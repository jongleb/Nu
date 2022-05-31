﻿//
// Box2.cs
//
// Copyright (C) 2019 OpenTK
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//

using System;
using System.Runtime.InteropServices;
using System.Numerics;

namespace Nu
{
    /// <summary>
    /// Defines an axis-aligned 2D box (rectangle).
    /// Copied from - https://github.com/opentk/opentk/blob/opentk5.0/src/OpenTK.Mathematics/Geometry/Box2.cs
    /// Heavily modified by BGE to more closely conform to System.Numerics and use a size-preserving representation
    /// ([pos, siz] instead of [min, max]).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Box2 : IEquatable<Box2>
    {
        /// <summary>
        /// The position of the box.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// The size of the box.
        /// </summary>
        public Vector2 Size;

        /// <summary>
        /// Initializes a new instance of the <see cref="Box2"/> struct.
        /// </summary>
        public Box2(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Box2"/> struct.
        /// </summary>
        public Box2(float positionX, float positionY, float sizeX, float sizeY)
        {
            Position = new Vector2(positionX, positionY);
            Size = new Vector2(sizeX, sizeY);
        }

        /// <summary>
        /// Gets a box with a position 0,0 with the a size of 0,0.
        /// </summary>
        public static readonly Box2 Zero = default(Box2);

        /// <summary>
        /// Gets a box with a position 0,0 with the a size of 1,1.
        /// </summary>
        public static readonly Box2 Unit = new Box2(new Vector2(0, 0), new Vector2(1, 1));

        /// <summary>
        /// Create a bounding box by enclosing two points.
        /// </summary>
        public static Box2 Enclose(Vector2 point, Vector2 point2)
        {
            var position = new Vector2(
                Math.Min(point.X, point2.X),
                Math.Min(point.Y, point2.Y));
            var position2 = new Vector2(
                Math.Max(point.X, point2.X),
                Math.Max(point.Y, point2.Y));
            return new Box2(position, position2 - position);
        }

        /// <summary>
        /// Equality comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static bool operator ==(Box2 left, Box2 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Inequality comparator.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        public static bool operator !=(Box2 left, Box2 right)
        {
            return !(left == right);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is Box2 box && Equals(box);
        }

        /// <inheritdoc/>
        public bool Equals(Box2 other)
        {
            return
                Position.Equals(other.Position) &&
                Size.Equals(other.Size);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = Position.GetHashCode();
            hashCode = (hashCode * 397) ^ Size.GetHashCode();
            return hashCode;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return String.Format("{0}\n{1}", Position, Size);
        }
    }
}