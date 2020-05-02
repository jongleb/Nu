﻿namespace OmniBlade
open System
open Prime
open Nu
open OmniBlade

[<RequireQualifiedAccess>]
module Constants =

    [<RequireQualifiedAccess>]
    module Audio =

        // TODO: implement these to use the master volume functionality of the engine
        // when that is finally implemented.
        let MasterSongVolume = 0.5f
        let MasterSoundVolume = 1.0f

    [<RequireQualifiedAccess>]
    module Battle =

        let AllyMax = 3
        let ActionTime = 999
        let AutoBattleReadyTime = 48
        let ActionTimeInc = 3
        let DefendingCounterBuff = 0.5f
        let CancelPosition = v2 -448.0f -240.0f
        let CharacterCenterOffset = v2 0.0f -16.0f

    [<RequireQualifiedAccess>]
    module OmniBlade =

        let DissolveData =
            { IncomingTime = 20L
              OutgoingTime = 30L
              DissolveImage = asset<Image> Assets.GuiPackage "Dissolve" }

        let SplashData =
            { DissolveData = DissolveData
              IdlingTime = 60L
              SplashImage = asset<Image> Assets.GuiPackage "Nu" }