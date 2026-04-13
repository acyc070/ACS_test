using System;

namespace TMG.Lookup
{
	// Token: 0x020005CD RID: 1485
	public static class AssetLookup
	{
		// Token: 0x020005CE RID: 1486
		public static class Tags
		{
			// Token: 0x040020FD RID: 8445
			public const string UNTAGGED = "Untagged";

			// Token: 0x040020FE RID: 8446
			public const string RESPAWN = "Respawn";

			// Token: 0x040020FF RID: 8447
			public const string FINISH = "Finish";

			// Token: 0x04002100 RID: 8448
			public const string EDITOR_ONLY = "EditorOnly";

			// Token: 0x04002101 RID: 8449
			public const string MAIN_CAMERA = "MainCamera";

			// Token: 0x04002102 RID: 8450
			public const string PLAYER = "Player";

			// Token: 0x04002103 RID: 8451
			public const string GAME_CONTROLLER = "GameController";

			// Token: 0x04002104 RID: 8452
			public const string ENEMY = "Enemy";

			// Token: 0x04002105 RID: 8453
			public const string P_SOUND = "PSound";

			// Token: 0x04002106 RID: 8454
			public const string CAMERA_1 = "Camera1";

			// Token: 0x04002107 RID: 8455
			public const string CAMERA_ONE = "CameraOne";

			// Token: 0x04002108 RID: 8456
			public const string LOADER = "Loader";

			// Token: 0x04002109 RID: 8457
			public const string TARGET = "Target";

			// Token: 0x0400210A RID: 8458
			public const string SHAKER = "Shaker";

			// Token: 0x0400210B RID: 8459
			public const string UI_VISUAL_CONTROLS = "UIVisualControls";

			// Token: 0x0400210C RID: 8460
			public const string UI_CAMERA = "UICamera";

			// Token: 0x0400210D RID: 8461
			public const string INK = "Ink";

			// Token: 0x0400210E RID: 8462
			public const string STAIRS = "Stairs";

			// Token: 0x0400210F RID: 8463
			public const string DEEP_INK = "DeepInk";

			// Token: 0x04002110 RID: 8464
			public const string SAMMY_TRIGGER = "SammyTrigger";

			// Token: 0x04002111 RID: 8465
			public const string STAIRS_INK = "StairsInk";

			// Token: 0x04002112 RID: 8466
			public const string AI = "Ai";

			// Token: 0x04002113 RID: 8467
			public const string VENT = "Vent";

			// Token: 0x04002114 RID: 8468
			public const string DIRT = "Dirt";

			// Token: 0x04002115 RID: 8469
			public const string METAL = "Metal";

			// Token: 0x04002116 RID: 8470
			public const string TILE = "Tile";

			// Token: 0x04002117 RID: 8471
			public const string FAIR_GAME = "FairGame";

			// Token: 0x04002118 RID: 8472
			public const string POCKET = "Pocket";

			// Token: 0x04002119 RID: 8473
			public const string IGNORE_DO_F = "IgnoreDoF";

			// Token: 0x0400211A RID: 8474
			public const string DEAD = "Dead";
		}

		// Token: 0x020005CF RID: 1487
		public static class Layers
		{
			// Token: 0x0400211B RID: 8475
			public const string DEFAULT = "Default";

			// Token: 0x0400211C RID: 8476
			public const string TRANSPARENT_FX = "TransparentFX";

			// Token: 0x0400211D RID: 8477
			public const string IGNORE_RAYCAST = "Ignore Raycast";

			// Token: 0x0400211E RID: 8478
			public const string WATER = "Water";

			// Token: 0x0400211F RID: 8479
			public const string UI = "UI";

			// Token: 0x04002120 RID: 8480
			public const string PLAYER = "Player";

			// Token: 0x04002121 RID: 8481
			public const string CREDITS = "Credits";

			// Token: 0x04002122 RID: 8482
			public const string WEAPON = "Weapon";

			// Token: 0x04002123 RID: 8483
			public const string BREAKABLE_PLANK = "BreakablePlank";

			// Token: 0x04002124 RID: 8484
			public const string STATIC_PLANK = "StaticPlank";

			// Token: 0x04002125 RID: 8485
			public const string TRIGGER = "Trigger";

			// Token: 0x04002126 RID: 8486
			public const string EVENT_TRIGGER = "EventTrigger";

			// Token: 0x04002127 RID: 8487
			public const string IGNORE_PLAYER = "IgnorePlayer";

			// Token: 0x04002128 RID: 8488
			public const string INVISIBLE = "Invisible";

			// Token: 0x04002129 RID: 8489
			public const string INVISIBLE_COLLIDER = "InvisibleCollider";

			// Token: 0x0400212A RID: 8490
			public const string AI_COLLIDER = "AiCollider";

			// Token: 0x0400212B RID: 8491
			public const string IGNORE_LIGHT = "IgnoreLight";

			// Token: 0x0400212C RID: 8492
			public const string AI = "Ai";

			// Token: 0x0400212D RID: 8493
			public const string JOINTS = "Joints";

			// Token: 0x0400212E RID: 8494
			public const string AI_IGNORE = "Ai_Ignore";

			// Token: 0x0400212F RID: 8495
			public const string SELF_DEFAULT = "SelfDefault";

			// Token: 0x04002130 RID: 8496
			public const string ALLY = "Ally";

			// Token: 0x04002131 RID: 8497
			public const string BENDY = "Bendy";

			// Token: 0x04002132 RID: 8498
			public const string IGNORE_INVISIBLE_COLLIDER = "IgnoreInvisibleCollider";

			// Token: 0x04002133 RID: 8499
			public const string IGNORE_SELF = "IgnoreSelf";

			// Token: 0x04002134 RID: 8500
			public const string AUDIO = "Audio";

			// Token: 0x04002135 RID: 8501
			public const string UI_PARTICLES = "UIParticles";

			// Token: 0x04002136 RID: 8502
			public const string LOCKED = "Locked";
		}

		// Token: 0x020005D0 RID: 1488
		public static class SortingLayers
		{
			// Token: 0x04002137 RID: 8503
			public const string DEFAULT = "Default";
		}

		// Token: 0x020005D1 RID: 1489
		public static class InputAxes
		{
			// Token: 0x04002138 RID: 8504
			public const string JOYSTICK_1ANALOG_0 = "joystick 1 analog 0";

			// Token: 0x04002139 RID: 8505
			public const string JOYSTICK_1ANALOG_1 = "joystick 1 analog 1";

			// Token: 0x0400213A RID: 8506
			public const string JOYSTICK_1ANALOG_2 = "joystick 1 analog 2";

			// Token: 0x0400213B RID: 8507
			public const string JOYSTICK_1ANALOG_3 = "joystick 1 analog 3";

			// Token: 0x0400213C RID: 8508
			public const string JOYSTICK_1ANALOG_4 = "joystick 1 analog 4";

			// Token: 0x0400213D RID: 8509
			public const string JOYSTICK_1ANALOG_5 = "joystick 1 analog 5";

			// Token: 0x0400213E RID: 8510
			public const string JOYSTICK_1ANALOG_6 = "joystick 1 analog 6";

			// Token: 0x0400213F RID: 8511
			public const string JOYSTICK_1ANALOG_7 = "joystick 1 analog 7";

			// Token: 0x04002140 RID: 8512
			public const string JOYSTICK_1ANALOG_8 = "joystick 1 analog 8";

			// Token: 0x04002141 RID: 8513
			public const string JOYSTICK_1ANALOG_9 = "joystick 1 analog 9";

			// Token: 0x04002142 RID: 8514
			public const string JOYSTICK_1ANALOG_10 = "joystick 1 analog 10";

			// Token: 0x04002143 RID: 8515
			public const string JOYSTICK_1ANALOG_11 = "joystick 1 analog 11";

			// Token: 0x04002144 RID: 8516
			public const string JOYSTICK_1ANALOG_12 = "joystick 1 analog 12";

			// Token: 0x04002145 RID: 8517
			public const string JOYSTICK_1ANALOG_13 = "joystick 1 analog 13";

			// Token: 0x04002146 RID: 8518
			public const string JOYSTICK_1ANALOG_14 = "joystick 1 analog 14";

			// Token: 0x04002147 RID: 8519
			public const string JOYSTICK_1ANALOG_15 = "joystick 1 analog 15";

			// Token: 0x04002148 RID: 8520
			public const string JOYSTICK_1ANALOG_16 = "joystick 1 analog 16";

			// Token: 0x04002149 RID: 8521
			public const string JOYSTICK_1ANALOG_17 = "joystick 1 analog 17";

			// Token: 0x0400214A RID: 8522
			public const string JOYSTICK_1ANALOG_18 = "joystick 1 analog 18";

			// Token: 0x0400214B RID: 8523
			public const string JOYSTICK_1ANALOG_19 = "joystick 1 analog 19";

			// Token: 0x0400214C RID: 8524
			public const string JOYSTICK_2ANALOG_0 = "joystick 2 analog 0";

			// Token: 0x0400214D RID: 8525
			public const string JOYSTICK_2ANALOG_1 = "joystick 2 analog 1";

			// Token: 0x0400214E RID: 8526
			public const string JOYSTICK_2ANALOG_2 = "joystick 2 analog 2";

			// Token: 0x0400214F RID: 8527
			public const string JOYSTICK_2ANALOG_3 = "joystick 2 analog 3";

			// Token: 0x04002150 RID: 8528
			public const string JOYSTICK_2ANALOG_4 = "joystick 2 analog 4";

			// Token: 0x04002151 RID: 8529
			public const string JOYSTICK_2ANALOG_5 = "joystick 2 analog 5";

			// Token: 0x04002152 RID: 8530
			public const string JOYSTICK_2ANALOG_6 = "joystick 2 analog 6";

			// Token: 0x04002153 RID: 8531
			public const string JOYSTICK_2ANALOG_7 = "joystick 2 analog 7";

			// Token: 0x04002154 RID: 8532
			public const string JOYSTICK_2ANALOG_8 = "joystick 2 analog 8";

			// Token: 0x04002155 RID: 8533
			public const string JOYSTICK_2ANALOG_9 = "joystick 2 analog 9";

			// Token: 0x04002156 RID: 8534
			public const string JOYSTICK_2ANALOG_10 = "joystick 2 analog 10";

			// Token: 0x04002157 RID: 8535
			public const string JOYSTICK_2ANALOG_11 = "joystick 2 analog 11";

			// Token: 0x04002158 RID: 8536
			public const string JOYSTICK_2ANALOG_12 = "joystick 2 analog 12";

			// Token: 0x04002159 RID: 8537
			public const string JOYSTICK_2ANALOG_13 = "joystick 2 analog 13";

			// Token: 0x0400215A RID: 8538
			public const string JOYSTICK_2ANALOG_14 = "joystick 2 analog 14";

			// Token: 0x0400215B RID: 8539
			public const string JOYSTICK_2ANALOG_15 = "joystick 2 analog 15";

			// Token: 0x0400215C RID: 8540
			public const string JOYSTICK_2ANALOG_16 = "joystick 2 analog 16";

			// Token: 0x0400215D RID: 8541
			public const string JOYSTICK_2ANALOG_17 = "joystick 2 analog 17";

			// Token: 0x0400215E RID: 8542
			public const string JOYSTICK_2ANALOG_18 = "joystick 2 analog 18";

			// Token: 0x0400215F RID: 8543
			public const string JOYSTICK_2ANALOG_19 = "joystick 2 analog 19";

			// Token: 0x04002160 RID: 8544
			public const string JOYSTICK_3ANALOG_0 = "joystick 3 analog 0";

			// Token: 0x04002161 RID: 8545
			public const string JOYSTICK_3ANALOG_1 = "joystick 3 analog 1";

			// Token: 0x04002162 RID: 8546
			public const string JOYSTICK_3ANALOG_2 = "joystick 3 analog 2";

			// Token: 0x04002163 RID: 8547
			public const string JOYSTICK_3ANALOG_3 = "joystick 3 analog 3";

			// Token: 0x04002164 RID: 8548
			public const string JOYSTICK_3ANALOG_4 = "joystick 3 analog 4";

			// Token: 0x04002165 RID: 8549
			public const string JOYSTICK_3ANALOG_5 = "joystick 3 analog 5";

			// Token: 0x04002166 RID: 8550
			public const string JOYSTICK_3ANALOG_6 = "joystick 3 analog 6";

			// Token: 0x04002167 RID: 8551
			public const string JOYSTICK_3ANALOG_7 = "joystick 3 analog 7";

			// Token: 0x04002168 RID: 8552
			public const string JOYSTICK_3ANALOG_8 = "joystick 3 analog 8";

			// Token: 0x04002169 RID: 8553
			public const string JOYSTICK_3ANALOG_9 = "joystick 3 analog 9";

			// Token: 0x0400216A RID: 8554
			public const string JOYSTICK_3ANALOG_10 = "joystick 3 analog 10";

			// Token: 0x0400216B RID: 8555
			public const string JOYSTICK_3ANALOG_11 = "joystick 3 analog 11";

			// Token: 0x0400216C RID: 8556
			public const string JOYSTICK_3ANALOG_12 = "joystick 3 analog 12";

			// Token: 0x0400216D RID: 8557
			public const string JOYSTICK_3ANALOG_13 = "joystick 3 analog 13";

			// Token: 0x0400216E RID: 8558
			public const string JOYSTICK_3ANALOG_14 = "joystick 3 analog 14";

			// Token: 0x0400216F RID: 8559
			public const string JOYSTICK_3ANALOG_15 = "joystick 3 analog 15";

			// Token: 0x04002170 RID: 8560
			public const string JOYSTICK_3ANALOG_16 = "joystick 3 analog 16";

			// Token: 0x04002171 RID: 8561
			public const string JOYSTICK_3ANALOG_17 = "joystick 3 analog 17";

			// Token: 0x04002172 RID: 8562
			public const string JOYSTICK_3ANALOG_18 = "joystick 3 analog 18";

			// Token: 0x04002173 RID: 8563
			public const string JOYSTICK_3ANALOG_19 = "joystick 3 analog 19";

			// Token: 0x04002174 RID: 8564
			public const string JOYSTICK_4ANALOG_0 = "joystick 4 analog 0";

			// Token: 0x04002175 RID: 8565
			public const string JOYSTICK_4ANALOG_1 = "joystick 4 analog 1";

			// Token: 0x04002176 RID: 8566
			public const string JOYSTICK_4ANALOG_2 = "joystick 4 analog 2";

			// Token: 0x04002177 RID: 8567
			public const string JOYSTICK_4ANALOG_3 = "joystick 4 analog 3";

			// Token: 0x04002178 RID: 8568
			public const string JOYSTICK_4ANALOG_4 = "joystick 4 analog 4";

			// Token: 0x04002179 RID: 8569
			public const string JOYSTICK_4ANALOG_5 = "joystick 4 analog 5";

			// Token: 0x0400217A RID: 8570
			public const string JOYSTICK_4ANALOG_6 = "joystick 4 analog 6";

			// Token: 0x0400217B RID: 8571
			public const string JOYSTICK_4ANALOG_7 = "joystick 4 analog 7";

			// Token: 0x0400217C RID: 8572
			public const string JOYSTICK_4ANALOG_8 = "joystick 4 analog 8";

			// Token: 0x0400217D RID: 8573
			public const string JOYSTICK_4ANALOG_9 = "joystick 4 analog 9";

			// Token: 0x0400217E RID: 8574
			public const string JOYSTICK_4ANALOG_10 = "joystick 4 analog 10";

			// Token: 0x0400217F RID: 8575
			public const string JOYSTICK_4ANALOG_11 = "joystick 4 analog 11";

			// Token: 0x04002180 RID: 8576
			public const string JOYSTICK_4ANALOG_12 = "joystick 4 analog 12";

			// Token: 0x04002181 RID: 8577
			public const string JOYSTICK_4ANALOG_13 = "joystick 4 analog 13";

			// Token: 0x04002182 RID: 8578
			public const string JOYSTICK_4ANALOG_14 = "joystick 4 analog 14";

			// Token: 0x04002183 RID: 8579
			public const string JOYSTICK_4ANALOG_15 = "joystick 4 analog 15";

			// Token: 0x04002184 RID: 8580
			public const string JOYSTICK_4ANALOG_16 = "joystick 4 analog 16";

			// Token: 0x04002185 RID: 8581
			public const string JOYSTICK_4ANALOG_17 = "joystick 4 analog 17";

			// Token: 0x04002186 RID: 8582
			public const string JOYSTICK_4ANALOG_18 = "joystick 4 analog 18";

			// Token: 0x04002187 RID: 8583
			public const string JOYSTICK_4ANALOG_19 = "joystick 4 analog 19";

			// Token: 0x04002188 RID: 8584
			public const string JOYSTICK_5ANALOG_0 = "joystick 5 analog 0";

			// Token: 0x04002189 RID: 8585
			public const string JOYSTICK_5ANALOG_1 = "joystick 5 analog 1";

			// Token: 0x0400218A RID: 8586
			public const string JOYSTICK_5ANALOG_2 = "joystick 5 analog 2";

			// Token: 0x0400218B RID: 8587
			public const string JOYSTICK_5ANALOG_3 = "joystick 5 analog 3";

			// Token: 0x0400218C RID: 8588
			public const string JOYSTICK_5ANALOG_4 = "joystick 5 analog 4";

			// Token: 0x0400218D RID: 8589
			public const string JOYSTICK_5ANALOG_5 = "joystick 5 analog 5";

			// Token: 0x0400218E RID: 8590
			public const string JOYSTICK_5ANALOG_6 = "joystick 5 analog 6";

			// Token: 0x0400218F RID: 8591
			public const string JOYSTICK_5ANALOG_7 = "joystick 5 analog 7";

			// Token: 0x04002190 RID: 8592
			public const string JOYSTICK_5ANALOG_8 = "joystick 5 analog 8";

			// Token: 0x04002191 RID: 8593
			public const string JOYSTICK_5ANALOG_9 = "joystick 5 analog 9";

			// Token: 0x04002192 RID: 8594
			public const string JOYSTICK_5ANALOG_10 = "joystick 5 analog 10";

			// Token: 0x04002193 RID: 8595
			public const string JOYSTICK_5ANALOG_11 = "joystick 5 analog 11";

			// Token: 0x04002194 RID: 8596
			public const string JOYSTICK_5ANALOG_12 = "joystick 5 analog 12";

			// Token: 0x04002195 RID: 8597
			public const string JOYSTICK_5ANALOG_13 = "joystick 5 analog 13";

			// Token: 0x04002196 RID: 8598
			public const string JOYSTICK_5ANALOG_14 = "joystick 5 analog 14";

			// Token: 0x04002197 RID: 8599
			public const string JOYSTICK_5ANALOG_15 = "joystick 5 analog 15";

			// Token: 0x04002198 RID: 8600
			public const string JOYSTICK_5ANALOG_16 = "joystick 5 analog 16";

			// Token: 0x04002199 RID: 8601
			public const string JOYSTICK_5ANALOG_17 = "joystick 5 analog 17";

			// Token: 0x0400219A RID: 8602
			public const string JOYSTICK_5ANALOG_18 = "joystick 5 analog 18";

			// Token: 0x0400219B RID: 8603
			public const string JOYSTICK_5ANALOG_19 = "joystick 5 analog 19";

			// Token: 0x0400219C RID: 8604
			public const string JOYSTICK_6ANALOG_0 = "joystick 6 analog 0";

			// Token: 0x0400219D RID: 8605
			public const string JOYSTICK_6ANALOG_1 = "joystick 6 analog 1";

			// Token: 0x0400219E RID: 8606
			public const string JOYSTICK_6ANALOG_2 = "joystick 6 analog 2";

			// Token: 0x0400219F RID: 8607
			public const string JOYSTICK_6ANALOG_3 = "joystick 6 analog 3";

			// Token: 0x040021A0 RID: 8608
			public const string JOYSTICK_6ANALOG_4 = "joystick 6 analog 4";

			// Token: 0x040021A1 RID: 8609
			public const string JOYSTICK_6ANALOG_5 = "joystick 6 analog 5";

			// Token: 0x040021A2 RID: 8610
			public const string JOYSTICK_6ANALOG_6 = "joystick 6 analog 6";

			// Token: 0x040021A3 RID: 8611
			public const string JOYSTICK_6ANALOG_7 = "joystick 6 analog 7";

			// Token: 0x040021A4 RID: 8612
			public const string JOYSTICK_6ANALOG_8 = "joystick 6 analog 8";

			// Token: 0x040021A5 RID: 8613
			public const string JOYSTICK_6ANALOG_9 = "joystick 6 analog 9";

			// Token: 0x040021A6 RID: 8614
			public const string JOYSTICK_6ANALOG_10 = "joystick 6 analog 10";

			// Token: 0x040021A7 RID: 8615
			public const string JOYSTICK_6ANALOG_11 = "joystick 6 analog 11";

			// Token: 0x040021A8 RID: 8616
			public const string JOYSTICK_6ANALOG_12 = "joystick 6 analog 12";

			// Token: 0x040021A9 RID: 8617
			public const string JOYSTICK_6ANALOG_13 = "joystick 6 analog 13";

			// Token: 0x040021AA RID: 8618
			public const string JOYSTICK_6ANALOG_14 = "joystick 6 analog 14";

			// Token: 0x040021AB RID: 8619
			public const string JOYSTICK_6ANALOG_15 = "joystick 6 analog 15";

			// Token: 0x040021AC RID: 8620
			public const string JOYSTICK_6ANALOG_16 = "joystick 6 analog 16";

			// Token: 0x040021AD RID: 8621
			public const string JOYSTICK_6ANALOG_17 = "joystick 6 analog 17";

			// Token: 0x040021AE RID: 8622
			public const string JOYSTICK_6ANALOG_18 = "joystick 6 analog 18";

			// Token: 0x040021AF RID: 8623
			public const string JOYSTICK_6ANALOG_19 = "joystick 6 analog 19";

			// Token: 0x040021B0 RID: 8624
			public const string JOYSTICK_7ANALOG_0 = "joystick 7 analog 0";

			// Token: 0x040021B1 RID: 8625
			public const string JOYSTICK_7ANALOG_1 = "joystick 7 analog 1";

			// Token: 0x040021B2 RID: 8626
			public const string JOYSTICK_7ANALOG_2 = "joystick 7 analog 2";

			// Token: 0x040021B3 RID: 8627
			public const string JOYSTICK_7ANALOG_3 = "joystick 7 analog 3";

			// Token: 0x040021B4 RID: 8628
			public const string JOYSTICK_7ANALOG_4 = "joystick 7 analog 4";

			// Token: 0x040021B5 RID: 8629
			public const string JOYSTICK_7ANALOG_5 = "joystick 7 analog 5";

			// Token: 0x040021B6 RID: 8630
			public const string JOYSTICK_7ANALOG_6 = "joystick 7 analog 6";

			// Token: 0x040021B7 RID: 8631
			public const string JOYSTICK_7ANALOG_7 = "joystick 7 analog 7";

			// Token: 0x040021B8 RID: 8632
			public const string JOYSTICK_7ANALOG_8 = "joystick 7 analog 8";

			// Token: 0x040021B9 RID: 8633
			public const string JOYSTICK_7ANALOG_9 = "joystick 7 analog 9";

			// Token: 0x040021BA RID: 8634
			public const string JOYSTICK_7ANALOG_10 = "joystick 7 analog 10";

			// Token: 0x040021BB RID: 8635
			public const string JOYSTICK_7ANALOG_11 = "joystick 7 analog 11";

			// Token: 0x040021BC RID: 8636
			public const string JOYSTICK_7ANALOG_12 = "joystick 7 analog 12";

			// Token: 0x040021BD RID: 8637
			public const string JOYSTICK_7ANALOG_13 = "joystick 7 analog 13";

			// Token: 0x040021BE RID: 8638
			public const string JOYSTICK_7ANALOG_14 = "joystick 7 analog 14";

			// Token: 0x040021BF RID: 8639
			public const string JOYSTICK_7ANALOG_15 = "joystick 7 analog 15";

			// Token: 0x040021C0 RID: 8640
			public const string JOYSTICK_7ANALOG_16 = "joystick 7 analog 16";

			// Token: 0x040021C1 RID: 8641
			public const string JOYSTICK_7ANALOG_17 = "joystick 7 analog 17";

			// Token: 0x040021C2 RID: 8642
			public const string JOYSTICK_7ANALOG_18 = "joystick 7 analog 18";

			// Token: 0x040021C3 RID: 8643
			public const string JOYSTICK_7ANALOG_19 = "joystick 7 analog 19";

			// Token: 0x040021C4 RID: 8644
			public const string JOYSTICK_8ANALOG_0 = "joystick 8 analog 0";

			// Token: 0x040021C5 RID: 8645
			public const string JOYSTICK_8ANALOG_1 = "joystick 8 analog 1";

			// Token: 0x040021C6 RID: 8646
			public const string JOYSTICK_8ANALOG_2 = "joystick 8 analog 2";

			// Token: 0x040021C7 RID: 8647
			public const string JOYSTICK_8ANALOG_3 = "joystick 8 analog 3";

			// Token: 0x040021C8 RID: 8648
			public const string JOYSTICK_8ANALOG_4 = "joystick 8 analog 4";

			// Token: 0x040021C9 RID: 8649
			public const string JOYSTICK_8ANALOG_5 = "joystick 8 analog 5";

			// Token: 0x040021CA RID: 8650
			public const string JOYSTICK_8ANALOG_6 = "joystick 8 analog 6";

			// Token: 0x040021CB RID: 8651
			public const string JOYSTICK_8ANALOG_7 = "joystick 8 analog 7";

			// Token: 0x040021CC RID: 8652
			public const string JOYSTICK_8ANALOG_8 = "joystick 8 analog 8";

			// Token: 0x040021CD RID: 8653
			public const string JOYSTICK_8ANALOG_9 = "joystick 8 analog 9";

			// Token: 0x040021CE RID: 8654
			public const string JOYSTICK_8ANALOG_10 = "joystick 8 analog 10";

			// Token: 0x040021CF RID: 8655
			public const string JOYSTICK_8ANALOG_11 = "joystick 8 analog 11";

			// Token: 0x040021D0 RID: 8656
			public const string JOYSTICK_8ANALOG_12 = "joystick 8 analog 12";

			// Token: 0x040021D1 RID: 8657
			public const string JOYSTICK_8ANALOG_13 = "joystick 8 analog 13";

			// Token: 0x040021D2 RID: 8658
			public const string JOYSTICK_8ANALOG_14 = "joystick 8 analog 14";

			// Token: 0x040021D3 RID: 8659
			public const string JOYSTICK_8ANALOG_15 = "joystick 8 analog 15";

			// Token: 0x040021D4 RID: 8660
			public const string JOYSTICK_8ANALOG_16 = "joystick 8 analog 16";

			// Token: 0x040021D5 RID: 8661
			public const string JOYSTICK_8ANALOG_17 = "joystick 8 analog 17";

			// Token: 0x040021D6 RID: 8662
			public const string JOYSTICK_8ANALOG_18 = "joystick 8 analog 18";

			// Token: 0x040021D7 RID: 8663
			public const string JOYSTICK_8ANALOG_19 = "joystick 8 analog 19";

			// Token: 0x040021D8 RID: 8664
			public const string JOYSTICK_9ANALOG_0 = "joystick 9 analog 0";

			// Token: 0x040021D9 RID: 8665
			public const string JOYSTICK_9ANALOG_1 = "joystick 9 analog 1";

			// Token: 0x040021DA RID: 8666
			public const string JOYSTICK_9ANALOG_2 = "joystick 9 analog 2";

			// Token: 0x040021DB RID: 8667
			public const string JOYSTICK_9ANALOG_3 = "joystick 9 analog 3";

			// Token: 0x040021DC RID: 8668
			public const string JOYSTICK_9ANALOG_4 = "joystick 9 analog 4";

			// Token: 0x040021DD RID: 8669
			public const string JOYSTICK_9ANALOG_5 = "joystick 9 analog 5";

			// Token: 0x040021DE RID: 8670
			public const string JOYSTICK_9ANALOG_6 = "joystick 9 analog 6";

			// Token: 0x040021DF RID: 8671
			public const string JOYSTICK_9ANALOG_7 = "joystick 9 analog 7";

			// Token: 0x040021E0 RID: 8672
			public const string JOYSTICK_9ANALOG_8 = "joystick 9 analog 8";

			// Token: 0x040021E1 RID: 8673
			public const string JOYSTICK_9ANALOG_9 = "joystick 9 analog 9";

			// Token: 0x040021E2 RID: 8674
			public const string JOYSTICK_9ANALOG_10 = "joystick 9 analog 10";

			// Token: 0x040021E3 RID: 8675
			public const string JOYSTICK_9ANALOG_11 = "joystick 9 analog 11";

			// Token: 0x040021E4 RID: 8676
			public const string JOYSTICK_9ANALOG_12 = "joystick 9 analog 12";

			// Token: 0x040021E5 RID: 8677
			public const string JOYSTICK_9ANALOG_13 = "joystick 9 analog 13";

			// Token: 0x040021E6 RID: 8678
			public const string JOYSTICK_9ANALOG_14 = "joystick 9 analog 14";

			// Token: 0x040021E7 RID: 8679
			public const string JOYSTICK_9ANALOG_15 = "joystick 9 analog 15";

			// Token: 0x040021E8 RID: 8680
			public const string JOYSTICK_9ANALOG_16 = "joystick 9 analog 16";

			// Token: 0x040021E9 RID: 8681
			public const string JOYSTICK_9ANALOG_17 = "joystick 9 analog 17";

			// Token: 0x040021EA RID: 8682
			public const string JOYSTICK_9ANALOG_18 = "joystick 9 analog 18";

			// Token: 0x040021EB RID: 8683
			public const string JOYSTICK_9ANALOG_19 = "joystick 9 analog 19";

			// Token: 0x040021EC RID: 8684
			public const string JOYSTICK_10ANALOG_0 = "joystick 10 analog 0";

			// Token: 0x040021ED RID: 8685
			public const string JOYSTICK_10ANALOG_1 = "joystick 10 analog 1";

			// Token: 0x040021EE RID: 8686
			public const string JOYSTICK_10ANALOG_2 = "joystick 10 analog 2";

			// Token: 0x040021EF RID: 8687
			public const string JOYSTICK_10ANALOG_3 = "joystick 10 analog 3";

			// Token: 0x040021F0 RID: 8688
			public const string JOYSTICK_10ANALOG_4 = "joystick 10 analog 4";

			// Token: 0x040021F1 RID: 8689
			public const string JOYSTICK_10ANALOG_5 = "joystick 10 analog 5";

			// Token: 0x040021F2 RID: 8690
			public const string JOYSTICK_10ANALOG_6 = "joystick 10 analog 6";

			// Token: 0x040021F3 RID: 8691
			public const string JOYSTICK_10ANALOG_7 = "joystick 10 analog 7";

			// Token: 0x040021F4 RID: 8692
			public const string JOYSTICK_10ANALOG_8 = "joystick 10 analog 8";

			// Token: 0x040021F5 RID: 8693
			public const string JOYSTICK_10ANALOG_9 = "joystick 10 analog 9";

			// Token: 0x040021F6 RID: 8694
			public const string JOYSTICK_10ANALOG_10 = "joystick 10 analog 10";

			// Token: 0x040021F7 RID: 8695
			public const string JOYSTICK_10ANALOG_11 = "joystick 10 analog 11";

			// Token: 0x040021F8 RID: 8696
			public const string JOYSTICK_10ANALOG_12 = "joystick 10 analog 12";

			// Token: 0x040021F9 RID: 8697
			public const string JOYSTICK_10ANALOG_13 = "joystick 10 analog 13";

			// Token: 0x040021FA RID: 8698
			public const string JOYSTICK_10ANALOG_14 = "joystick 10 analog 14";

			// Token: 0x040021FB RID: 8699
			public const string JOYSTICK_10ANALOG_15 = "joystick 10 analog 15";

			// Token: 0x040021FC RID: 8700
			public const string JOYSTICK_10ANALOG_16 = "joystick 10 analog 16";

			// Token: 0x040021FD RID: 8701
			public const string JOYSTICK_10ANALOG_17 = "joystick 10 analog 17";

			// Token: 0x040021FE RID: 8702
			public const string JOYSTICK_10ANALOG_18 = "joystick 10 analog 18";

			// Token: 0x040021FF RID: 8703
			public const string JOYSTICK_10ANALOG_19 = "joystick 10 analog 19";

			// Token: 0x04002200 RID: 8704
			public const string MOUSEX = "mouse x";

			// Token: 0x04002201 RID: 8705
			public const string MOUSEY = "mouse y";

			// Token: 0x04002202 RID: 8706
			public const string MOUSEZ = "mouse z";

			// Token: 0x04002203 RID: 8707
			public const string HORIZONTAL = "Horizontal";

			// Token: 0x04002204 RID: 8708
			public const string VERTICAL = "Vertical";

			// Token: 0x04002205 RID: 8709
			public const string JUMP = "Jump";

			// Token: 0x04002206 RID: 8710
			public const string MOUSE_X = "Mouse X";

			// Token: 0x04002207 RID: 8711
			public const string MOUSE_Y = "Mouse Y";

			// Token: 0x04002208 RID: 8712
			public const string SUBMIT = "Submit";

			// Token: 0x04002209 RID: 8713
			public const string CANCEL = "Cancel";

			// Token: 0x0400220A RID: 8714
			public const string MOUSE_SCROLL_WHEEL = "Mouse ScrollWheel";
		}

		// Token: 0x020005D2 RID: 1490
		public static class Audio
		{
			// Token: 0x0400220B RID: 8715
			public const string CH_1AUDIOLOGTHOMAS = "Audio/DIA/CH1/AudioLogs/ch1_audiolog_thomas";

			// Token: 0x0400220C RID: 8716
			public const string CH_1AUDIOLOGWALLY = "Audio/DIA/CH1/AudioLogs/ch1_audiolog_wally";

			// Token: 0x0400220D RID: 8717
			public const string DIACH_1_HENRY_01 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_01";

			// Token: 0x0400220E RID: 8718
			public const string DIACH_1_HENRY_02 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_02";

			// Token: 0x0400220F RID: 8719
			public const string DIACH_1_HENRY_03 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_03";

			// Token: 0x04002210 RID: 8720
			public const string DIACH_1_HENRY_04 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_04";

			// Token: 0x04002211 RID: 8721
			public const string DIACH_1_HENRY_05 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_05";

			// Token: 0x04002212 RID: 8722
			public const string DIACH_1_HENRY_06 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_06";

			// Token: 0x04002213 RID: 8723
			public const string DIACH_1_HENRY_07 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_07";

			// Token: 0x04002214 RID: 8724
			public const string DIACH_1_HENRY_08 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_08";

			// Token: 0x04002215 RID: 8725
			public const string DIACH_1_HENRY_09 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_09";

			// Token: 0x04002216 RID: 8726
			public const string DIACH_1_HENRY_10 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_10";

			// Token: 0x04002217 RID: 8727
			public const string DIACH_1_HENRY_11 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_11";

			// Token: 0x04002218 RID: 8728
			public const string DIACH_1_HENRY_12 = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_12";

			// Token: 0x04002219 RID: 8729
			public const string DIACH_1_HENRYFALL = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_FALL";

			// Token: 0x0400221A RID: 8730
			public const string DIACH_1_HENRYLAND = "Audio/DIA/CH1/Henry/DIA_CH1_HENRY_LAND";

			// Token: 0x0400221B RID: 8731
			public const string DIAHENRYSAVE_01 = "Audio/DIA/CH1/Henry/Save/DIA_HENRY_SAVE_01";

			// Token: 0x0400221C RID: 8732
			public const string DIAHENRYSAVE_02 = "Audio/DIA/CH1/Henry/Save/DIA_HENRY_SAVE_02";

			// Token: 0x0400221D RID: 8733
			public const string DIAHENRYSAVE_03 = "Audio/DIA/CH1/Henry/Save/DIA_HENRY_SAVE_03";

			// Token: 0x0400221E RID: 8734
			public const string DIAHENRYSAVE_04 = "Audio/DIA/CH1/Henry/Save/DIA_HENRY_SAVE_04";

			// Token: 0x0400221F RID: 8735
			public const string DIAHENRYSAVE_05 = "Audio/DIA/CH1/Henry/Save/DIA_HENRY_SAVE_05";

			// Token: 0x04002220 RID: 8736
			public const string CH_2AUDIOLOGJACKFAIN = "Audio/DIA/CH2/AudioLogs/ch2_audiolog_jackfain";

			// Token: 0x04002221 RID: 8737
			public const string DIANOR_DIARY_PROJECTIONIST_01TEMP = "Audio/DIA/CH2/AudioLogs/DIA_NOR_Diary_Projectionist_01_temp";

			// Token: 0x04002222 RID: 8738
			public const string DIA_SAMMY_C_2_AUDIO_DIARRY_01 = "Audio/DIA/CH2/AudioLogs/DIA_SammyC2_Audio_Diarry_01";

			// Token: 0x04002223 RID: 8739
			public const string DIASAM_DIARY_DISTRACTIONS_01TEMP = "Audio/DIA/CH2/AudioLogs/DIA_SAM_Diary_Distractions_01_temp";

			// Token: 0x04002224 RID: 8740
			public const string DIASUS_DIARY_NEW_VOICE_ACTRESS_01TEMP = "Audio/DIA/CH2/AudioLogs/DIA_SUS_Diary_New_Voice_Actress_01_temp";

			// Token: 0x04002225 RID: 8741
			public const string DIAWAL_DIARY_LOST_KEYS_01TEMP = "Audio/DIA/CH2/AudioLogs/DIA_WAL_Diary_Lost_Keys_01_temp";

			// Token: 0x04002226 RID: 8742
			public const string DIACH_2_HENRY_01 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_01";

			// Token: 0x04002227 RID: 8743
			public const string DIACH_2_HENRY_02 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_02";

			// Token: 0x04002228 RID: 8744
			public const string DIACH_2_HENRY_03 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_03";

			// Token: 0x04002229 RID: 8745
			public const string DIACH_2_HENRY_04 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_04";

			// Token: 0x0400222A RID: 8746
			public const string DIACH_2_HENRY_05 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_05";

			// Token: 0x0400222B RID: 8747
			public const string DIACH_2_HENRY_06 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_06";

			// Token: 0x0400222C RID: 8748
			public const string DIACH_2_HENRY_07 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_07";

			// Token: 0x0400222D RID: 8749
			public const string DIACH_2_HENRY_08 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_08";

			// Token: 0x0400222E RID: 8750
			public const string DIACH_2_HENRY_09 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_09";

			// Token: 0x0400222F RID: 8751
			public const string DIACH_2_HENRY_10 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_10";

			// Token: 0x04002230 RID: 8752
			public const string DIACH_2_HENRY_11 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_11";

			// Token: 0x04002231 RID: 8753
			public const string DIACH_2_HENRY_12 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_12";

			// Token: 0x04002232 RID: 8754
			public const string DIACH_2_HENRY_13 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_13";

			// Token: 0x04002233 RID: 8755
			public const string DIACH_2_HENRY_14 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_14";

			// Token: 0x04002234 RID: 8756
			public const string DIACH_2_HENRY_15 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_15";

			// Token: 0x04002235 RID: 8757
			public const string DIACH_2_HENRY_16 = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_16";

			// Token: 0x04002236 RID: 8758
			public const string DIACH_2_HENRYGETUP = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_GET_UP";

			// Token: 0x04002237 RID: 8759
			public const string DIACH_2_HENRYROPEBREAK = "Audio/DIA/CH2/Henry/DIA_CH2_HENRY_ROPE_BREAK";

			// Token: 0x04002238 RID: 8760
			public const string DIA_SAMMY_C_201 = "Audio/DIA/CH2/Sammy/DIA_SammyC2_01";

			// Token: 0x04002239 RID: 8761
			public const string DIA_SAMMY_FINALE_BG_AUDIO = "Audio/DIA/CH2/Sammy/DIA_Sammy_Finale_BG_Audio";

			// Token: 0x0400223A RID: 8762
			public const string DIA_SAMMY_FINALE_MONOLOGUE_LINE_01 = "Audio/DIA/CH2/Sammy/FinaleMonologue/DIA_Sammy_Finale_Monologue_Line_01";

			// Token: 0x0400223B RID: 8763
			public const string DIA_SAMMY_FINALE_MONOLOGUE_LINE_02 = "Audio/DIA/CH2/Sammy/FinaleMonologue/DIA_Sammy_Finale_Monologue_Line_02";

			// Token: 0x0400223C RID: 8764
			public const string DIA_SAMMY_FINALE_MONOLOGUE_LINE_03 = "Audio/DIA/CH2/Sammy/FinaleMonologue/DIA_Sammy_Finale_Monologue_Line_03";

			// Token: 0x0400223D RID: 8765
			public const string DIA_SAMMY_FINALE_MONOLOGUE_LINE_04 = "Audio/DIA/CH2/Sammy/FinaleMonologue/DIA_Sammy_Finale_Monologue_Line_04";

			// Token: 0x0400223E RID: 8766
			public const string DIA_SAMMY_FINALE_MONOLOGUE_LINE_05 = "Audio/DIA/CH2/Sammy/FinaleMonologue/DIA_Sammy_Finale_Monologue_Line_05";

			// Token: 0x0400223F RID: 8767
			public const string DIA_SAMMY_FINALE_MONOLOGUE_LINE_06 = "Audio/DIA/CH2/Sammy/FinaleMonologue/DIA_Sammy_Finale_Monologue_Line_06";

			// Token: 0x04002240 RID: 8768
			public const string DIA_SAMMY_FINALE_MONOLOGUE_LINE_07 = "Audio/DIA/CH2/Sammy/FinaleMonologue/DIA_Sammy_Finale_Monologue_Line_07";

			// Token: 0x04002241 RID: 8769
			public const string DIA_SAMMY_FINALE_MONOLOGUE_LINE_08 = "Audio/DIA/CH2/Sammy/FinaleMonologue/DIA_Sammy_Finale_Monologue_Line_08";

			// Token: 0x04002242 RID: 8770
			public const string DIA_SAMMY_FINALE_MONOLOGUE_LINE_09 = "Audio/DIA/CH2/Sammy/FinaleMonologue/DIA_Sammy_Finale_Monologue_Line_09";

			// Token: 0x04002243 RID: 8771
			public const string DIA_SAMMY_FINALE_MONOLOGUE_LINE_10 = "Audio/DIA/CH2/Sammy/FinaleMonologue/DIA_Sammy_Finale_Monologue_Line_10";

			// Token: 0x04002244 RID: 8772
			public const string DIA_SAMMY_FINALE_MONOLOGUE_LINE_11 = "Audio/DIA/CH2/Sammy/FinaleMonologue/DIA_Sammy_Finale_Monologue_Line_11";

			// Token: 0x04002245 RID: 8773
			public const string DIA_SAMMY_FINALE_SPEAKER_LINE_01 = "Audio/DIA/CH2/Sammy/FinaleMonologueSpeaker/DIA_Sammy_Finale_Speaker_Line_01";

			// Token: 0x04002246 RID: 8774
			public const string DIA_SAMMY_FINALE_SPEAKER_LINE_02 = "Audio/DIA/CH2/Sammy/FinaleMonologueSpeaker/DIA_Sammy_Finale_Speaker_Line_02";

			// Token: 0x04002247 RID: 8775
			public const string DIA_SAMMY_FINALE_SPEAKER_LINE_03 = "Audio/DIA/CH2/Sammy/FinaleMonologueSpeaker/DIA_Sammy_Finale_Speaker_Line_03";

			// Token: 0x04002248 RID: 8776
			public const string DIA_SAMMY_FINALE_SPEAKER_LINE_04 = "Audio/DIA/CH2/Sammy/FinaleMonologueSpeaker/DIA_Sammy_Finale_Speaker_Line_04";

			// Token: 0x04002249 RID: 8777
			public const string DIA_SAMMY_FINALE_SPEAKER_LINE_05 = "Audio/DIA/CH2/Sammy/FinaleMonologueSpeaker/DIA_Sammy_Finale_Speaker_Line_05";

			// Token: 0x0400224A RID: 8778
			public const string DIA_SAMMY_FINALE_SPEAKER_LINE_06 = "Audio/DIA/CH2/Sammy/FinaleMonologueSpeaker/DIA_Sammy_Finale_Speaker_Line_06";

			// Token: 0x0400224B RID: 8779
			public const string DIA_SAMMY_FINALE_SPEAKER_LINE_07 = "Audio/DIA/CH2/Sammy/FinaleMonologueSpeaker/DIA_Sammy_Finale_Speaker_Line_07";

			// Token: 0x0400224C RID: 8780
			public const string DIA_SAMMY_PUZZLE_DIARY_INTRO_01 = "Audio/DIA/CH2/Sammy/Puzzle/DIA_Sammy_Puzzle_Diary_Intro_01";

			// Token: 0x0400224D RID: 8781
			public const string DIA_SAMMY_PUZZLE_DIARY_OUTRO_01 = "Audio/DIA/CH2/Sammy/Puzzle/DIA_Sammy_Puzzle_Diary_Outro_01";

			// Token: 0x0400224E RID: 8782
			public const string DIA_SAMMY_PUZZLE_DIARY_BANJO_01 = "Audio/DIA/CH2/Sammy/Puzzle/Banjo/DIA_Sammy_Puzzle_Diary_Banjo_01";

			// Token: 0x0400224F RID: 8783
			public const string DIA_SAMMY_PUZZLE_DIARY_BANJO_02 = "Audio/DIA/CH2/Sammy/Puzzle/Banjo/DIA_Sammy_Puzzle_Diary_Banjo_02";

			// Token: 0x04002250 RID: 8784
			public const string DIA_SAMMY_PUZZLE_DIARY_BASS_01 = "Audio/DIA/CH2/Sammy/Puzzle/BassFiddle/DIA_Sammy_Puzzle_Diary_Bass_01";

			// Token: 0x04002251 RID: 8785
			public const string DIA_SAMMY_PUZZLE_DIARY_BASS_02 = "Audio/DIA/CH2/Sammy/Puzzle/BassFiddle/DIA_Sammy_Puzzle_Diary_Bass_02";

			// Token: 0x04002252 RID: 8786
			public const string DIA_SAMMY_PUZZLE_DIARY_DRUM_01 = "Audio/DIA/CH2/Sammy/Puzzle/Drum/DIA_Sammy_Puzzle_Diary_Drum_01";

			// Token: 0x04002253 RID: 8787
			public const string DIA_SAMMY_PUZZLE_DIARY_DRUM_02 = "Audio/DIA/CH2/Sammy/Puzzle/Drum/DIA_Sammy_Puzzle_Diary_Drum_02";

			// Token: 0x04002254 RID: 8788
			public const string DIA_SAMMY_PUZZLE_DIARY_PIANO_01 = "Audio/DIA/CH2/Sammy/Puzzle/Piano/DIA_Sammy_Puzzle_Diary_Piano_01";

			// Token: 0x04002255 RID: 8789
			public const string DIA_SAMMY_PUZZLE_DIARY_PIANO_02 = "Audio/DIA/CH2/Sammy/Puzzle/Piano/DIA_Sammy_Puzzle_Diary_Piano_02";

			// Token: 0x04002256 RID: 8790
			public const string DIA_SAMMY_PUZZLE_DIARY_VIOLIN_01 = "Audio/DIA/CH2/Sammy/Puzzle/Violin/DIA_Sammy_Puzzle_Diary_Violin_01";

			// Token: 0x04002257 RID: 8791
			public const string DIA_SAMMY_PUZZLE_DIARY_VIOLIN_02 = "Audio/DIA/CH2/Sammy/Puzzle/Violin/DIA_Sammy_Puzzle_Diary_Violin_02";

			// Token: 0x04002258 RID: 8792
			public const string CH_3ALICE_01LOBBYHUMMING = "Audio/DIA/CH3/Alice/ch3_alice_01_lobbyhumming";

			// Token: 0x04002259 RID: 8793
			public const string CH_3ALICE_22GEARMISSIONINTRO = "Audio/DIA/CH3/Alice/ch3_alice_22_gearmissionintro";

			// Token: 0x0400225A RID: 8794
			public const string CH_3ALICE_30SEARCHERMISSIONEND_A = "Audio/DIA/CH3/Alice/ch3_alice_30_searchermissionendA";

			// Token: 0x0400225B RID: 8795
			public const string CH_3ALICE_31SEARCHERMISSIONEND_B = "Audio/DIA/CH3/Alice/ch3_alice_31_searchermissionendB";

			// Token: 0x0400225C RID: 8796
			public const string CH_3ALICE_34VALVEMISSIONEND = "Audio/DIA/CH3/Alice/ch3_alice_34_valvemissionend";

			// Token: 0x0400225D RID: 8797
			public const string CH_3ALICE_43PROJECTIONISTMISSIONINTRO_E = "Audio/DIA/CH3/Alice/ch3_alice_43_projectionistmissionintroE";

			// Token: 0x0400225E RID: 8798
			public const string CH_3ALICE_44PROJECTIONISTMISSIONEND_A = "Audio/DIA/CH3/Alice/ch3_alice_44_projectionistmissionendA";

			// Token: 0x0400225F RID: 8799
			public const string CH_3ALICE_44SHHTHEREHEISTHEPROJECTIONIST = "Audio/DIA/CH3/Alice/ch3_alice_44_shhthereheistheprojectionist";

			// Token: 0x04002260 RID: 8800
			public const string CH_3ALICE_45BESURETOSTAYOUTOFHISLIGHT = "Audio/DIA/CH3/Alice/ch3_alice_45_besuretostayoutofhislight";

			// Token: 0x04002261 RID: 8801
			public const string CH_3ALICE_68ENEMYMISSIONEND_A = "Audio/DIA/CH3/Alice/ch3_alice_68_enemymissionendA";

			// Token: 0x04002262 RID: 8802
			public const string CH_3ALICE_79LETSBEGIN = "Audio/DIA/CH3/Alice/ch3_alice_79_letsbegin";

			// Token: 0x04002263 RID: 8803
			public const string CH_3ALICESPAWNRETURN = "Audio/DIA/CH3/Alice/ch3_alice_spawnreturn";

			// Token: 0x04002264 RID: 8804
			public const string DIACH_3_ALICEINKDEMON_01 = "Audio/DIA/CH3/Alice/InkDemon/DIA_CH3_ALICE_INK_DEMON_01";

			// Token: 0x04002265 RID: 8805
			public const string DIACH_3_ALICEINKDEMON_02 = "Audio/DIA/CH3/Alice/InkDemon/DIA_CH3_ALICE_INK_DEMON_02";

			// Token: 0x04002266 RID: 8806
			public const string DIACH_3_ALICEINKDEMON_03 = "Audio/DIA/CH3/Alice/InkDemon/DIA_CH3_ALICE_INK_DEMON_03";

			// Token: 0x04002267 RID: 8807
			public const string DIACH_3_ALICEBODIES_01 = "Audio/DIA/CH3/Alice/MonologueDeadBodies/DIA_CH3_ALICE_BODIES_01";

			// Token: 0x04002268 RID: 8808
			public const string DIACH_3_ALICEBODIES_02 = "Audio/DIA/CH3/Alice/MonologueDeadBodies/DIA_CH3_ALICE_BODIES_02";

			// Token: 0x04002269 RID: 8809
			public const string DIACH_3_ALICEBODIES_03 = "Audio/DIA/CH3/Alice/MonologueDeadBodies/DIA_CH3_ALICE_BODIES_03";

			// Token: 0x0400226A RID: 8810
			public const string DIACH_3_ALICEFINALMONOLOGUEA_01 = "Audio/DIA/CH3/Alice/MonologueFinaleA/DIA_CH3_ALICE_FINAL_MONOLOGUE_A_01";

			// Token: 0x0400226B RID: 8811
			public const string DIACH_3_ALICEFINALMONOLOGUEA_02 = "Audio/DIA/CH3/Alice/MonologueFinaleA/DIA_CH3_ALICE_FINAL_MONOLOGUE_A_02";

			// Token: 0x0400226C RID: 8812
			public const string DIACH_3_ALICEFINALMONOLOGUEA_03 = "Audio/DIA/CH3/Alice/MonologueFinaleA/DIA_CH3_ALICE_FINAL_MONOLOGUE_A_03";

			// Token: 0x0400226D RID: 8813
			public const string DIACH_3_ALICEFINALMONOLOGUEA_04 = "Audio/DIA/CH3/Alice/MonologueFinaleA/DIA_CH3_ALICE_FINAL_MONOLOGUE_A_04";

			// Token: 0x0400226E RID: 8814
			public const string DIACH_3_ALICEFINALMONOLOGUEA_05 = "Audio/DIA/CH3/Alice/MonologueFinaleA/DIA_CH3_ALICE_FINAL_MONOLOGUE_A_05";

			// Token: 0x0400226F RID: 8815
			public const string DIACH_3_ALICEFINALMONOLOGUEA_06 = "Audio/DIA/CH3/Alice/MonologueFinaleA/DIA_CH3_ALICE_FINAL_MONOLOGUE_A_06";

			// Token: 0x04002270 RID: 8816
			public const string DIACH_3_ALICEFINALMONOLOGUEB_01 = "Audio/DIA/CH3/Alice/MonologueFinaleB/DIA_CH3_ALICE_FINAL_MONOLOGUE_B_01";

			// Token: 0x04002271 RID: 8817
			public const string DIACH_3_ALICEFINALMONOLOGUEB_02 = "Audio/DIA/CH3/Alice/MonologueFinaleB/DIA_CH3_ALICE_FINAL_MONOLOGUE_B_02";

			// Token: 0x04002272 RID: 8818
			public const string DIACH_3_ALICEFINALMONOLOGUEB_03 = "Audio/DIA/CH3/Alice/MonologueFinaleB/DIA_CH3_ALICE_FINAL_MONOLOGUE_B_03";

			// Token: 0x04002273 RID: 8819
			public const string DIACH_3_ALICEFINALMONOLOGUEB_04 = "Audio/DIA/CH3/Alice/MonologueFinaleB/DIA_CH3_ALICE_FINAL_MONOLOGUE_B_04";

			// Token: 0x04002274 RID: 8820
			public const string DIACH_3_ALICEFINALMONOLOGUEB_05 = "Audio/DIA/CH3/Alice/MonologueFinaleB/DIA_CH3_ALICE_FINAL_MONOLOGUE_B_05";

			// Token: 0x04002275 RID: 8821
			public const string DIACH_3_ALICEFINALMONOLOGUEB_06 = "Audio/DIA/CH3/Alice/MonologueFinaleB/DIA_CH3_ALICE_FINAL_MONOLOGUE_B_06";

			// Token: 0x04002276 RID: 8822
			public const string DIACH_3_ALICEFINALMONOLOGUEB_07 = "Audio/DIA/CH3/Alice/MonologueFinaleB/DIA_CH3_ALICE_FINAL_MONOLOGUE_B_07";

			// Token: 0x04002277 RID: 8823
			public const string DIACH_3_ALICEFINALMONOLOGUEB_08 = "Audio/DIA/CH3/Alice/MonologueFinaleB/DIA_CH3_ALICE_FINAL_MONOLOGUE_B_08";

			// Token: 0x04002278 RID: 8824
			public const string DIACH_3_ALICEFINALMONOLOGUEC = "Audio/DIA/CH3/Alice/MonologueFinaleC/DIA_CH3_ALICE_FINAL_MONOLOGUE_C";

			// Token: 0x04002279 RID: 8825
			public const string DIACH_3_ALICELIFT_01 = "Audio/DIA/CH3/Alice/MonologueLift/DIA_CH3_ALICE_LIFT_01";

			// Token: 0x0400227A RID: 8826
			public const string DIACH_3_ALICELIFT_02 = "Audio/DIA/CH3/Alice/MonologueLift/DIA_CH3_ALICE_LIFT_02";

			// Token: 0x0400227B RID: 8827
			public const string DIACH_3_ALICELIFT_03 = "Audio/DIA/CH3/Alice/MonologueLift/DIA_CH3_ALICE_LIFT_03";

			// Token: 0x0400227C RID: 8828
			public const string DIACH_3_ALICELIFT_04 = "Audio/DIA/CH3/Alice/MonologueLift/DIA_CH3_ALICE_LIFT_04";

			// Token: 0x0400227D RID: 8829
			public const string DIACH_3_ALICELIFT_05 = "Audio/DIA/CH3/Alice/MonologueLift/DIA_CH3_ALICE_LIFT_05";

			// Token: 0x0400227E RID: 8830
			public const string DIACH_3_ALICELIFTEND_01 = "Audio/DIA/CH3/Alice/MonologueLiftExit/DIA_CH3_ALICE_LIFT_END_01";

			// Token: 0x0400227F RID: 8831
			public const string DIACH_3_ALICELIFTEND_02 = "Audio/DIA/CH3/Alice/MonologueLiftExit/DIA_CH3_ALICE_LIFT_END_02";

			// Token: 0x04002280 RID: 8832
			public const string DIACH_3_ALICEMONOLOGUE_01 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_01";

			// Token: 0x04002281 RID: 8833
			public const string DIACH_3_ALICEMONOLOGUE_02 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_02";

			// Token: 0x04002282 RID: 8834
			public const string DIACH_3_ALICEMONOLOGUE_03 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_03";

			// Token: 0x04002283 RID: 8835
			public const string DIACH_3_ALICEMONOLOGUE_04 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_04";

			// Token: 0x04002284 RID: 8836
			public const string DIACH_3_ALICEMONOLOGUE_05 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_05";

			// Token: 0x04002285 RID: 8837
			public const string DIACH_3_ALICEMONOLOGUE_06 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_06";

			// Token: 0x04002286 RID: 8838
			public const string DIACH_3_ALICEMONOLOGUE_07 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_07";

			// Token: 0x04002287 RID: 8839
			public const string DIACH_3_ALICEMONOLOGUE_08 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_08";

			// Token: 0x04002288 RID: 8840
			public const string DIACH_3_ALICEMONOLOGUE_09 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_09";

			// Token: 0x04002289 RID: 8841
			public const string DIACH_3_ALICEMONOLOGUE_10 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_10";

			// Token: 0x0400228A RID: 8842
			public const string DIACH_3_ALICEMONOLOGUE_11 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_11";

			// Token: 0x0400228B RID: 8843
			public const string DIACH_3_ALICEMONOLOGUE_12 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_12";

			// Token: 0x0400228C RID: 8844
			public const string DIACH_3_ALICEMONOLOGUE_13 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_13";

			// Token: 0x0400228D RID: 8845
			public const string DIACH_3_ALICEMONOLOGUE_14 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_14";

			// Token: 0x0400228E RID: 8846
			public const string DIACH_3_ALICEMONOLOGUE_15 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_15";

			// Token: 0x0400228F RID: 8847
			public const string DIACH_3_ALICEMONOLOGUE_16 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_16";

			// Token: 0x04002290 RID: 8848
			public const string DIACH_3_ALICEMONOLOGUE_17 = "Audio/DIA/CH3/Alice/MonologueMain/DIA_CH3_ALICE_MONOLOGUE_17";

			// Token: 0x04002291 RID: 8849
			public const string DIACH_3_ALICEREVEAL_01 = "Audio/DIA/CH3/Alice/MonologueReveal/DIA_CH3_ALICE_REVEAL_01";

			// Token: 0x04002292 RID: 8850
			public const string DIACH_3_ALICEREVEAL_02 = "Audio/DIA/CH3/Alice/MonologueReveal/DIA_CH3_ALICE_REVEAL_02";

			// Token: 0x04002293 RID: 8851
			public const string DIACH_3_ALICEREVEAL_03 = "Audio/DIA/CH3/Alice/MonologueReveal/DIA_CH3_ALICE_REVEAL_03";

			// Token: 0x04002294 RID: 8852
			public const string DIACH_3_ALICEBUTCHERGANGSTART_01 = "Audio/DIA/CH3/Alice/TaskButcherGangStart/DIA_CH3_ALICE_BUTCHER_GANG_START_01";

			// Token: 0x04002295 RID: 8853
			public const string DIACH_3_ALICEBUTCHERGANGSTART_02 = "Audio/DIA/CH3/Alice/TaskButcherGangStart/DIA_CH3_ALICE_BUTCHER_GANG_START_02";

			// Token: 0x04002296 RID: 8854
			public const string DIACH_3_ALICEBUTCHERGANGSTART_03 = "Audio/DIA/CH3/Alice/TaskButcherGangStart/DIA_CH3_ALICE_BUTCHER_GANG_START_03";

			// Token: 0x04002297 RID: 8855
			public const string DIACH_3_ALICECUTOUTEND_01 = "Audio/DIA/CH3/Alice/TaskCutoutEnd/DIA_CH3_ALICE_CUTOUT_END_01";

			// Token: 0x04002298 RID: 8856
			public const string DIACH_3_ALICECUTOUTEND_02 = "Audio/DIA/CH3/Alice/TaskCutoutEnd/DIA_CH3_ALICE_CUTOUT_END_02";

			// Token: 0x04002299 RID: 8857
			public const string DIACH_3_ALICETASKCUTOUTSSTART_01 = "Audio/DIA/CH3/Alice/TaskCutoutStart/DIA_CH3_ALICE_TASK_CUTOUTS_START_01";

			// Token: 0x0400229A RID: 8858
			public const string DIACH_3_ALICETASKCUTOUTSSTART_02 = "Audio/DIA/CH3/Alice/TaskCutoutStart/DIA_CH3_ALICE_TASK_CUTOUTS_START_02";

			// Token: 0x0400229B RID: 8859
			public const string DIACH_3_ALICETASKSGEARSLIFT_01 = "Audio/DIA/CH3/Alice/TaskGear/DIA_CH3_ALICE_TASKS_GEARS_LIFT_01";

			// Token: 0x0400229C RID: 8860
			public const string DIACH_3_ALICETASKSGEARSLIFT_02 = "Audio/DIA/CH3/Alice/TaskGear/DIA_CH3_ALICE_TASKS_GEARS_LIFT_02";

			// Token: 0x0400229D RID: 8861
			public const string DIACH_3_ALICETASKSGEAREND_01 = "Audio/DIA/CH3/Alice/TaskGearEnd/DIA_CH3_ALICE_TASKS_GEAR_END_01";

			// Token: 0x0400229E RID: 8862
			public const string DIACH_3_ALICETASKSGEAREND_02 = "Audio/DIA/CH3/Alice/TaskGearEnd/DIA_CH3_ALICE_TASKS_GEAR_END_02";

			// Token: 0x0400229F RID: 8863
			public const string DIACH_3_ALICETASKPROJ_01 = "Audio/DIA/CH3/Alice/TaskProjectionist/DIA_CH3_ALICE_TASK_PROJ_01";

			// Token: 0x040022A0 RID: 8864
			public const string DIACH_3_ALICETASKPROJ_02 = "Audio/DIA/CH3/Alice/TaskProjectionist/DIA_CH3_ALICE_TASK_PROJ_02";

			// Token: 0x040022A1 RID: 8865
			public const string DIACH_3_ALICETASKPROJ_03 = "Audio/DIA/CH3/Alice/TaskProjectionist/DIA_CH3_ALICE_TASK_PROJ_03";

			// Token: 0x040022A2 RID: 8866
			public const string DIACH_3_ALICETASKPROJ_04 = "Audio/DIA/CH3/Alice/TaskProjectionist/DIA_CH3_ALICE_TASK_PROJ_04";

			// Token: 0x040022A3 RID: 8867
			public const string DIACH_3_ALICETASKSBEGIN_01 = "Audio/DIA/CH3/Alice/TasksBegin/DIA_CH3_ALICE_TASKS_BEGIN_01";

			// Token: 0x040022A4 RID: 8868
			public const string DIACH_3_ALICETASKSBEGIN_02 = "Audio/DIA/CH3/Alice/TasksBegin/DIA_CH3_ALICE_TASKS_BEGIN_02";

			// Token: 0x040022A5 RID: 8869
			public const string DIACH_3_ALICETASKSBEGIN_03 = "Audio/DIA/CH3/Alice/TasksBegin/DIA_CH3_ALICE_TASKS_BEGIN_03";

			// Token: 0x040022A6 RID: 8870
			public const string DIACH_3_ALICETASKSBEGIN_04 = "Audio/DIA/CH3/Alice/TasksBegin/DIA_CH3_ALICE_TASKS_BEGIN_04";

			// Token: 0x040022A7 RID: 8871
			public const string DIACH_3_ALICETASKSBEGIN_05 = "Audio/DIA/CH3/Alice/TasksBegin/DIA_CH3_ALICE_TASKS_BEGIN_05";

			// Token: 0x040022A8 RID: 8872
			public const string DIACH_3_ALICETASKSBEGIN_06 = "Audio/DIA/CH3/Alice/TasksBegin/DIA_CH3_ALICE_TASKS_BEGIN_06";

			// Token: 0x040022A9 RID: 8873
			public const string DIACH_3_ALICETASKSBEGIN_07 = "Audio/DIA/CH3/Alice/TasksBegin/DIA_CH3_ALICE_TASKS_BEGIN_07";

			// Token: 0x040022AA RID: 8874
			public const string DIACH_3_ALICETASKSCOMPLETE_01 = "Audio/DIA/CH3/Alice/TasksComplete/DIA_CH3_ALICE_TASKS_COMPLETE_01";

			// Token: 0x040022AB RID: 8875
			public const string DIACH_3_ALICETASKSCOMPLETE_02 = "Audio/DIA/CH3/Alice/TasksComplete/DIA_CH3_ALICE_TASKS_COMPLETE_02";

			// Token: 0x040022AC RID: 8876
			public const string DIACH_3_ALICETASKSCOMPLETE_03 = "Audio/DIA/CH3/Alice/TasksComplete/DIA_CH3_ALICE_TASKS_COMPLETE_03";

			// Token: 0x040022AD RID: 8877
			public const string DIACH_3_ALICETASKSCOMPLETE_04 = "Audio/DIA/CH3/Alice/TasksComplete/DIA_CH3_ALICE_TASKS_COMPLETE_04";

			// Token: 0x040022AE RID: 8878
			public const string DIACH_3_ALICETASKSTHICKINKLIFT_01 = "Audio/DIA/CH3/Alice/TaskThickInk/DIA_CH3_ALICE_TASKS_THICK_INK_LIFT_01";

			// Token: 0x040022AF RID: 8879
			public const string DIACH_3_ALICETASKSTHICKINKLIFT_02 = "Audio/DIA/CH3/Alice/TaskThickInk/DIA_CH3_ALICE_TASKS_THICK_INK_LIFT_02";

			// Token: 0x040022B0 RID: 8880
			public const string DIACH_3_ALICETASKSTHICKINKLIFT_03 = "Audio/DIA/CH3/Alice/TaskThickInk/DIA_CH3_ALICE_TASKS_THICK_INK_LIFT_03";

			// Token: 0x040022B1 RID: 8881
			public const string DIACH_3_ALICETASKSTHICKINKSTART_01 = "Audio/DIA/CH3/Alice/TaskThickInkStart/DIA_CH3_ALICE_TASKS_THICK_INK_START_01";

			// Token: 0x040022B2 RID: 8882
			public const string DIACH_3_ALICETASKSTHICKINKSTART_02 = "Audio/DIA/CH3/Alice/TaskThickInkStart/DIA_CH3_ALICE_TASKS_THICK_INK_START_02";

			// Token: 0x040022B3 RID: 8883
			public const string DIACH_3_ALICETASKSTHICKINKSTART_03 = "Audio/DIA/CH3/Alice/TaskThickInkStart/DIA_CH3_ALICE_TASKS_THICK_INK_START_03";

			// Token: 0x040022B4 RID: 8884
			public const string DIACH_3_ALICETASKSTHICKINKSTART_04 = "Audio/DIA/CH3/Alice/TaskThickInkStart/DIA_CH3_ALICE_TASKS_THICK_INK_START_04";

			// Token: 0x040022B5 RID: 8885
			public const string DIACH_3_ALICETASKSTHICKINKSTART_05 = "Audio/DIA/CH3/Alice/TaskThickInkStart/DIA_CH3_ALICE_TASKS_THICK_INK_START_05";

			// Token: 0x040022B6 RID: 8886
			public const string DIACH_3_ALICETASKSVALVESLIFT_01 = "Audio/DIA/CH3/Alice/TaskValve/DIA_CH3_ALICE_TASKS_VALVES_LIFT_01";

			// Token: 0x040022B7 RID: 8887
			public const string DIACH_3_ALICETASKSVALVESLIFT_02 = "Audio/DIA/CH3/Alice/TaskValve/DIA_CH3_ALICE_TASKS_VALVES_LIFT_02";

			// Token: 0x040022B8 RID: 8888
			public const string DIACH_3_ALICETASKSVALVESLIFT_03 = "Audio/DIA/CH3/Alice/TaskValve/DIA_CH3_ALICE_TASKS_VALVES_LIFT_03";

			// Token: 0x040022B9 RID: 8889
			public const string DIACH_3_ALICETASKSVALVESSTART_01 = "Audio/DIA/CH3/Alice/TaskValveStart/DIA_CH3_ALICE_TASKS_VALVES_START_01";

			// Token: 0x040022BA RID: 8890
			public const string DIACH_3_ALICETASKSVALVESSTART_02 = "Audio/DIA/CH3/Alice/TaskValveStart/DIA_CH3_ALICE_TASKS_VALVES_START_02";

			// Token: 0x040022BB RID: 8891
			public const string CH_3_AUDIO_LOGGRANTTHEGENIUSUPSTAIRS = "Audio/DIA/CH3/AudioLogs/CH3_AudioLog_grant_thegeniusupstairs";

			// Token: 0x040022BC RID: 8892
			public const string CH_3_AUDIO_LOGHENRY = "Audio/DIA/CH3/AudioLogs/CH3_AudioLog_henry";

			// Token: 0x040022BD RID: 8893
			public const string CH_3_AUDIO_LOGJOEYDREWTIMETOBELIEVE = "Audio/DIA/CH3/AudioLogs/CH3_AudioLog_joeydrew_timetobelieve";

			// Token: 0x040022BE RID: 8894
			public const string CH_3_AUDIO_LOGNORMANLOOKINGFORTROUBLE = "Audio/DIA/CH3/AudioLogs/CH3_AudioLog_norman_lookingfortrouble";

			// Token: 0x040022BF RID: 8895
			public const string CH_3_AUDIO_LOGSHAWNCROOKEDSMILES = "Audio/DIA/CH3/AudioLogs/CH3_AudioLog_shawn_crookedsmiles";

			// Token: 0x040022C0 RID: 8896
			public const string CH_3_AUDIO_LOGSUSIEEVERYTHINGISCOMINGAPART = "Audio/DIA/CH3/AudioLogs/CH3_AudioLog_susie_everythingiscomingapart";

			// Token: 0x040022C1 RID: 8897
			public const string CH_3_AUDIO_LOGSUSIELUNCHWITHJOEY = "Audio/DIA/CH3/AudioLogs/CH3_AudioLog_susie_lunchwithjoey";

			// Token: 0x040022C2 RID: 8898
			public const string CH_3_AUDIO_LOG_THOMAS_CUTTING_CORNERS = "Audio/DIA/CH3/AudioLogs/CH3_AudioLog_Thomas_CuttingCorners";

			// Token: 0x040022C3 RID: 8899
			public const string CH_3_AUDIO_LOGWALLYCRACKASMILE = "Audio/DIA/CH3/AudioLogs/CH3_AudioLog_wally_crackasmile";

			// Token: 0x040022C4 RID: 8900
			public const string CH_3_AUDIO_LOG_WALLY_THOMAS = "Audio/DIA/CH3/AudioLogs/CH3_AudioLog_Wally_Thomas";

			// Token: 0x040022C5 RID: 8901
			public const string CH_3HENRY_05THATSHOULDBEENOUGH = "Audio/DIA/CH3/Henry/ch3_henry_05_thatshouldbeenough";

			// Token: 0x040022C6 RID: 8902
			public const string CH_3HENRY_06HEREYOUGO = "Audio/DIA/CH3/Henry/ch3_henry_06_hereyougo";

			// Token: 0x040022C7 RID: 8903
			public const string CH_3HENRY_07LETSSEEWHATSOUTTHERE = "Audio/DIA/CH3/Henry/ch3_henry_07_letsseewhatsoutthere";

			// Token: 0x040022C8 RID: 8904
			public const string CH_3HENRY_08LOOKSLIKEITSDARKUPAHEAD = "Audio/DIA/CH3/Henry/ch3_henry_08_lookslikeitsdarkupahead";

			// Token: 0x040022C9 RID: 8905
			public const string CH_3HENRY_13WOWIDONTREMEMBERANYOFTHIS = "Audio/DIA/CH3/Henry/ch3_henry_13_wowidontrememberanyofthis";

			// Token: 0x040022CA RID: 8906
			public const string CH_3HENRY_20TWOLEVERSATONCE = "Audio/DIA/CH3/Henry/ch3_henry_20_twoleversatonce";

			// Token: 0x040022CB RID: 8907
			public const string CH_3HENRY_21YOUGETTHISONEILLFINDTHEOTHER = "Audio/DIA/CH3/Henry/ch3_henry_21_yougetthisoneillfindtheother";

			// Token: 0x040022CC RID: 8908
			public const string CH_3HENRY_24THISWILLDO = "Audio/DIA/CH3/Henry/ch3_henry_24_thiswilldo";

			// Token: 0x040022CD RID: 8909
			public const string CH_3HENRY_25VALVEPUZZLEFALSE_A = "Audio/DIA/CH3/Henry/ch3_henry_25_valvepuzzle_falseA";

			// Token: 0x040022CE RID: 8910
			public const string CH_3HENRY_26VALVEPUZZLEFALSE_B = "Audio/DIA/CH3/Henry/ch3_henry_26_valvepuzzle_falseB";

			// Token: 0x040022CF RID: 8911
			public const string CH_3HENRY_27VALVEPUZZLETRUE_A = "Audio/DIA/CH3/Henry/ch3_henry_27_valvepuzzle_trueA";

			// Token: 0x040022D0 RID: 8912
			public const string CH_3HENRY_28VALVEPUZZLETRUE_B = "Audio/DIA/CH3/Henry/ch3_henry_28_valvepuzzle_trueB";

			// Token: 0x040022D1 RID: 8913
			public const string CH_3HENRY_29WHATTHEHECKWASTHAT = "Audio/DIA/CH3/Henry/ch3_henry_29_whattheheckwasthat";

			// Token: 0x040022D2 RID: 8914
			public const string CH_3HENRY_30DONTBESCAREDBORIS = "Audio/DIA/CH3/Henry/ch3_henry_30_dontbescaredboris";

			// Token: 0x040022D3 RID: 8915
			public const string DIACH_3_HENRYBLOCKINGTHEWAY_01 = "Audio/DIA/CH3/Henry/BlockingTheWay/DIA_CH3_HENRY_BLOCKING_THE_WAY_01";

			// Token: 0x040022D4 RID: 8916
			public const string DIACH_3_HENRYBLOCKINGTHEWAY_02 = "Audio/DIA/CH3/Henry/BlockingTheWay/DIA_CH3_HENRY_BLOCKING_THE_WAY_02";

			// Token: 0x040022D5 RID: 8917
			public const string DIACH_3_HENRYBORISSCARE_01 = "Audio/DIA/CH3/Henry/BorisScare/DIA_CH3_HENRY_BORIS_SCARE_01";

			// Token: 0x040022D6 RID: 8918
			public const string DIACH_3_HENRYBORISSCARE_02 = "Audio/DIA/CH3/Henry/BorisScare/DIA_CH3_HENRY_BORIS_SCARE_02";

			// Token: 0x040022D7 RID: 8919
			public const string DIACH_3_HENRYDEADEND_01 = "Audio/DIA/CH3/Henry/DeadEnd/DIA_CH3_HENRY_DEAD_END_01";

			// Token: 0x040022D8 RID: 8920
			public const string DIACH_3_HENRYDEADEND_02 = "Audio/DIA/CH3/Henry/DeadEnd/DIA_CH3_HENRY_DEAD_END_02";

			// Token: 0x040022D9 RID: 8921
			public const string DIACH_3_HENRYDIDYOUHEARTHAT_01 = "Audio/DIA/CH3/Henry/DidYouHearThat/DIA_CH3_HENRY_DID_YOU_HEAR_THAT_01";

			// Token: 0x040022DA RID: 8922
			public const string DIACH_3_HENRYDIDYOUHEARTHAT_02 = "Audio/DIA/CH3/Henry/DidYouHearThat/DIA_CH3_HENRY_DID_YOU_HEAR_THAT_02";

			// Token: 0x040022DB RID: 8923
			public const string DIACH_3_HENRYHEYBUDDY_01 = "Audio/DIA/CH3/Henry/HeyBuddy/DIA_CH3_HENRY_HEY_BUDDY_01";

			// Token: 0x040022DC RID: 8924
			public const string DIACH_3_HENRYHEYBUDDY_02 = "Audio/DIA/CH3/Henry/HeyBuddy/DIA_CH3_HENRY_HEY_BUDDY_02";

			// Token: 0x040022DD RID: 8925
			public const string DIACH_3_HENRYNOTGETTINGOUT_01 = "Audio/DIA/CH3/Henry/NotGettingOut/DIA_CH3_HENRY_NOT_GETTING_OUT_01";

			// Token: 0x040022DE RID: 8926
			public const string DIACH_3_HENRYNOTGETTINGOUT_02 = "Audio/DIA/CH3/Henry/NotGettingOut/DIA_CH3_HENRY_NOT_GETTING_OUT_02";

			// Token: 0x040022DF RID: 8927
			public const string DIACH_3_SAMMYSECRET_01 = "Audio/DIA/CH3/Sammy/DIA_CH3_SAMMY_SECRET_01";

			// Token: 0x040022E0 RID: 8928
			public const string DIACH_4_ALICEDEATH = "Audio/DIA/CH4/Alice/DIA_CH4_ALICE_DEATH";

			// Token: 0x040022E1 RID: 8929
			public const string DIACH_4_ALICEHAVINGFUN = "Audio/DIA/CH4/Alice/DIA_CH4_ALICE_HAVING_FUN";

			// Token: 0x040022E2 RID: 8930
			public const string DIACH_4_ALICEBORISREVEAL_01 = "Audio/DIA/CH4/Alice/BorisReveal/DIA_CH4_ALICE_BORIS_REVEAL_01";

			// Token: 0x040022E3 RID: 8931
			public const string DIACH_4_ALICEBORISREVEAL_02 = "Audio/DIA/CH4/Alice/BorisReveal/DIA_CH4_ALICE_BORIS_REVEAL_02";

			// Token: 0x040022E4 RID: 8932
			public const string DIACH_4_ALICEBORISREVEAL_03 = "Audio/DIA/CH4/Alice/BorisReveal/DIA_CH4_ALICE_BORIS_REVEAL_03";

			// Token: 0x040022E5 RID: 8933
			public const string DIACH_4_ALICEBORISREVEAL_04 = "Audio/DIA/CH4/Alice/BorisReveal/DIA_CH4_ALICE_BORIS_REVEAL_04";

			// Token: 0x040022E6 RID: 8934
			public const string DIACH_4_ALICEBORISREVEAL_05 = "Audio/DIA/CH4/Alice/BorisReveal/DIA_CH4_ALICE_BORIS_REVEAL_05";

			// Token: 0x040022E7 RID: 8935
			public const string DIACH_4_ALICEFINALE_01 = "Audio/DIA/CH4/Alice/Finale/DIA_CH4_ALICE_FINALE_01";

			// Token: 0x040022E8 RID: 8936
			public const string DIACH_4_ALICEFINALE_02 = "Audio/DIA/CH4/Alice/Finale/DIA_CH4_ALICE_FINALE_02";

			// Token: 0x040022E9 RID: 8937
			public const string DIACH_4_ALICEHAUNTEDHOUSERIDE_01 = "Audio/DIA/CH4/Alice/HauntedHouse/Ride/DIA_CH4_ALICE_HAUNTED_HOUSE_RIDE_01";

			// Token: 0x040022EA RID: 8938
			public const string DIACH_4_ALICEHAUNTEDHOUSERIDE_02 = "Audio/DIA/CH4/Alice/HauntedHouse/Ride/DIA_CH4_ALICE_HAUNTED_HOUSE_RIDE_02";

			// Token: 0x040022EB RID: 8939
			public const string DIACH_4_ALICEHAUNTEDHOUSERIDE_03 = "Audio/DIA/CH4/Alice/HauntedHouse/Ride/DIA_CH4_ALICE_HAUNTED_HOUSE_RIDE_03";

			// Token: 0x040022EC RID: 8940
			public const string DIACH_4_ALICEHAUNTEDHOUSERIDE_04 = "Audio/DIA/CH4/Alice/HauntedHouse/Ride/DIA_CH4_ALICE_HAUNTED_HOUSE_RIDE_04";

			// Token: 0x040022ED RID: 8941
			public const string DIACH_4_ALICEHAUNTEDHOUSERIDE_05 = "Audio/DIA/CH4/Alice/HauntedHouse/Ride/DIA_CH4_ALICE_HAUNTED_HOUSE_RIDE_05";

			// Token: 0x040022EE RID: 8942
			public const string DIACH_4_ALICEHAUNTEDHOUSERIDE_06 = "Audio/DIA/CH4/Alice/HauntedHouse/Ride/DIA_CH4_ALICE_HAUNTED_HOUSE_RIDE_06";

			// Token: 0x040022EF RID: 8943
			public const string DIACH_4_ALICEHAUNTEDHOUSERIDE_07 = "Audio/DIA/CH4/Alice/HauntedHouse/Ride/DIA_CH4_ALICE_HAUNTED_HOUSE_RIDE_07";

			// Token: 0x040022F0 RID: 8944
			public const string DIACH_4_ALICEHAUNTEDHOUSERIDE_08 = "Audio/DIA/CH4/Alice/HauntedHouse/Ride/DIA_CH4_ALICE_HAUNTED_HOUSE_RIDE_08";

			// Token: 0x040022F1 RID: 8945
			public const string DIACH_4_ALICEHAUNTEDHOUSESTART_01 = "Audio/DIA/CH4/Alice/HauntedHouse/Start/DIA_CH4_ALICE_HAUNTED_HOUSE_START_01";

			// Token: 0x040022F2 RID: 8946
			public const string DIACH_4_ALICEHAUNTEDHOUSESTART_02 = "Audio/DIA/CH4/Alice/HauntedHouse/Start/DIA_CH4_ALICE_HAUNTED_HOUSE_START_02";

			// Token: 0x040022F3 RID: 8947
			public const string DIACH_4_ALICESPIRALSTAIRS_01 = "Audio/DIA/CH4/Alice/SpiralStairs/DIA_CH4_ALICE_SPIRAL_STAIRS_01";

			// Token: 0x040022F4 RID: 8948
			public const string DIACH_4_ALICESPIRALSTAIRS_02 = "Audio/DIA/CH4/Alice/SpiralStairs/DIA_CH4_ALICE_SPIRAL_STAIRS_02";

			// Token: 0x040022F5 RID: 8949
			public const string DIACH_4_ALICESPIRALSTAIRS_03 = "Audio/DIA/CH4/Alice/SpiralStairs/DIA_CH4_ALICE_SPIRAL_STAIRS_03";

			// Token: 0x040022F6 RID: 8950
			public const string DIACH_4_ALICESPIRALSTAIRS_04 = "Audio/DIA/CH4/Alice/SpiralStairs/DIA_CH4_ALICE_SPIRAL_STAIRS_04";

			// Token: 0x040022F7 RID: 8951
			public const string DIACH_4_ALICESPIRALSTAIRS_05 = "Audio/DIA/CH4/Alice/SpiralStairs/DIA_CH4_ALICE_SPIRAL_STAIRS_05";

			// Token: 0x040022F8 RID: 8952
			public const string DIACH_4_ALICESPIRALSTAIRS_06 = "Audio/DIA/CH4/Alice/SpiralStairs/DIA_CH4_ALICE_SPIRAL_STAIRS_06";

			// Token: 0x040022F9 RID: 8953
			public const string CH_4AUDIOLOGBERT = "Audio/DIA/CH4/AudioLogs/ch4_audiolog_bert";

			// Token: 0x040022FA RID: 8954
			public const string CH_4AUDIOLOGJOEY = "Audio/DIA/CH4/AudioLogs/ch4_audiolog_joey";

			// Token: 0x040022FB RID: 8955
			public const string CH_4AUDIOLOGLACIE = "Audio/DIA/CH4/AudioLogs/ch4_audiolog_lacie";

			// Token: 0x040022FC RID: 8956
			public const string CH_4AUDIOLOGSUSIE = "Audio/DIA/CH4/AudioLogs/ch4_audiolog_susie";

			// Token: 0x040022FD RID: 8957
			public const string CH_4AUDIOLOGWALLY = "Audio/DIA/CH4/AudioLogs/ch4_audiolog_wally";

			// Token: 0x040022FE RID: 8958
			public const string DIACH_4_BERTREVEAL_01 = "Audio/DIA/CH4/Bert/Boss/DIA_CH4_BERT_REVEAL_01";

			// Token: 0x040022FF RID: 8959
			public const string DIACH_4_BERTREVEAL_02 = "Audio/DIA/CH4/Bert/Boss/DIA_CH4_BERT_REVEAL_02";

			// Token: 0x04002300 RID: 8960
			public const string DIACH_4_BERTREVEAL_03 = "Audio/DIA/CH4/Bert/Boss/DIA_CH4_BERT_REVEAL_03";

			// Token: 0x04002301 RID: 8961
			public const string DIACH_4_BERTREVEAL_04 = "Audio/DIA/CH4/Bert/Boss/DIA_CH4_BERT_REVEAL_04";

			// Token: 0x04002302 RID: 8962
			public const string DIACH_4_BERTREVEAL_05 = "Audio/DIA/CH4/Bert/Boss/DIA_CH4_BERT_REVEAL_05";

			// Token: 0x04002303 RID: 8963
			public const string DIACH_4_BERTREVEAL_06 = "Audio/DIA/CH4/Bert/Boss/DIA_CH4_BERT_REVEAL_06";

			// Token: 0x04002304 RID: 8964
			public const string DIACH_4_BERTREVEAL_07 = "Audio/DIA/CH4/Bert/Boss/DIA_CH4_BERT_REVEAL_07";

			// Token: 0x04002305 RID: 8965
			public const string DIACH_4_BERTREVEAL_08 = "Audio/DIA/CH4/Bert/Boss/DIA_CH4_BERT_REVEAL_08";

			// Token: 0x04002306 RID: 8966
			public const string DIACH_4_BERTREVEAL_09 = "Audio/DIA/CH4/Bert/Boss/DIA_CH4_BERT_REVEAL_09";

			// Token: 0x04002307 RID: 8967
			public const string DIACH_4_BERTREVEAL_10 = "Audio/DIA/CH4/Bert/Boss/DIA_CH4_BERT_REVEAL_10";

			// Token: 0x04002308 RID: 8968
			public const string DIACH_4_HENRY_01 = "Audio/DIA/CH4/Henry/DIA_CH4_HENRY_01";

			// Token: 0x04002309 RID: 8969
			public const string DIACH_4_HENRY_02 = "Audio/DIA/CH4/Henry/DIA_CH4_HENRY_02";

			// Token: 0x0400230A RID: 8970
			public const string DIACH_4_HENRY_03 = "Audio/DIA/CH4/Henry/DIA_CH4_HENRY_03";

			// Token: 0x0400230B RID: 8971
			public const string DIACH_4_HENRY_04 = "Audio/DIA/CH4/Henry/DIA_CH4_HENRY_04";

			// Token: 0x0400230C RID: 8972
			public const string DIACH_4_HENRY_05 = "Audio/DIA/CH4/Henry/DIA_CH4_HENRY_05";

			// Token: 0x0400230D RID: 8973
			public const string DIACH_4_HENRY_06 = "Audio/DIA/CH4/Henry/DIA_CH4_HENRY_06";

			// Token: 0x0400230E RID: 8974
			public const string DIACH_4_HENRY_07 = "Audio/DIA/CH4/Henry/DIA_CH4_HENRY_07";

			// Token: 0x0400230F RID: 8975
			public const string DIACH_4_HENRY_08 = "Audio/DIA/CH4/Henry/DIA_CH4_HENRY_08";

			// Token: 0x04002310 RID: 8976
			public const string DIACH_4_HENRYHAUNTEDHOUSE_01 = "Audio/DIA/CH4/Henry/HauntedHouse/DIA_CH4_HENRY_HAUNTED_HOUSE_01";

			// Token: 0x04002311 RID: 8977
			public const string DIACH_4_HENRYHAUNTEDHOUSE_02 = "Audio/DIA/CH4/Henry/HauntedHouse/DIA_CH4_HENRY_HAUNTED_HOUSE_02";

			// Token: 0x04002312 RID: 8978
			public const string DIACH_4_HENRYRESEARCH_01 = "Audio/DIA/CH4/Henry/Research/DIA_CH4_HENRY_RESEARCH_01";

			// Token: 0x04002313 RID: 8979
			public const string DIACH_4_HENRYRESEARCH_02 = "Audio/DIA/CH4/Henry/Research/DIA_CH4_HENRY_RESEARCH_02";

			// Token: 0x04002314 RID: 8980
			public const string AD_2 = "Audio/DIA/CH5/ad2";

			// Token: 0x04002315 RID: 8981
			public const string DIACH_5_HENRY_IM_HERE = "Audio/DIA/CH5/DIA_CH5_HenryImHere";

			// Token: 0x04002316 RID: 8982
			public const string DIACH_5_ALICEAHENRY = "Audio/DIA/CH5/AliceA/DIA_CH5_ALICEA_HENRY";

			// Token: 0x04002317 RID: 8983
			public const string DIACH_5_ALICEAQUIET = "Audio/DIA/CH5/AliceA/DIA_CH5_ALICEA_QUIET";

			// Token: 0x04002318 RID: 8984
			public const string DIACH_5_ALICEABATTLE_01 = "Audio/DIA/CH5/AliceA/Battle/DIA_CH5_ALICEA_BATTLE_01";

			// Token: 0x04002319 RID: 8985
			public const string DIACH_5_ALICEABATTLE_02 = "Audio/DIA/CH5/AliceA/Battle/DIA_CH5_ALICEA_BATTLE_02";

			// Token: 0x0400231A RID: 8986
			public const string DIACH_5_ALICEABATTLE_03 = "Audio/DIA/CH5/AliceA/Battle/DIA_CH5_ALICEA_BATTLE_03";

			// Token: 0x0400231B RID: 8987
			public const string DIACH_5_ALICEABATTLE_04 = "Audio/DIA/CH5/AliceA/Battle/DIA_CH5_ALICEA_BATTLE_04";

			// Token: 0x0400231C RID: 8988
			public const string DIACH_5_BATTLE_ENDING_01 = "Audio/DIA/CH5/AliceA/BattleEnding/DIA_CH5_Battle_Ending_01";

			// Token: 0x0400231D RID: 8989
			public const string DIACH_5_BATTLE_ENDING_02 = "Audio/DIA/CH5/AliceA/BattleEnding/DIA_CH5_Battle_Ending_02";

			// Token: 0x0400231E RID: 8990
			public const string DIACH_5_BATTLE_ENDING_03 = "Audio/DIA/CH5/AliceA/BattleEnding/DIA_CH5_Battle_Ending_03";

			// Token: 0x0400231F RID: 8991
			public const string DIACH_5_BATTLE_ENDING_04 = "Audio/DIA/CH5/AliceA/BattleEnding/DIA_CH5_Battle_Ending_04";

			// Token: 0x04002320 RID: 8992
			public const string DIACH_5_BATTLE_INTRO_01 = "Audio/DIA/CH5/AliceA/BattleIntro/DIA_CH5_Battle_Intro_01";

			// Token: 0x04002321 RID: 8993
			public const string DIACH_5_BATTLE_INTRO_02 = "Audio/DIA/CH5/AliceA/BattleIntro/DIA_CH5_Battle_Intro_02";

			// Token: 0x04002322 RID: 8994
			public const string DIACH_5_BATTLE_INTRO_03 = "Audio/DIA/CH5/AliceA/BattleIntro/DIA_CH5_Battle_Intro_03";

			// Token: 0x04002323 RID: 8995
			public const string DIACH_5_BATTLE_INTRO_04 = "Audio/DIA/CH5/AliceA/BattleIntro/DIA_CH5_Battle_Intro_04";

			// Token: 0x04002324 RID: 8996
			public const string DIACH_5_BATTLE_INTRO_05 = "Audio/DIA/CH5/AliceA/BattleIntro/DIA_CH5_Battle_Intro_05";

			// Token: 0x04002325 RID: 8997
			public const string DIACH_5_BATTLE_INTRO_06 = "Audio/DIA/CH5/AliceA/BattleIntro/DIA_CH5_Battle_Intro_06";

			// Token: 0x04002326 RID: 8998
			public const string DIACH_5_BATTLE_INTRO_07 = "Audio/DIA/CH5/AliceA/BattleIntro/DIA_CH5_Battle_Intro_07";

			// Token: 0x04002327 RID: 8999
			public const string DIACH_5_GIANT_INK_MACHINE_01 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_01";

			// Token: 0x04002328 RID: 9000
			public const string DIACH_5_GIANT_INK_MACHINE_02 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_02";

			// Token: 0x04002329 RID: 9001
			public const string DIACH_5_GIANT_INK_MACHINE_03 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_03";

			// Token: 0x0400232A RID: 9002
			public const string DIACH_5_GIANT_INK_MACHINE_04 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_04";

			// Token: 0x0400232B RID: 9003
			public const string DIACH_5_GIANT_INK_MACHINE_05 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_05";

			// Token: 0x0400232C RID: 9004
			public const string DIACH_5_GIANT_INK_MACHINE_06 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_06";

			// Token: 0x0400232D RID: 9005
			public const string DIACH_5_GIANT_INK_MACHINE_07 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_07";

			// Token: 0x0400232E RID: 9006
			public const string DIACH_5_GIANT_INK_MACHINE_08 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_08";

			// Token: 0x0400232F RID: 9007
			public const string DIACH_5_GIANT_INK_MACHINE_09 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_09";

			// Token: 0x04002330 RID: 9008
			public const string DIACH_5_GIANT_INK_MACHINE_10 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_10";

			// Token: 0x04002331 RID: 9009
			public const string DIACH_5_GIANT_INK_MACHINE_11 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_11";

			// Token: 0x04002332 RID: 9010
			public const string DIACH_5_GIANT_INK_MACHINE_12 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_12";

			// Token: 0x04002333 RID: 9011
			public const string DIACH_5_GIANT_INK_MACHINE_13 = "Audio/DIA/CH5/AliceA/GiantInkMachine/DIA_CH5_GiantInkMachine_13";

			// Token: 0x04002334 RID: 9012
			public const string DIACH_5_VAULT_01 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_01";

			// Token: 0x04002335 RID: 9013
			public const string DIACH_5_VAULT_02 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_02";

			// Token: 0x04002336 RID: 9014
			public const string DIACH_5_VAULT_03 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_03";

			// Token: 0x04002337 RID: 9015
			public const string DIACH_5_VAULT_04 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_04";

			// Token: 0x04002338 RID: 9016
			public const string DIACH_5_VAULT_05 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_05";

			// Token: 0x04002339 RID: 9017
			public const string DIACH_5_VAULT_06 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_06";

			// Token: 0x0400233A RID: 9018
			public const string DIACH_5_VAULT_07 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_07";

			// Token: 0x0400233B RID: 9019
			public const string DIACH_5_VAULT_08 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_08";

			// Token: 0x0400233C RID: 9020
			public const string DIACH_5_VAULT_09 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_09";

			// Token: 0x0400233D RID: 9021
			public const string DIACH_5_VAULT_10 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_10";

			// Token: 0x0400233E RID: 9022
			public const string DIACH_5_VAULT_11 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_11";

			// Token: 0x0400233F RID: 9023
			public const string DIACH_5_VAULT_12 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_12";

			// Token: 0x04002340 RID: 9024
			public const string DIACH_5_VAULT_13 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_13";

			// Token: 0x04002341 RID: 9025
			public const string DIACH_5_VAULT_14 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_14";

			// Token: 0x04002342 RID: 9026
			public const string DIACH_5_VAULT_15 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_15";

			// Token: 0x04002343 RID: 9027
			public const string DIACH_5_VAULT_16 = "Audio/DIA/CH5/AliceA/Vault/DIA_CH5_Vault_16";

			// Token: 0x04002344 RID: 9028
			public const string CH_5AUDIOLOGJOEYDREW_01 = "Audio/DIA/CH5/AudioLogs/ch5_audiolog_joeydrew01";

			// Token: 0x04002345 RID: 9029
			public const string CH_5AUDIOLOGJOEYDREW_02 = "Audio/DIA/CH5/AudioLogs/ch5_audiolog_joeydrew02";

			// Token: 0x04002346 RID: 9030
			public const string CH_5AUDIOLOGJOEYDREW_03 = "Audio/DIA/CH5/AudioLogs/ch5_audiolog_joeydrew03";

			// Token: 0x04002347 RID: 9031
			public const string CH_5AUDIOLOGTHOMASCONNOR = "Audio/DIA/CH5/AudioLogs/ch5_audiolog_thomasconnor";

			// Token: 0x04002348 RID: 9032
			public const string CH_5AUDIOLOGWALLYFRANKS = "Audio/DIA/CH5/AudioLogs/ch5_audiolog_wallyfranks";

			// Token: 0x04002349 RID: 9033
			public const string DIACH_5_HENRYJOEY = "Audio/DIA/CH5/Henry/DIA_CH5_HENRY_JOEY";

			// Token: 0x0400234A RID: 9034
			public const string DIACH_5HENRYNOTTHESEGUYSAGAINIBETTERSTAYOUTOFSIGHT = "Audio/DIA/CH5/Henry/DIA_CH5_henry_nottheseguysagainibetterstayoutofsight";

			// Token: 0x0400234B RID: 9035
			public const string DIACH_5HENRYNOWTHATSINTERESTING = "Audio/DIA/CH5/Henry/DIA_CH5_henry_nowthatsinteresting";

			// Token: 0x0400234C RID: 9036
			public const string DIACH_5HENRYSOUNDSLIKESOMETHINGISSTUCKINTHEPADDLWHEEL = "Audio/DIA/CH5/Henry/DIA_CH5_henry_soundslikesomethingisstuckinthepaddlwheel";

			// Token: 0x0400234D RID: 9037
			public const string DIACH_5HENRYTHEYCOULDHAVEATLEASTGIVENMEAWEAPON = "Audio/DIA/CH5/Henry/DIA_CH5_henry_theycouldhaveatleastgivenmeaweapon";

			// Token: 0x0400234E RID: 9038
			public const string DIACH_5_HENRYTHEEND = "Audio/DIA/CH5/Henry/DIA_CH5_HENRY_THE_END";

			// Token: 0x0400234F RID: 9039
			public const string DIACH_5_JOEYEND_01 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_01";

			// Token: 0x04002350 RID: 9040
			public const string DIACH_5_JOEYEND_02 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_02";

			// Token: 0x04002351 RID: 9041
			public const string DIACH_5_JOEYEND_03 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_03";

			// Token: 0x04002352 RID: 9042
			public const string DIACH_5_JOEYEND_04 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_04";

			// Token: 0x04002353 RID: 9043
			public const string DIACH_5_JOEYEND_05 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_05";

			// Token: 0x04002354 RID: 9044
			public const string DIACH_5_JOEYEND_06 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_06";

			// Token: 0x04002355 RID: 9045
			public const string DIACH_5_JOEYEND_07 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_07";

			// Token: 0x04002356 RID: 9046
			public const string DIACH_5_JOEYEND_08 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_08";

			// Token: 0x04002357 RID: 9047
			public const string DIACH_5_JOEYEND_09 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_09";

			// Token: 0x04002358 RID: 9048
			public const string DIACH_5_JOEYEND_10 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_10";

			// Token: 0x04002359 RID: 9049
			public const string DIACH_5_JOEYEND_11 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_11";

			// Token: 0x0400235A RID: 9050
			public const string DIACH_5_JOEYEND_12 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_12";

			// Token: 0x0400235B RID: 9051
			public const string DIACH_5_JOEYEND_13 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_13";

			// Token: 0x0400235C RID: 9052
			public const string DIACH_5_JOEYEND_14 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_14";

			// Token: 0x0400235D RID: 9053
			public const string DIACH_5_JOEYEND_15 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_15";

			// Token: 0x0400235E RID: 9054
			public const string DIACH_5_JOEYEND_16 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_16";

			// Token: 0x0400235F RID: 9055
			public const string DIACH_5_JOEYEND_17 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_17";

			// Token: 0x04002360 RID: 9056
			public const string DIACH_5_JOEYEND_18 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_18";

			// Token: 0x04002361 RID: 9057
			public const string DIACH_5_JOEYEND_19 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_19";

			// Token: 0x04002362 RID: 9058
			public const string DIACH_5_JOEYEND_20 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_20";

			// Token: 0x04002363 RID: 9059
			public const string DIACH_5_JOEYEND_21 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_21";

			// Token: 0x04002364 RID: 9060
			public const string DIACH_5_JOEYEND_22 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_22";

			// Token: 0x04002365 RID: 9061
			public const string DIACH_5_JOEYEND_23 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_23";

			// Token: 0x04002366 RID: 9062
			public const string DIACH_5_JOEYEND_24 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_24";

			// Token: 0x04002367 RID: 9063
			public const string DIACH_5_JOEYEND_25 = "Audio/DIA/CH5/Joey/DIA_CH5_JOEY_END_25";

			// Token: 0x04002368 RID: 9064
			public const string JOEY_THRONE_ROOM_AUDIO_LOG_01 = "Audio/DIA/CH5/JoeyAudioLog/JoeyThroneRoomAudioLog01";

			// Token: 0x04002369 RID: 9065
			public const string JOEY_THRONE_ROOM_AUDIO_LOG_02 = "Audio/DIA/CH5/JoeyAudioLog/JoeyThroneRoomAudioLog02";

			// Token: 0x0400236A RID: 9066
			public const string JOEY_THRONE_ROOM_AUDIO_LOG_03 = "Audio/DIA/CH5/JoeyAudioLog/JoeyThroneRoomAudioLog03";

			// Token: 0x0400236B RID: 9067
			public const string JOEY_THRONE_ROOM_AUDIO_LOG_04 = "Audio/DIA/CH5/JoeyAudioLog/JoeyThroneRoomAudioLog04";

			// Token: 0x0400236C RID: 9068
			public const string JOEY_THRONE_ROOM_AUDIO_LOG_05 = "Audio/DIA/CH5/JoeyAudioLog/JoeyThroneRoomAudioLog05";

			// Token: 0x0400236D RID: 9069
			public const string JOEY_THRONE_ROOM_AUDIO_LOG_06 = "Audio/DIA/CH5/JoeyAudioLog/JoeyThroneRoomAudioLog06";

			// Token: 0x0400236E RID: 9070
			public const string JOEY_THRONE_ROOM_AUDIO_LOG_07 = "Audio/DIA/CH5/JoeyAudioLog/JoeyThroneRoomAudioLog07";

			// Token: 0x0400236F RID: 9071
			public const string JOEY_THRONE_ROOM_AUDIO_LOG_08 = "Audio/DIA/CH5/JoeyAudioLog/JoeyThroneRoomAudioLog08";

			// Token: 0x04002370 RID: 9072
			public const string JOEY_THRONE_ROOM_AUDIO_LOG_09 = "Audio/DIA/CH5/JoeyAudioLog/JoeyThroneRoomAudioLog09";

			// Token: 0x04002371 RID: 9073
			public const string JOEY_THRONE_ROOM_AUDIO_LOG_10 = "Audio/DIA/CH5/JoeyAudioLog/JoeyThroneRoomAudioLog10";

			// Token: 0x04002372 RID: 9074
			public const string JOEY_THRONE_ROOM_AUDIO_LOG_11 = "Audio/DIA/CH5/JoeyAudioLog/JoeyThroneRoomAudioLog11";

			// Token: 0x04002373 RID: 9075
			public const string DIACH_5_OPENING_SCENE_0101 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_01";

			// Token: 0x04002374 RID: 9076
			public const string DIACH_5_OPENING_SCENE_0102 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_02";

			// Token: 0x04002375 RID: 9077
			public const string DIACH_5_OPENING_SCENE_0103 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_03";

			// Token: 0x04002376 RID: 9078
			public const string DIACH_5_OPENING_SCENE_0104 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_04";

			// Token: 0x04002377 RID: 9079
			public const string DIACH_5_OPENING_SCENE_0105 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_05";

			// Token: 0x04002378 RID: 9080
			public const string DIACH_5_OPENING_SCENE_0106 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_06";

			// Token: 0x04002379 RID: 9081
			public const string DIACH_5_OPENING_SCENE_0107 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_07";

			// Token: 0x0400237A RID: 9082
			public const string DIACH_5_OPENING_SCENE_0108 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_08";

			// Token: 0x0400237B RID: 9083
			public const string DIACH_5_OPENING_SCENE_0109 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_09";

			// Token: 0x0400237C RID: 9084
			public const string DIACH_5_OPENING_SCENE_0110 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_10";

			// Token: 0x0400237D RID: 9085
			public const string DIACH_5_OPENING_SCENE_0111 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_11";

			// Token: 0x0400237E RID: 9086
			public const string DIACH_5_OPENING_SCENE_0112 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_12";

			// Token: 0x0400237F RID: 9087
			public const string DIACH_5_OPENING_SCENE_0113 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_13";

			// Token: 0x04002380 RID: 9088
			public const string DIACH_5_OPENING_SCENE_0114 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_14";

			// Token: 0x04002381 RID: 9089
			public const string DIACH_5_OPENING_SCENE_0115 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_15";

			// Token: 0x04002382 RID: 9090
			public const string DIACH_5_OPENING_SCENE_0116 = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_16";

			// Token: 0x04002383 RID: 9091
			public const string DIACH_5_OPENING_SCENE_0117B = "Audio/DIA/CH5/Opening/Scene1/DIA_CH5_Opening_Scene_01_17b";

			// Token: 0x04002384 RID: 9092
			public const string DIACH_5_OPENING_SCENE_0201 = "Audio/DIA/CH5/Opening/Scene2/DIA_CH5_Opening_Scene_02_01";

			// Token: 0x04002385 RID: 9093
			public const string DIACH_5_OPENING_SCENE_0202 = "Audio/DIA/CH5/Opening/Scene2/DIA_CH5_Opening_Scene_02_02";

			// Token: 0x04002386 RID: 9094
			public const string DIACH_5_OPENING_SCENE_0203 = "Audio/DIA/CH5/Opening/Scene2/DIA_CH5_Opening_Scene_02_03";

			// Token: 0x04002387 RID: 9095
			public const string DIACH_5_OPENING_SCENE_0204 = "Audio/DIA/CH5/Opening/Scene2/DIA_CH5_Opening_Scene_02_04";

			// Token: 0x04002388 RID: 9096
			public const string DIACH_5_OPENING_SCENE_0205B = "Audio/DIA/CH5/Opening/Scene2/DIA_CH5_Opening_Scene_02_05b";

			// Token: 0x04002389 RID: 9097
			public const string DIACH_5_OPENING_SCENE_0206 = "Audio/DIA/CH5/Opening/Scene2/DIA_CH5_Opening_Scene_02_06";

			// Token: 0x0400238A RID: 9098
			public const string DIACH_5_OPENING_SCENE_0401 = "Audio/DIA/CH5/Opening/Scene4/DIA_CH5_Opening_Scene_04_01";

			// Token: 0x0400238B RID: 9099
			public const string DIACH_5_OPENING_SCENE_0402 = "Audio/DIA/CH5/Opening/Scene4/DIA_CH5_Opening_Scene_04_02";

			// Token: 0x0400238C RID: 9100
			public const string DIACH_5_OPENING_SCENE_0403 = "Audio/DIA/CH5/Opening/Scene4/DIA_CH5_Opening_Scene_04_03";

			// Token: 0x0400238D RID: 9101
			public const string DIACH_5_OPENING_SCENE_0404B = "Audio/DIA/CH5/Opening/Scene4/DIA_CH5_Opening_Scene_04_04b";

			// Token: 0x0400238E RID: 9102
			public const string DIACH_5_OPENING_SCENE_0405 = "Audio/DIA/CH5/Opening/Scene4/DIA_CH5_Opening_Scene_04_05";

			// Token: 0x0400238F RID: 9103
			public const string DIACH_5_OPENING_SCENE_0501 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_01";

			// Token: 0x04002390 RID: 9104
			public const string DIACH_5_OPENING_SCENE_0502 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_02";

			// Token: 0x04002391 RID: 9105
			public const string DIACH_5_OPENING_SCENE_0503 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_03";

			// Token: 0x04002392 RID: 9106
			public const string DIACH_5_OPENING_SCENE_0504 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_04";

			// Token: 0x04002393 RID: 9107
			public const string DIACH_5_OPENING_SCENE_0505 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_05";

			// Token: 0x04002394 RID: 9108
			public const string DIACH_5_OPENING_SCENE_0506 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_06";

			// Token: 0x04002395 RID: 9109
			public const string DIACH_5_OPENING_SCENE_0507 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_07";

			// Token: 0x04002396 RID: 9110
			public const string DIACH_5_OPENING_SCENE_0508 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_08";

			// Token: 0x04002397 RID: 9111
			public const string DIACH_5_OPENING_SCENE_0509 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_09";

			// Token: 0x04002398 RID: 9112
			public const string DIACH_5_OPENING_SCENE_0510 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_10";

			// Token: 0x04002399 RID: 9113
			public const string DIACH_5_OPENING_SCENE_0511 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_11";

			// Token: 0x0400239A RID: 9114
			public const string DIACH_5_OPENING_SCENE_0512 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_12";

			// Token: 0x0400239B RID: 9115
			public const string DIACH_5_OPENING_SCENE_0513 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_13";

			// Token: 0x0400239C RID: 9116
			public const string DIACH_5_OPENING_SCENE_0514 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_14";

			// Token: 0x0400239D RID: 9117
			public const string DIACH_5_OPENING_SCENE_0515 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_15";

			// Token: 0x0400239E RID: 9118
			public const string DIACH_5_OPENING_SCENE_0516 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_16";

			// Token: 0x0400239F RID: 9119
			public const string DIACH_5_OPENING_SCENE_0517 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_17";

			// Token: 0x040023A0 RID: 9120
			public const string DIACH_5_OPENING_SCENE_0518 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_18";

			// Token: 0x040023A1 RID: 9121
			public const string DIACH_5_OPENING_SCENE_0519 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_19";

			// Token: 0x040023A2 RID: 9122
			public const string DIACH_5_OPENING_SCENE_0520 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_20";

			// Token: 0x040023A3 RID: 9123
			public const string DIACH_5_OPENING_SCENE_0521 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_21";

			// Token: 0x040023A4 RID: 9124
			public const string DIACH_5_OPENING_SCENE_0522 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_22";

			// Token: 0x040023A5 RID: 9125
			public const string DIACH_5_OPENING_SCENE_0523 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_23";

			// Token: 0x040023A6 RID: 9126
			public const string DIACH_5_OPENING_SCENE_0524 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_24";

			// Token: 0x040023A7 RID: 9127
			public const string DIACH_5_OPENING_SCENE_0525 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_25";

			// Token: 0x040023A8 RID: 9128
			public const string DIACH_5_OPENING_SCENE_0526 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_26";

			// Token: 0x040023A9 RID: 9129
			public const string DIACH_5_OPENING_SCENE_0527 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_27";

			// Token: 0x040023AA RID: 9130
			public const string DIACH_5_OPENING_SCENE_0528 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_28";

			// Token: 0x040023AB RID: 9131
			public const string DIACH_5_OPENING_SCENE_0529 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_29";

			// Token: 0x040023AC RID: 9132
			public const string DIACH_5_OPENING_SCENE_0530 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_30";

			// Token: 0x040023AD RID: 9133
			public const string DIACH_5_OPENING_SCENE_0531 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_31";

			// Token: 0x040023AE RID: 9134
			public const string DIACH_5_OPENING_SCENE_0532 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_32";

			// Token: 0x040023AF RID: 9135
			public const string DIACH_5_OPENING_SCENE_0533 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_33";

			// Token: 0x040023B0 RID: 9136
			public const string DIACH_5_OPENING_SCENE_0534 = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_34";

			// Token: 0x040023B1 RID: 9137
			public const string DIACH_5_OPENING_SCENE_0535B = "Audio/DIA/CH5/Opening/Scene5/DIA_CH5_Opening_Scene_05_35b";

			// Token: 0x040023B2 RID: 9138
			public const string DIACH_5_OPENING_SCENE_0601 = "Audio/DIA/CH5/Opening/Scene6/DIA_CH5_Opening_Scene_06_01";

			// Token: 0x040023B3 RID: 9139
			public const string DIACH_5_OPENING_SCENE_0602 = "Audio/DIA/CH5/Opening/Scene6/DIA_CH5_Opening_Scene_06_02";

			// Token: 0x040023B4 RID: 9140
			public const string DIACH_5_OPENING_SCENE_0603 = "Audio/DIA/CH5/Opening/Scene6/DIA_CH5_Opening_Scene_06_03";

			// Token: 0x040023B5 RID: 9141
			public const string DIACH_5_OPENING_SCENE_0604 = "Audio/DIA/CH5/Opening/Scene6/DIA_CH5_Opening_Scene_06_04";

			// Token: 0x040023B6 RID: 9142
			public const string DIACH_5_OPENING_SCENE_0605 = "Audio/DIA/CH5/Opening/Scene6/DIA_CH5_Opening_Scene_06_05";

			// Token: 0x040023B7 RID: 9143
			public const string DIACH_5_OPENING_SCENE_0606B = "Audio/DIA/CH5/Opening/Scene6/DIA_CH5_Opening_Scene_06_06b";

			// Token: 0x040023B8 RID: 9144
			public const string DIACH_5_OPENING_SCENE_0607 = "Audio/DIA/CH5/Opening/Scene6/DIA_CH5_Opening_Scene_06_07";

			// Token: 0x040023B9 RID: 9145
			public const string DIACH_5_OPENING_SCENE_0701 = "Audio/DIA/CH5/Opening/Scene7/DIA_CH5_Opening_Scene_07_01";

			// Token: 0x040023BA RID: 9146
			public const string DIACH_5_OPENING_SCENE_0702 = "Audio/DIA/CH5/Opening/Scene7/DIA_CH5_Opening_Scene_07_02";

			// Token: 0x040023BB RID: 9147
			public const string DIACH_5_OPENING_SCENE_0703 = "Audio/DIA/CH5/Opening/Scene7/DIA_CH5_Opening_Scene_07_03";

			// Token: 0x040023BC RID: 9148
			public const string DIACH_5_OPENING_SCENE_0704 = "Audio/DIA/CH5/Opening/Scene7/DIA_CH5_Opening_Scene_07_04";

			// Token: 0x040023BD RID: 9149
			public const string DIACH_5_OPENING_SCENE_0705 = "Audio/DIA/CH5/Opening/Scene7/DIA_CH5_Opening_Scene_07_05";

			// Token: 0x040023BE RID: 9150
			public const string DIACH_5_OPENING_SCENE_0706 = "Audio/DIA/CH5/Opening/Scene7/DIA_CH5_Opening_Scene_07_06";

			// Token: 0x040023BF RID: 9151
			public const string DIACH_5_OPENING_SCENE_0707 = "Audio/DIA/CH5/Opening/Scene7/DIA_CH5_Opening_Scene_07_07";

			// Token: 0x040023C0 RID: 9152
			public const string DIACH_5_OPENING_SCENE_0708 = "Audio/DIA/CH5/Opening/Scene7/DIA_CH5_Opening_Scene_07_08";

			// Token: 0x040023C1 RID: 9153
			public const string DIACH_5_OPENING_SCENE_0709 = "Audio/DIA/CH5/Opening/Scene7/DIA_CH5_Opening_Scene_07_09";

			// Token: 0x040023C2 RID: 9154
			public const string DIACH_5_OPENING_SCENE_0117A = "Audio/DIA/CH5/Opening/_Old/DIA_CH5_Opening_Scene_01_17a";

			// Token: 0x040023C3 RID: 9155
			public const string DIACH_5_OPENING_SCENE_0205A = "Audio/DIA/CH5/Opening/_Old/DIA_CH5_Opening_Scene_02_05a";

			// Token: 0x040023C4 RID: 9156
			public const string DIACH_5_OPENING_SCENE_0404A = "Audio/DIA/CH5/Opening/_Old/DIA_CH5_Opening_Scene_04_04a";

			// Token: 0x040023C5 RID: 9157
			public const string DIACH_5_OPENING_SCENE_0535A = "Audio/DIA/CH5/Opening/_Old/DIA_CH5_Opening_Scene_05_35a";

			// Token: 0x040023C6 RID: 9158
			public const string DIACH_5_OPENING_SCENE_0606A = "Audio/DIA/CH5/Opening/_Old/DIA_CH5_Opening_Scene_06_06a";

			// Token: 0x040023C7 RID: 9159
			public const string DIACH_5_SAMMYNOMASK = "Audio/DIA/CH5/Sammy/DIA_CH5_SAMMY_NO_MASK";

			// Token: 0x040023C8 RID: 9160
			public const string DIACH_5_SAMMYBATTLE_01 = "Audio/DIA/CH5/Sammy/Battle/DIA_CH5_SAMMY_BATTLE_01";

			// Token: 0x040023C9 RID: 9161
			public const string DIACH_5_SAMMYBATTLE_02 = "Audio/DIA/CH5/Sammy/Battle/DIA_CH5_SAMMY_BATTLE_02";

			// Token: 0x040023CA RID: 9162
			public const string DIACH_5_SAMMYBATTLE_03 = "Audio/DIA/CH5/Sammy/Battle/DIA_CH5_SAMMY_BATTLE_03";

			// Token: 0x040023CB RID: 9163
			public const string DIACH_5_SAMMYBATTLE_04 = "Audio/DIA/CH5/Sammy/Battle/DIA_CH5_SAMMY_BATTLE_04";

			// Token: 0x040023CC RID: 9164
			public const string DIACH_5_SAMMYBATTLE_05 = "Audio/DIA/CH5/Sammy/Battle/DIA_CH5_SAMMY_BATTLE_05";

			// Token: 0x040023CD RID: 9165
			public const string DIACH_5_SAMMYDEATH_01 = "Audio/DIA/CH5/Sammy/Death/DIA_CH5_SAMMY_DEATH_01";

			// Token: 0x040023CE RID: 9166
			public const string DIACH_5_SAMMYDEATH_02 = "Audio/DIA/CH5/Sammy/Death/DIA_CH5_SAMMY_DEATH_02";

			// Token: 0x040023CF RID: 9167
			public const string DIACH_5_SAMMYDEATH_03 = "Audio/DIA/CH5/Sammy/Death/DIA_CH5_SAMMY_DEATH_03";

			// Token: 0x040023D0 RID: 9168
			public const string DIACH_5_SAMMYDEATH_04 = "Audio/DIA/CH5/Sammy/Death/DIA_CH5_SAMMY_DEATH_04";

			// Token: 0x040023D1 RID: 9169
			public const string DIACH_5_SAMMYDEATH_05 = "Audio/DIA/CH5/Sammy/Death/DIA_CH5_SAMMY_DEATH_05";

			// Token: 0x040023D2 RID: 9170
			public const string DIACH_5_SAMMYDEATH_06 = "Audio/DIA/CH5/Sammy/Death/DIA_CH5_SAMMY_DEATH_06";

			// Token: 0x040023D3 RID: 9171
			public const string DIACH_5_SAMMYDEATH_07 = "Audio/DIA/CH5/Sammy/Death/DIA_CH5_SAMMY_DEATH_07";

			// Token: 0x040023D4 RID: 9172
			public const string DIACH_5_SAMMYDEATH_08B = "Audio/DIA/CH5/Sammy/Death/DIA_CH5_SAMMY_DEATH_08b";

			// Token: 0x040023D5 RID: 9173
			public const string DIACH_5_SAMMYDEATH_09 = "Audio/DIA/CH5/Sammy/Death/DIA_CH5_SAMMY_DEATH_09";

			// Token: 0x040023D6 RID: 9174
			public const string DIACH_5_SAMMYINTRO_01 = "Audio/DIA/CH5/Sammy/Intro/DIA_CH5_SAMMY_INTRO_01";

			// Token: 0x040023D7 RID: 9175
			public const string DIACH_5_SAMMYINTRO_02 = "Audio/DIA/CH5/Sammy/Intro/DIA_CH5_SAMMY_INTRO_02";

			// Token: 0x040023D8 RID: 9176
			public const string DIACH_5_SAMMYINTRO_03 = "Audio/DIA/CH5/Sammy/Intro/DIA_CH5_SAMMY_INTRO_03";

			// Token: 0x040023D9 RID: 9177
			public const string DIACH_5_SAMMYDEATH_08A = "Audio/DIA/CH5/Sammy/_old/DIA_CH5_SAMMY_DEATH_08a";

			// Token: 0x040023DA RID: 9178
			public const string EASTER_EGG_INK_MUSICAL = "Audio/EasterEggs/EasterEggInkMusical";

			// Token: 0x040023DB RID: 9179
			public const string EASTER_EGG_JT_MUSIC_CANT_BE_ERASED = "Audio/EasterEggs/EasterEggJTMusicCantBeErased";

			// Token: 0x040023DC RID: 9180
			public const string EASTER_EGG_LONELY_ANGEL = "Audio/EasterEggs/EasterEggLonelyAngel";

			// Token: 0x040023DD RID: 9181
			public const string MUS_LITTLE_DEVIL_DARLING_REMASTERED = "Audio/MUS/MUS_Little_Devil_Darling_Remastered";

			// Token: 0x040023DE RID: 9182
			public const string MUS_LOGO_INTRO = "Audio/MUS/MUS_Logo_Intro";

			// Token: 0x040023DF RID: 9183
			public const string MUS_BENDY_CARTOON_MUSIC = "Audio/MUS/CH1/MUS_BendyCartoonMusic";

			// Token: 0x040023E0 RID: 9184
			public const string MUS_DOWN_WHERE_MONSTERS_LIVE = "Audio/MUS/CH1/MUS_DownWhereMonstersLive";

			// Token: 0x040023E1 RID: 9185
			public const string MUS_LITTLE_DEVIL_DARLING_LOOP_01 = "Audio/MUS/CH1/MUS_Little_Devil_Darling_Loop_01";

			// Token: 0x040023E2 RID: 9186
			public const string MUS_MACHINE_REVEALED = "Audio/MUS/CH1/MUS_MachineRevealed";

			// Token: 0x040023E3 RID: 9187
			public const string MUS_ODE_TO_BENDY_LOOP_01 = "Audio/MUS/CH1/MUS_Ode_To_Bendy_Loop_01";

			// Token: 0x040023E4 RID: 9188
			public const string MUS_ODE_TO_BENDY_LOOP_THROUGH_DOOR_01 = "Audio/MUS/CH1/MUS_Ode_To_Bendy_Loop_Through_Door_01";

			// Token: 0x040023E5 RID: 9189
			public const string MUS_YOU_LEFT_ME_IN_A_HEARTBEAT_LOOP_01_LOUD = "Audio/MUS/CH1/MUS_You_Left_Me_In_A_Heartbeat_Loop_01LOUD";

			// Token: 0x040023E6 RID: 9190
			public const string MUS_YOU_LEFT_ME_IN_A_HEARTBEAT_START_UP_01_LOUD = "Audio/MUS/CH1/MUS_You_Left_Me_In_A_Heartbeat_Start_Up_01LOUD";

			// Token: 0x040023E7 RID: 9191
			public const string MUS_CHAPTER_TWO_TITLE = "Audio/MUS/CH2/MUS_Chapter_Two_Title";

			// Token: 0x040023E8 RID: 9192
			public const string MUS_HORROR_CUE_02 = "Audio/MUS/CH2/MUS_Horror_Cue_02";

			// Token: 0x040023E9 RID: 9193
			public const string MUS_LOBBY_JAZZ_01 = "Audio/MUS/CH2/MUS_Lobby_Jazz_01";

			// Token: 0x040023EA RID: 9194
			public const string MUS_SEARCHER_START_CUE_01 = "Audio/MUS/CH2/MUS_SearcherStartCue01";

			// Token: 0x040023EB RID: 9195
			public const string MUS_THE_SEARCHERS = "Audio/MUS/CH2/MUS_The_Searchers";

			// Token: 0x040023EC RID: 9196
			public const string MUSCH_3AAINTRODUCTIONSONG = "Audio/MUS/CH3/MUS_CH3_aaintroductionsong";

			// Token: 0x040023ED RID: 9197
			public const string MUSCH_3AAJUMPSCARE = "Audio/MUS/CH3/MUS_CH3_aajumpscare";

			// Token: 0x040023EE RID: 9198
			public const string MUSCH_3ANGELICAMBIENCE = "Audio/MUS/CH3/MUS_CH3_angelicambience";

			// Token: 0x040023EF RID: 9199
			public const string MUSCH_3ANGELICAMBIENCE_2 = "Audio/MUS/CH3/MUS_CH3_angelicambience2";

			// Token: 0x040023F0 RID: 9200
			public const string MUSCH_3FORMERGLORY = "Audio/MUS/CH3/MUS_CH3_formerglory";

			// Token: 0x040023F1 RID: 9201
			public const string MUSCH_3_MAIN_AMBIENCE_LOOP = "Audio/MUS/CH3/MUS_CH3_MainAmbienceLoop";

			// Token: 0x040023F2 RID: 9202
			public const string MUSCH_3OLDFRIENDSNEWFACES = "Audio/MUS/CH3/MUS_CH3_oldfriendsnewfaces";

			// Token: 0x040023F3 RID: 9203
			public const string MUSCH_3REELFEARLOOP = "Audio/MUS/CH3/MUS_CH3_reelfearloop";

			// Token: 0x040023F4 RID: 9204
			public const string MUSCH_3THEDARKPUDDLES = "Audio/MUS/CH3/MUS_CH3_thedarkpuddles";

			// Token: 0x040023F5 RID: 9205
			public const string MUSCH_3THEOLDGANGENDING = "Audio/MUS/CH3/MUS_CH3_theoldgangending";

			// Token: 0x040023F6 RID: 9206
			public const string MUSCH_3THEOLDGANGFASTER = "Audio/MUS/CH3/MUS_CH3_theoldgangfaster";

			// Token: 0x040023F7 RID: 9207
			public const string MUSCH_3THEOLDGANGSLOW = "Audio/MUS/CH3/MUS_CH3_theoldgangslow";

			// Token: 0x040023F8 RID: 9208
			public const string MUSCH_3THEPRICEOFBEAUTY = "Audio/MUS/CH3/MUS_CH3_thepriceofbeauty";

			// Token: 0x040023F9 RID: 9209
			public const string MUSCH_3THINKINGOFYOU = "Audio/MUS/CH3/MUS_CH3_thinkingofyou";

			// Token: 0x040023FA RID: 9210
			public const string MUSCH_3WHOSLAUGHINGNOW = "Audio/MUS/CH3/MUS_CH3_whoslaughingnow";

			// Token: 0x040023FB RID: 9211
			public const string MUSCH_3WHOSLAUGHINGNOW_LOOP = "Audio/MUS/CH3/MUS_CH3_whoslaughingnow_Loop";

			// Token: 0x040023FC RID: 9212
			public const string MUS_BAD_DOG = "Audio/MUS/CH4/MUS_BadDog";

			// Token: 0x040023FD RID: 9213
			public const string MUS_COLOSSAL_WONDERS = "Audio/MUS/CH4/MUS_ColossalWonders";

			// Token: 0x040023FE RID: 9214
			public const string MUS_COLOSSAL_WONDERS_FINISHER = "Audio/MUS/CH4/MUS_ColossalWondersFinisher";

			// Token: 0x040023FF RID: 9215
			public const string MUS_DANGLING_BY_A_THREAD = "Audio/MUS/CH4/MUS_DanglingByAThread";

			// Token: 0x04002400 RID: 9216
			public const string MUS_DEATH_OF_A_FRIEND = "Audio/MUS/CH4/MUS_DeathOfAFriend";

			// Token: 0x04002401 RID: 9217
			public const string MUS_DEATH_OF_A_FRIEND_FINISHER = "Audio/MUS/CH4/MUS_DeathOfAFriendFinisher";

			// Token: 0x04002402 RID: 9218
			public const string MUS_ENDINGS_AND_BEGINNINGS = "Audio/MUS/CH4/MUS_EndingsAndBeginnings";

			// Token: 0x04002403 RID: 9219
			public const string MUS_HELLO_BERTIE = "Audio/MUS/CH4/MUS_HelloBertie";

			// Token: 0x04002404 RID: 9220
			public const string MU_SLETSPLAYLOOP = "Audio/MUS/CH4/MUS_letsplay_loop";

			// Token: 0x04002405 RID: 9221
			public const string MUS_LONG_LONG_FORGOTTEN = "Audio/MUS/CH4/MUS_LongLongForgotten";

			// Token: 0x04002406 RID: 9222
			public const string MUS_NEW_BEGINNINGS = "Audio/MUS/CH4/MUS_NewBeginnings";

			// Token: 0x04002407 RID: 9223
			public const string MUS_NOBODY_KNOWS_THE_TROUBLE_IVE_SEEN = "Audio/MUS/CH4/MUS_NobodyKnowsTheTroubleIveSeen";

			// Token: 0x04002408 RID: 9224
			public const string MUS_OLD_ENDINGS = "Audio/MUS/CH4/MUS_OldEndings";

			// Token: 0x04002409 RID: 9225
			public const string MUS_OLD_LIGHT_HEAD = "Audio/MUS/CH4/MUS_OldLightHead";

			// Token: 0x0400240A RID: 9226
			public const string MUS_THE_LOST_ONES = "Audio/MUS/CH4/MUS_TheLostOnes";

			// Token: 0x0400240B RID: 9227
			public const string MUS_THE_MONSTER_WALTZ = "Audio/MUS/CH4/MUS_TheMonsterWaltz";

			// Token: 0x0400240C RID: 9228
			public const string MUS_WELCOME_TO_BENDY_LAND = "Audio/MUS/CH4/MUS_WelcomeToBendyLand";

			// Token: 0x0400240D RID: 9229
			public const string MUS_ANOTHER_WORLD_REVEALED = "Audio/MUS/CH5/MUS_AnotherWorldRevealed";

			// Token: 0x0400240E RID: 9230
			public const string MUSA_SONGWRITER_SCORNED = "Audio/MUS/CH5/MUS_ASongwriterScorned";

			// Token: 0x0400240F RID: 9231
			public const string MUS_CIRCLES = "Audio/MUS/CH5/MUS_Circles";

			// Token: 0x04002410 RID: 9232
			public const string MUS_FALLING_AGAIN = "Audio/MUS/CH5/MUS_FallingAgain";

			// Token: 0x04002411 RID: 9233
			public const string MUS_INSIDE_THE_MACHINE = "Audio/MUS/CH5/MUS_InsideTheMachine";

			// Token: 0x04002412 RID: 9234
			public const string MUS_LEGACY_AND_SHAME = "Audio/MUS/CH5/MUS_LegacyAndShame";

			// Token: 0x04002413 RID: 9235
			public const string MUS_LONELY_ANGEL_CLARINET_EDITION = "Audio/MUS/CH5/MUS_LonelyAngelClarinetEdition";

			// Token: 0x04002414 RID: 9236
			public const string MUS_LONELY_ANGEL_VIOLIN_EDITION = "Audio/MUS/CH5/MUS_LonelyAngelViolinEdition";

			// Token: 0x04002415 RID: 9237
			public const string MU_SLONELYANGELAPARTMENTRADIOVERSION = "Audio/MUS/CH5/MUS_lonelyangel_apartmentradioversion";

			// Token: 0x04002416 RID: 9238
			public const string MUS_NAKED_AND_AFRAID = "Audio/MUS/CH5/MUS_NakedAndAfraid";

			// Token: 0x04002417 RID: 9239
			public const string MUS_STANDING_TOGETHER = "Audio/MUS/CH5/MUS_StandingTogether";

			// Token: 0x04002418 RID: 9240
			public const string MUS_STANDING_TOGETHER_FINISHER = "Audio/MUS/CH5/MUS_StandingTogether_Finisher";

			// Token: 0x04002419 RID: 9241
			public const string MUS_STORIES = "Audio/MUS/CH5/MUS_Stories";

			// Token: 0x0400241A RID: 9242
			public const string MUS_THE_BEAST_REVEALED = "Audio/MUS/CH5/MUS_TheBeastRevealed";

			// Token: 0x0400241B RID: 9243
			public const string MUS_THE_END_OF_ALL_THINGS = "Audio/MUS/CH5/MUS_TheEndOfAllThings";

			// Token: 0x0400241C RID: 9244
			public const string MUS_THE_INK_DEMON = "Audio/MUS/CH5/MUS_TheInkDemon";

			// Token: 0x0400241D RID: 9245
			public const string MUS_THE_INK_DEMON_UNDERSCORE = "Audio/MUS/CH5/MUS_TheInkDemon_Underscore";

			// Token: 0x0400241E RID: 9246
			public const string MUS_THE_INK_RIVER = "Audio/MUS/CH5/MUS_TheInkRiver";

			// Token: 0x0400241F RID: 9247
			public const string MUS_THE_LAST_REEL = "Audio/MUS/CH5/MUS_TheLastReel";

			// Token: 0x04002420 RID: 9248
			public const string MUS_THERE_YOU_ARE = "Audio/MUS/CH5/MUS_ThereYouAre";

			// Token: 0x04002421 RID: 9249
			public const string MUS_THE_TRUE_INK_MACHINE = "Audio/MUS/CH5/MUS_TheTrueInkMachine";

			// Token: 0x04002422 RID: 9250
			public const string MUS_WALKING_WITH_THE_DEMON = "Audio/MUS/CH5/MUS_WalkingWithTheDemon";

			// Token: 0x04002423 RID: 9251
			public const string AMB_FLOWING_INK = "Audio/SFX/AMB_FlowingInk";

			// Token: 0x04002424 RID: 9252
			public const string FOL_DUCT_CRAWLING_01 = "Audio/SFX/FOL_Duct_Crawling_01";

			// Token: 0x04002425 RID: 9253
			public const string SF_XBATIMINKDRIPPINGLOOP_01 = "Audio/SFX/SFX_batim_ink_dripping_loop_01";

			// Token: 0x04002426 RID: 9254
			public const string SF_XBATIMINKDRIPPINGSTARTUP_01 = "Audio/SFX/SFX_batim_ink_dripping_startup_01";

			// Token: 0x04002427 RID: 9255
			public const string SFX_BENDY_APPEARANCE = "Audio/SFX/SFX_BendyAppearance";

			// Token: 0x04002428 RID: 9256
			public const string SFX_BENDY_APPEARS_FROM_INK = "Audio/SFX/SFX_BendyAppearsFromInk";

			// Token: 0x04002429 RID: 9257
			public const string SFX_BENDY_AT_THE_DOOR = "Audio/SFX/SFX_BendyAtTheDoor";

			// Token: 0x0400242A RID: 9258
			public const string SFX_BENDY_HAND_ALICE_TOM_BOAT_SINK_SEQUENCE = "Audio/SFX/sfx_BendyHand_Alice_Tom_Boat_Sink_Sequence";

			// Token: 0x0400242B RID: 9259
			public const string SFX_BENDY_HAND_RISE = "Audio/SFX/sfx_BendyHand_Rise";

			// Token: 0x0400242C RID: 9260
			public const string SFX_BENDY_HAND_SLAP = "Audio/SFX/sfx_BendyHand_Slap";

			// Token: 0x0400242D RID: 9261
			public const string SFX_BENDY_CUTOUT_IMPACT_01 = "Audio/SFX/SFX_Bendy_Cutout_Impact_01";

			// Token: 0x0400242E RID: 9262
			public const string SFX_BENDY_VOCAL_CHEST_NOISE_LOOP_02 = "Audio/SFX/SFX_Bendy_Vocal_Chest_Noise_Loop_02";

			// Token: 0x0400242F RID: 9263
			public const string SFXBIGDOOROPEN = "Audio/SFX/sfx_big_door_open";

			// Token: 0x04002430 RID: 9264
			public const string SFX_BOARD_DROP_FROM_CEILING_01 = "Audio/SFX/SFX_Board_Drop_From_Ceiling_01";

			// Token: 0x04002431 RID: 9265
			public const string SFXBOATDESTROYED = "Audio/SFX/sfx_boat_destroyed";

			// Token: 0x04002432 RID: 9266
			public const string SFXBOXOPEN = "Audio/SFX/sfx_boxopen";

			// Token: 0x04002433 RID: 9267
			public const string SFX_CAMERA_FLASH_02 = "Audio/SFX/SFX_Camera_Flash_02";

			// Token: 0x04002434 RID: 9268
			public const string SFX_CAN_ROLLSLOW_01 = "Audio/SFX/SFX_Can_Roll_slow_01";

			// Token: 0x04002435 RID: 9269
			public const string SFX_CASSETTE_PLAYER_RUN_01 = "Audio/SFX/SFX_Cassette_Player_Run_01";

			// Token: 0x04002436 RID: 9270
			public const string SFX_CASSETTE_PLAYER_TURN_OFF_01 = "Audio/SFX/SFX_Cassette_Player_Turn_Off_01";

			// Token: 0x04002437 RID: 9271
			public const string SFX_CASSETTE_PLAYER_TURN_ON_01 = "Audio/SFX/SFX_Cassette_Player_Turn_On_01";

			// Token: 0x04002438 RID: 9272
			public const string SFX_CEILING_COLLAPSE_01 = "Audio/SFX/SFX_Ceiling_Collapse_01";

			// Token: 0x04002439 RID: 9273
			public const string SFX_CEILING_COLLAPSE_02 = "Audio/SFX/SFX_Ceiling_Collapse_02";

			// Token: 0x0400243A RID: 9274
			public const string SFX_CEILING_SETTLE_02 = "Audio/SFX/SFX_Ceiling_Settle_02";

			// Token: 0x0400243B RID: 9275
			public const string SFX_CHAPTER_ONE_BENDY_APPEARS = "Audio/SFX/SFX_ChapterOneBendyAppears";

			// Token: 0x0400243C RID: 9276
			public const string SFXDOORSMASH = "Audio/SFX/sfx_doorsmash";

			// Token: 0x0400243D RID: 9277
			public const string SFX_DRAWER = "Audio/SFX/SFX_Drawer";

			// Token: 0x0400243E RID: 9278
			public const string SFX_DUCT_SCARE_01 = "Audio/SFX/SFX_Duct_Scare_01";

			// Token: 0x0400243F RID: 9279
			public const string SFX_FINGER_VENT = "Audio/SFX/SFX_Finger_Vent";

			// Token: 0x04002440 RID: 9280
			public const string SFX_FLOOR_BOARDS_BREAK_01_L = "Audio/SFX/SFX_Floor_Boards_Break_01.L";

			// Token: 0x04002441 RID: 9281
			public const string SFX_GATE_SMASH_01 = "Audio/SFX/SFX_GateSmash_01";

			// Token: 0x04002442 RID: 9282
			public const string SFX_GATE_SMASH_02 = "Audio/SFX/SFX_GateSmash_02";

			// Token: 0x04002443 RID: 9283
			public const string SFX_GATE_CLOSE_01 = "Audio/SFX/SFX_Gate_Close_01";

			// Token: 0x04002444 RID: 9284
			public const string SFX_GATE_OPEN_01 = "Audio/SFX/SFX_Gate_Open_01";

			// Token: 0x04002445 RID: 9285
			public const string SFX_GATE_OPEN_SLOW_01 = "Audio/SFX/SFX_Gate_Open_Slow_01";

			// Token: 0x04002446 RID: 9286
			public const string SFX_GENERIC_DOORKNOB_RATTLE_01 = "Audio/SFX/SFX_Generic_Doorknob_Rattle_01";

			// Token: 0x04002447 RID: 9287
			public const string SFX_GENERIC_DOORKNOB_RATTLE_02 = "Audio/SFX/SFX_Generic_Doorknob_Rattle_02";

			// Token: 0x04002448 RID: 9288
			public const string SFX_GENERIC_DOORKNOB_RATTLE_03 = "Audio/SFX/SFX_Generic_Doorknob_Rattle_03";

			// Token: 0x04002449 RID: 9289
			public const string SFX_GENERIC_DOORKNOB_RATTLE_04 = "Audio/SFX/SFX_Generic_Doorknob_Rattle_04";

			// Token: 0x0400244A RID: 9290
			public const string SFX_HENRY_BODY_FALL_01 = "Audio/SFX/SFX_Henry_Body_Fall_01";

			// Token: 0x0400244B RID: 9291
			public const string SFX_HENRY_FAINT_AXE = "Audio/SFX/SFX_Henry_Faint_Axe";

			// Token: 0x0400244C RID: 9292
			public const string SFX_HENRY_HIT_ON_HEAD = "Audio/SFX/SFX_Henry_HitOnHead";

			// Token: 0x0400244D RID: 9293
			public const string SFX_HORROR_AMBIENCE_LOOP_01 = "Audio/SFX/SFX_Horror_Ambience_Loop_01";

			// Token: 0x0400244E RID: 9294
			public const string SFXHU_DWHOOSH_01 = "Audio/SFX/SFX_HUD_whoosh_01";

			// Token: 0x0400244F RID: 9295
			public const string SFX_INK_MACHINE_MOTOR_AND_WHISTLE = "Audio/SFX/SFX_InkMachineMotorAndWhistle";

			// Token: 0x04002450 RID: 9296
			public const string SFX_INK_FLOOD_AMB_01 = "Audio/SFX/SFX_Ink_Flood_AMB_01";

			// Token: 0x04002451 RID: 9297
			public const string SFX_INK_GUSH_MED_01 = "Audio/SFX/SFX_Ink_Gush_Med_01";

			// Token: 0x04002452 RID: 9298
			public const string SFX_INK_MACHINE_RUN_LOOP_01 = "Audio/SFX/SFX_Ink_Machine_Run_Loop_01";

			// Token: 0x04002453 RID: 9299
			public const string SFX_JUMPSCARE_01 = "Audio/SFX/SFX_Jumpscare_01";

			// Token: 0x04002454 RID: 9300
			public const string SFX_LAMP_FLICKER_LOOP_01 = "Audio/SFX/SFX_Lamp_Flicker_Loop_01";

			// Token: 0x04002455 RID: 9301
			public const string SFX_LIGHT_SWITCH_SAMMYS_ROOM_01 = "Audio/SFX/SFX_Light_Switch_Sammys_Room_01";

			// Token: 0x04002456 RID: 9302
			public const string SFX_LOW_RUMBLE_CLOSING_SCENE_01 = "Audio/SFX/SFX_Low_Rumble_Closing_Scene_01";

			// Token: 0x04002457 RID: 9303
			public const string SFX_MAINR_POWER_LEVER_TURN_ON_01 = "Audio/SFX/SFX_Mainr_Power_Lever_Turn_On_01";

			// Token: 0x04002458 RID: 9304
			public const string SFX_PIANO_LID_CLOSE_JUMPSCARE = "Audio/SFX/SFX_Piano_Lid_Close_Jumpscare";

			// Token: 0x04002459 RID: 9305
			public const string SFX_PIPES_INK_FLOW_01 = "Audio/SFX/SFX_Pipes_Ink_Flow_01";

			// Token: 0x0400245A RID: 9306
			public const string SFX_PIPES_INK_FLOW_02 = "Audio/SFX/SFX_Pipes_Ink_Flow_02";

			// Token: 0x0400245B RID: 9307
			public const string SFX_PIPES_STRESS_01 = "Audio/SFX/SFX_Pipes_Stress_01";

			// Token: 0x0400245C RID: 9308
			public const string SF_XPROJECTIONISTPROJECTORLOOP_01 = "Audio/SFX/SFX_projectionist_projector_loop01";

			// Token: 0x0400245D RID: 9309
			public const string SFX_PROJECTOR_RUNNING_WILD_01 = "Audio/SFX/SFX_Projector_Running_Wild_01";

			// Token: 0x0400245E RID: 9310
			public const string SFX_PROJECTOR_RUN_WITH_FILM_01 = "Audio/SFX/SFX_Projector_Run_With_Film_01";

			// Token: 0x0400245F RID: 9311
			public const string SFX_PROJECTOR_SWITCH_TURN_ON_01 = "Audio/SFX/SFX_Projector_Switch_Turn_On_01";

			// Token: 0x04002460 RID: 9312
			public const string SFX_RESPAWN_01 = "Audio/SFX/SFX_Respawn_01";

			// Token: 0x04002461 RID: 9313
			public const string SFX_RINGING_EARS_01 = "Audio/SFX/SFX_Ringing_Ears_01";

			// Token: 0x04002462 RID: 9314
			public const string SFX_ROPE_STRESS_01 = "Audio/SFX/SFX_Rope_Stress_01";

			// Token: 0x04002463 RID: 9315
			public const string SFX_ROPE_STRESS_SNAP_02 = "Audio/SFX/SFX_Rope_Stress_Snap_02";

			// Token: 0x04002464 RID: 9316
			public const string SFX_RUMBLE_LOOP_01 = "Audio/SFX/SFX_Rumble_Loop_01";

			// Token: 0x04002465 RID: 9317
			public const string SF_XRUNNINGOVERHEAD = "Audio/SFX/SFX_runningoverhead";

			// Token: 0x04002466 RID: 9318
			public const string SFX_SAMMY_JUMPSCARE = "Audio/SFX/SFX_SammyJumpscare";

			// Token: 0x04002467 RID: 9319
			public const string SFXSCENESEVENRUMBLE = "Audio/SFX/sfx_sceneseven_rumble";

			// Token: 0x04002468 RID: 9320
			public const string SFX_SPEAKER_TAP_FEEDBACK = "Audio/SFX/SFX_Speaker_Tap_Feedback";

			// Token: 0x04002469 RID: 9321
			public const string SFX_SPLASH_01 = "Audio/SFX/SFX_Splash_01";

			// Token: 0x0400246A RID: 9322
			public const string SFX_STAND_UP_PLAYER_01 = "Audio/SFX/SFX_Stand_Up_Player_01";

			// Token: 0x0400246B RID: 9323
			public const string SFX_TUMBLE_DOWN_SHAFT_01 = "Audio/SFX/SFX_Tumble_Down_Shaft_01";

			// Token: 0x0400246C RID: 9324
			public const string SFX_TUMBLE_DOWN_SHAFT_BODY_FALL_01 = "Audio/SFX/SFX_Tumble_Down_Shaft_Body_Fall_01";

			// Token: 0x0400246D RID: 9325
			public const string SFX_VALVE_TURN_01 = "Audio/SFX/SFX_Valve_Turn_01";

			// Token: 0x0400246E RID: 9326
			public const string SFX_VALVE_TURN_STEAM_RELEASE_01 = "Audio/SFX/SFX_Valve_Turn_Steam_Release_01";

			// Token: 0x0400246F RID: 9327
			public const string SFX_VISIONS_CH_1 = "Audio/SFX/SFX_Visions_CH1";

			// Token: 0x04002470 RID: 9328
			public const string SFXWALLSMASH = "Audio/SFX/sfx_wall_smash";

			// Token: 0x04002471 RID: 9329
			public const string SFX_WOOD_PLANK_FALL = "Audio/SFX/SFX_WoodPlankFall";

			// Token: 0x04002472 RID: 9330
			public const string SFXCH_3ALICEPRESSBUTTON = "Audio/SFX/CH3/SFX_CH3_alicepressbutton";

			// Token: 0x04002473 RID: 9331
			public const string SFXCH_3ATTENTIONPROMPT = "Audio/SFX/CH3/SFX_CH3_attentionprompt";

			// Token: 0x04002474 RID: 9332
			public const string SFXCH_3_BENDY_AMBIENCE = "Audio/SFX/CH3/SFX_CH3_BendyAmbience";

			// Token: 0x04002475 RID: 9333
			public const string SFXCH_3BENDYCLOCKLOOP = "Audio/SFX/CH3/SFX_CH3_bendyclockloop";

			// Token: 0x04002476 RID: 9334
			public const string SFXCH_3BORISBOWLOFSOUP = "Audio/SFX/CH3/SFX_CH3_borisbowlofsoup";

			// Token: 0x04002477 RID: 9335
			public const string SFXCH_3BORISDUCTS = "Audio/SFX/CH3/SFX_CH3_borisducts";

			// Token: 0x04002478 RID: 9336
			public const string SFXCH_3BORISPLACETOOLBOX = "Audio/SFX/CH3/SFX_CH3_borisplacetoolbox";

			// Token: 0x04002479 RID: 9337
			public const string SFXCH_3BORISTAKESBONE = "Audio/SFX/CH3/SFX_CH3_boristakesbone";

			// Token: 0x0400247A RID: 9338
			public const string SFXCH_3BORISVENTCOVER = "Audio/SFX/CH3/SFX_CH3_borisventcover";

			// Token: 0x0400247B RID: 9339
			public const string SFXCH_3CREEPINGINKLOOP = "Audio/SFX/CH3/SFX_CH3_creepinginkloop";

			// Token: 0x0400247C RID: 9340
			public const string SFXCH_3CREEPINGLOOP = "Audio/SFX/CH3/SFX_CH3_creepingloop";

			// Token: 0x0400247D RID: 9341
			public const string SFXCH_3DROPBOXINTERACT = "Audio/SFX/CH3/SFX_CH3_dropboxinteract";

			// Token: 0x0400247E RID: 9342
			public const string SFXCH_3ELEVATORDOORCLOSE = "Audio/SFX/CH3/SFX_CH3_elevatordoorclose";

			// Token: 0x0400247F RID: 9343
			public const string SFXCH_3ELEVATORDOOROPEN = "Audio/SFX/CH3/SFX_CH3_elevatordooropen";

			// Token: 0x04002480 RID: 9344
			public const string SFXCH_3ELEVATORFALLINGLOOP = "Audio/SFX/CH3/SFX_CH3_elevatorfallingloop";

			// Token: 0x04002481 RID: 9345
			public const string SFXCH_3FINALEENDING = "Audio/SFX/CH3/SFX_CH3_finaleending";

			// Token: 0x04002482 RID: 9346
			public const string SFXCH_3FINALEENDING_2 = "Audio/SFX/CH3/SFX_CH3_finaleending2";

			// Token: 0x04002483 RID: 9347
			public const string SFXCH_3FINALEENDING_3 = "Audio/SFX/CH3/SFX_CH3_finaleending3";

			// Token: 0x04002484 RID: 9348
			public const string SFXCH_3FLASHLIGHTURNON = "Audio/SFX/CH3/SFX_CH3_flashlighturnon";

			// Token: 0x04002485 RID: 9349
			public const string SFXCH_3_FLUSH = "Audio/SFX/CH3/SFX_CH3_Flush";

			// Token: 0x04002486 RID: 9350
			public const string SFXCH_3GEARBOXLOOP = "Audio/SFX/CH3/SFX_CH3_gearboxloop";

			// Token: 0x04002487 RID: 9351
			public const string SFXCH_3GEARMISSIONGEARBOXCOVEROPEN = "Audio/SFX/CH3/SFX_CH3_gearmission_gearboxcoveropen";

			// Token: 0x04002488 RID: 9352
			public const string SFXCH_3GEARMISSIONTAKEGEAR = "Audio/SFX/CH3/SFX_CH3_gearmission_takegear";

			// Token: 0x04002489 RID: 9353
			public const string SFXCH_3GENERICPICKUP = "Audio/SFX/CH3/SFX_CH3_genericpickup";

			// Token: 0x0400248A RID: 9354
			public const string SFXCH_3HENTRYINTRO = "Audio/SFX/CH3/SFX_CH3_hentryintro";

			// Token: 0x0400248B RID: 9355
			public const string SFXCH_3INKTOY = "Audio/SFX/CH3/SFX_CH3_inktoy";

			// Token: 0x0400248C RID: 9356
			public const string SFXCH_3_LEVER_PULL = "Audio/SFX/CH3/SFX_CH3_LeverPull";

			// Token: 0x0400248D RID: 9357
			public const string SFXCH_3_LIFT_END_LOOP = "Audio/SFX/CH3/SFX_CH3_Lift_End_Loop";

			// Token: 0x0400248E RID: 9358
			public const string SFXCH_3MECHHALLWAYTOLIFT = "Audio/SFX/CH3/SFX_CH3_mechhallwaytolift";

			// Token: 0x0400248F RID: 9359
			public const string SFXCH_3MECHHALLWAYTORTUREROOM = "Audio/SFX/CH3/SFX_CH3_mechhallwaytortureroom";

			// Token: 0x04002490 RID: 9360
			public const string SFXCH_3MECHWALLLOOP = "Audio/SFX/CH3/SFX_CH3_mechwallloop";

			// Token: 0x04002491 RID: 9361
			public const string SFXCH_3METALDOORSOPENING = "Audio/SFX/CH3/SFX_CH3_metaldoorsopening";

			// Token: 0x04002492 RID: 9362
			public const string SFXCH_3_MIRACLE_STATION_ENTER = "Audio/SFX/CH3/SFX_CH3_Miracle_Station_Enter";

			// Token: 0x04002493 RID: 9363
			public const string SFXCH_3_MIRACLE_STATION_EXIT = "Audio/SFX/CH3/SFX_CH3_Miracle_Station_Exit";

			// Token: 0x04002494 RID: 9364
			public const string SFXCH_3OPENTOOLBOX = "Audio/SFX/CH3/SFX_CH3_opentoolbox";

			// Token: 0x04002495 RID: 9365
			public const string SFXCH_3PIPERFALLOUTOFPOSTER = "Audio/SFX/CH3/SFX_CH3_piperfalloutofposter";

			// Token: 0x04002496 RID: 9366
			public const string SFXCH_3PIPERRIPPINGTHROUGHPOSTER = "Audio/SFX/CH3/SFX_CH3_piperrippingthroughposter";

			// Token: 0x04002497 RID: 9367
			public const string SFXCH_3PIPERTORTUREDLOOP = "Audio/SFX/CH3/SFX_CH3_pipertorturedloop";

			// Token: 0x04002498 RID: 9368
			public const string SFXCH_3PIPERTORTURESTOP = "Audio/SFX/CH3/SFX_CH3_pipertorturestop";

			// Token: 0x04002499 RID: 9369
			public const string SFXCH_3PROJECTIONISTDEATH = "Audio/SFX/CH3/SFX_CH3_projectionist_death";

			// Token: 0x0400249A RID: 9370
			public const string SFXCH_3PROJECTIONISTSCREAM = "Audio/SFX/CH3/SFX_CH3_projectionist_scream";

			// Token: 0x0400249B RID: 9371
			public const string SFXCH_3PUNCHIN = "Audio/SFX/CH3/SFX_CH3_punchin";

			// Token: 0x0400249C RID: 9372
			public const string SFXCH_3RUNNINGOVERHEAD = "Audio/SFX/CH3/SFX_CH3_runningoverhead";

			// Token: 0x0400249D RID: 9373
			public const string SFXCH_3SAFEHOUSEDOOR = "Audio/SFX/CH3/SFX_CH3_safehousedoor";

			// Token: 0x0400249E RID: 9374
			public const string SFXCH_3SAFEHOUSEHANDLEPICKUP = "Audio/SFX/CH3/SFX_CH3_safehousehandlepickup";

			// Token: 0x0400249F RID: 9375
			public const string SFXCH_3SAFEHOUSEHANDLEPLACE = "Audio/SFX/CH3/SFX_CH3_safehousehandleplace";

			// Token: 0x040024A0 RID: 9376
			public const string SFXCH_3SOUPCOOKING = "Audio/SFX/CH3/SFX_CH3_soupcooking";

			// Token: 0x040024A1 RID: 9377
			public const string SFXCH_3SOUPPOTINTERACT = "Audio/SFX/CH3/SFX_CH3_souppotinteract";

			// Token: 0x040024A2 RID: 9378
			public const string SFXCH_3SWOLLENSEARCHERPOP = "Audio/SFX/CH3/SFX_CH3_swollensearcherpop";

			// Token: 0x040024A3 RID: 9379
			public const string SFXCH_3THEYREBREAKINGIN = "Audio/SFX/CH3/SFX_CH3_theyrebreakingin";

			// Token: 0x040024A4 RID: 9380
			public const string SFXCH_3THICKINKPICKUP = "Audio/SFX/CH3/SFX_CH3_thickinkpickup";

			// Token: 0x040024A5 RID: 9381
			public const string SFXCH_3TOMMYGUNMELT = "Audio/SFX/CH3/SFX_CH3_tommygunmelt";

			// Token: 0x040024A6 RID: 9382
			public const string SFXCH_3TOYRACK = "Audio/SFX/CH3/SFX_CH3_toyrack";

			// Token: 0x040024A7 RID: 9383
			public const string SFXCH_3TRUNKOPENING = "Audio/SFX/CH3/SFX_CH3_trunkopening";

			// Token: 0x040024A8 RID: 9384
			public const string SFXCH_3VALVEPANELCOREPICKUP = "Audio/SFX/CH3/SFX_CH3_valvepanelcorepickup";

			// Token: 0x040024A9 RID: 9385
			public const string SFXCH_3VALVEPANELDOOROPEN = "Audio/SFX/CH3/SFX_CH3_valvepaneldooropen";

			// Token: 0x040024AA RID: 9386
			public const string SFXCH_3VALVEPUZZLEALLINKVALVESALIGNED = "Audio/SFX/CH3/SFX_CH3_valvepuzzle_allinkvalvesaligned";

			// Token: 0x040024AB RID: 9387
			public const string SFXCH_3VALVEPUZZLEINKRISINGINPIPES = "Audio/SFX/CH3/SFX_CH3_valvepuzzle_inkrisinginpipes";

			// Token: 0x040024AC RID: 9388
			public const string SFXCH_3WEAPONGIVER = "Audio/SFX/CH3/SFX_CH3_weapongiver";

			// Token: 0x040024AD RID: 9389
			public const string SFXCH_3VALVEPUZZLEVALVEARRAY_01 = "Audio/SFX/CH3/Valves/SFX_CH3_valvepuzzle_valvearray_01";

			// Token: 0x040024AE RID: 9390
			public const string SFXCH_3VALVEPUZZLEVALVEARRAY_02 = "Audio/SFX/CH3/Valves/SFX_CH3_valvepuzzle_valvearray_02";

			// Token: 0x040024AF RID: 9391
			public const string SFXCH_3VALVEPUZZLEVALVEARRAY_03 = "Audio/SFX/CH3/Valves/SFX_CH3_valvepuzzle_valvearray_03";

			// Token: 0x040024B0 RID: 9392
			public const string SFXCH_3VALVEPUZZLEVALVEARRAY_04 = "Audio/SFX/CH3/Valves/SFX_CH3_valvepuzzle_valvearray_04";

			// Token: 0x040024B1 RID: 9393
			public const string SFXCH_3VALVEPUZZLEVALVEARRAY_05 = "Audio/SFX/CH3/Valves/SFX_CH3_valvepuzzle_valvearray_05";

			// Token: 0x040024B2 RID: 9394
			public const string SFXLOSTONEBALCONY = "Audio/SFX/CH4/sfx_lost_one_balcony";

			// Token: 0x040024B3 RID: 9395
			public const string CH_3_BUTCHERGANGBLAHBLAH = "Audio/SFX/Characters/ButcherGang/CH3_BUTCHER_GANG_BLAHBLAH";

			// Token: 0x040024B4 RID: 9396
			public const string CH_3_BUTCHERGANGHITME = "Audio/SFX/Characters/ButcherGang/CH3_BUTCHER_GANG_HITME";

			// Token: 0x040024B5 RID: 9397
			public const string CH_3_BUTCHERGANGITSCOLD = "Audio/SFX/Characters/ButcherGang/CH3_BUTCHER_GANG_ITSCOLD";

			// Token: 0x040024B6 RID: 9398
			public const string CH_3_BUTCHERGANGJUMPSCARE = "Audio/SFX/Characters/ButcherGang/CH3_BUTCHER_GANG_JUMPSCARE";

			// Token: 0x040024B7 RID: 9399
			public const string CH_3_BUTCHERGANGLAUGH = "Audio/SFX/Characters/ButcherGang/CH3_BUTCHER_GANG_LAUGH";

			// Token: 0x040024B8 RID: 9400
			public const string CH_3_BUTCHERGANGYEAAAA = "Audio/SFX/Characters/ButcherGang/CH3_BUTCHER_GANG_YEAAAA";

			// Token: 0x040024B9 RID: 9401
			public const string CH_3_BUTCHERGANGATTACK_01 = "Audio/SFX/Characters/ButcherGang/Attack/CH3_BUTCHER_GANG_ATTACK01";

			// Token: 0x040024BA RID: 9402
			public const string CH_3_BUTCHERGANGATTACK_02 = "Audio/SFX/Characters/ButcherGang/Attack/CH3_BUTCHER_GANG_ATTACK02";

			// Token: 0x040024BB RID: 9403
			public const string CH_3_BUTCHERGANGATTACK_03 = "Audio/SFX/Characters/ButcherGang/Attack/CH3_BUTCHER_GANG_ATTACK03";

			// Token: 0x040024BC RID: 9404
			public const string CH_3_BUTCHERGANGATTACK_04 = "Audio/SFX/Characters/ButcherGang/Attack/CH3_BUTCHER_GANG_ATTACK04";

			// Token: 0x040024BD RID: 9405
			public const string CH_3_BUTCHERGANGATTACK_05 = "Audio/SFX/Characters/ButcherGang/Attack/CH3_BUTCHER_GANG_ATTACK05";

			// Token: 0x040024BE RID: 9406
			public const string CH_3_BUTCHERGANGATTACK_06 = "Audio/SFX/Characters/ButcherGang/Attack/CH3_BUTCHER_GANG_ATTACK06";

			// Token: 0x040024BF RID: 9407
			public const string CH_3_BUTCHERGANGATTACK_07 = "Audio/SFX/Characters/ButcherGang/Attack/CH3_BUTCHER_GANG_ATTACK07";

			// Token: 0x040024C0 RID: 9408
			public const string CH_3_BUTCHERGANGDEATH_01 = "Audio/SFX/Characters/ButcherGang/Death/CH3_BUTCHER_GANG_DEATH01";

			// Token: 0x040024C1 RID: 9409
			public const string CH_3_BUTCHERGANGDEATH_02 = "Audio/SFX/Characters/ButcherGang/Death/CH3_BUTCHER_GANG_DEATH02";

			// Token: 0x040024C2 RID: 9410
			public const string CH_3_BUTCHERGANGDEATH_03 = "Audio/SFX/Characters/ButcherGang/Death/CH3_BUTCHER_GANG_DEATH03";

			// Token: 0x040024C3 RID: 9411
			public const string CH_3_BUTCHERGANGHIT_01 = "Audio/SFX/Characters/ButcherGang/Hit/CH3_BUTCHER_GANG_HIT01";

			// Token: 0x040024C4 RID: 9412
			public const string CH_3_BUTCHERGANGHIT_02 = "Audio/SFX/Characters/ButcherGang/Hit/CH3_BUTCHER_GANG_HIT02";

			// Token: 0x040024C5 RID: 9413
			public const string CH_3_BUTCHERGANGHIT_03 = "Audio/SFX/Characters/ButcherGang/Hit/CH3_BUTCHER_GANG_HIT03";

			// Token: 0x040024C6 RID: 9414
			public const string CH_3_BUTCHERGANGIDLE_01 = "Audio/SFX/Characters/ButcherGang/Idle/CH3_BUTCHER_GANG_IDLE01";

			// Token: 0x040024C7 RID: 9415
			public const string CH_3_BUTCHERGANGIDLE_02 = "Audio/SFX/Characters/ButcherGang/Idle/CH3_BUTCHER_GANG_IDLE02";

			// Token: 0x040024C8 RID: 9416
			public const string CH_3_BUTCHERGANGIDLE_03 = "Audio/SFX/Characters/ButcherGang/Idle/CH3_BUTCHER_GANG_IDLE03";

			// Token: 0x040024C9 RID: 9417
			public const string CH_3_BUTCHERGANGIDLE_04 = "Audio/SFX/Characters/ButcherGang/Idle/CH3_BUTCHER_GANG_IDLE04";

			// Token: 0x040024CA RID: 9418
			public const string CH_3_BUTCHERGANGIDLE_05 = "Audio/SFX/Characters/ButcherGang/Idle/CH3_BUTCHER_GANG_IDLE05";

			// Token: 0x040024CB RID: 9419
			public const string CH_3_BUTCHERGANGIDLE_06 = "Audio/SFX/Characters/ButcherGang/Idle/CH3_BUTCHER_GANG_IDLE06";

			// Token: 0x040024CC RID: 9420
			public const string SEARCHER_APPEAR_01 = "Audio/SFX/Characters/Searchers/Appear/SearcherAppear01";

			// Token: 0x040024CD RID: 9421
			public const string SEARCHER_APPEAR_02 = "Audio/SFX/Characters/Searchers/Appear/SearcherAppear02";

			// Token: 0x040024CE RID: 9422
			public const string SFX_SEARCHERS_VOIICE_ATTACK_01 = "Audio/SFX/Characters/Searchers/Attack/SFX_Searchers_Voiice_Attack_01";

			// Token: 0x040024CF RID: 9423
			public const string SFX_SEARCHERS_VOIICE_ATTACK_02 = "Audio/SFX/Characters/Searchers/Attack/SFX_Searchers_Voiice_Attack_02";

			// Token: 0x040024D0 RID: 9424
			public const string SFX_SEARCHERS_VOIICE_ATTACK_03 = "Audio/SFX/Characters/Searchers/Attack/SFX_Searchers_Voiice_Attack_03";

			// Token: 0x040024D1 RID: 9425
			public const string SFX_SEARCHERS_VOIICE_ATTACK_04 = "Audio/SFX/Characters/Searchers/Attack/SFX_Searchers_Voiice_Attack_04";

			// Token: 0x040024D2 RID: 9426
			public const string SFX_SEARCHERS_VOIICE_ATTACK_05 = "Audio/SFX/Characters/Searchers/Attack/SFX_Searchers_Voiice_Attack_05";

			// Token: 0x040024D3 RID: 9427
			public const string SFX_SEARCHERS_VOIICE_ATTACK_06 = "Audio/SFX/Characters/Searchers/Attack/SFX_Searchers_Voiice_Attack_06";

			// Token: 0x040024D4 RID: 9428
			public const string SFX_SEARCHERS_VOIICE_ATTACK_07 = "Audio/SFX/Characters/Searchers/Attack/SFX_Searchers_Voiice_Attack_07";

			// Token: 0x040024D5 RID: 9429
			public const string SFX_SEARCHERS_VOIICE_ATTACK_08 = "Audio/SFX/Characters/Searchers/Attack/SFX_Searchers_Voiice_Attack_08";

			// Token: 0x040024D6 RID: 9430
			public const string SFX_SEARCHERS_VOIICE_ATTACK_09 = "Audio/SFX/Characters/Searchers/Attack/SFX_Searchers_Voiice_Attack_09";

			// Token: 0x040024D7 RID: 9431
			public const string SFX_SEARCHER_DEATH_01 = "Audio/SFX/Characters/Searchers/Death/SFX_Searcher_Death_01";

			// Token: 0x040024D8 RID: 9432
			public const string SFX_SEARCHER_DEATH_02 = "Audio/SFX/Characters/Searchers/Death/SFX_Searcher_Death_02";

			// Token: 0x040024D9 RID: 9433
			public const string SFX_SEARCHER_MELT_01 = "Audio/SFX/Characters/Searchers/Hit/SFX_Searcher_Melt_01";

			// Token: 0x040024DA RID: 9434
			public const string SFX_SEARCHER_MELT_02 = "Audio/SFX/Characters/Searchers/Hit/SFX_Searcher_Melt_02";

			// Token: 0x040024DB RID: 9435
			public const string SFX_SEARCHER_MELT_03 = "Audio/SFX/Characters/Searchers/Hit/SFX_Searcher_Melt_03";

			// Token: 0x040024DC RID: 9436
			public const string SFX_SEARCHERS_VOIICE_MOUTH_OPEN_01 = "Audio/SFX/Characters/Searchers/Idle/SFX_Searchers_Voiice_Mouth_Open_01";

			// Token: 0x040024DD RID: 9437
			public const string SFX_SEARCHERS_VOIICE_MOUTH_OPEN_02 = "Audio/SFX/Characters/Searchers/Idle/SFX_Searchers_Voiice_Mouth_Open_02";

			// Token: 0x040024DE RID: 9438
			public const string SFX_SEARCHERS_VOIICE_MOUTH_OPEN_03 = "Audio/SFX/Characters/Searchers/Idle/SFX_Searchers_Voiice_Mouth_Open_03";

			// Token: 0x040024DF RID: 9439
			public const string SFX_SEARCHERS_VOIICE_MOUTH_OPEN_04 = "Audio/SFX/Characters/Searchers/Idle/SFX_Searchers_Voiice_Mouth_Open_04";

			// Token: 0x040024E0 RID: 9440
			public const string SFX_SEARCHERS_VOIICE_MOUTH_OPEN_05 = "Audio/SFX/Characters/Searchers/Idle/SFX_Searchers_Voiice_Mouth_Open_05";

			// Token: 0x040024E1 RID: 9441
			public const string SFX_SEARCHERS_VOIICE_MOUTH_OPEN_06 = "Audio/SFX/Characters/Searchers/Idle/SFX_Searchers_Voiice_Mouth_Open_06";

			// Token: 0x040024E2 RID: 9442
			public const string SFX_SEARCHERS_VOIICE_MOUTH_OPEN_07 = "Audio/SFX/Characters/Searchers/Idle/SFX_Searchers_Voiice_Mouth_Open_07";

			// Token: 0x040024E3 RID: 9443
			public const string SFX_SEARCHERS_VOIICE_MOUTH_OPEN_08 = "Audio/SFX/Characters/Searchers/Idle/SFX_Searchers_Voiice_Mouth_Open_08";

			// Token: 0x040024E4 RID: 9444
			public const string SFX_SEARCHERS_VOIICE_MOUTH_OPEN_09 = "Audio/SFX/Characters/Searchers/Idle/SFX_Searchers_Voiice_Mouth_Open_09";

			// Token: 0x040024E5 RID: 9445
			public const string SFX_SEARCHERS_VOIICE_MOUTH_OPEN_10 = "Audio/SFX/Characters/Searchers/Idle/SFX_Searchers_Voiice_Mouth_Open_10";

			// Token: 0x040024E6 RID: 9446
			public const string CH_3_SWOLLENSEARCHERDIE = "Audio/SFX/Characters/SwollenSearchers/CH3_SWOLLEN_SEARCHER_DIE";

			// Token: 0x040024E7 RID: 9447
			public const string CH_3_SWOLLENSEARCHERHIT = "Audio/SFX/Characters/SwollenSearchers/CH3_SWOLLEN_SEARCHER_HIT";

			// Token: 0x040024E8 RID: 9448
			public const string CH_3_SWOLLENSEARCHERIDLE = "Audio/SFX/Characters/SwollenSearchers/CH3_SWOLLEN_SEARCHER_IDLE";

			// Token: 0x040024E9 RID: 9449
			public const string SFX_BOOK_01 = "Audio/SFX/Collectables/SFX_Book_01";

			// Token: 0x040024EA RID: 9450
			public const string SFX_BOOK_PICK_UP_VANISH_01 = "Audio/SFX/Collectables/SFX_Book_Pick_Up_Vanish_01";

			// Token: 0x040024EB RID: 9451
			public const string SFX_GEAR_01 = "Audio/SFX/Collectables/SFX_Gear_01";

			// Token: 0x040024EC RID: 9452
			public const string SFX_GEAR_PICK_UP_VANISH_01 = "Audio/SFX/Collectables/SFX_Gear_Pick_UP_Vanish_01";

			// Token: 0x040024ED RID: 9453
			public const string SFX_INK_JAR_01 = "Audio/SFX/Collectables/SFX_Ink_Jar_01";

			// Token: 0x040024EE RID: 9454
			public const string SFX_INK_JAR_PICK_UP_VANISH_01 = "Audio/SFX/Collectables/SFX_Ink_Jar_Pick_UP_Vanish_01";

			// Token: 0x040024EF RID: 9455
			public const string SFX_KEYS_PICKUP_01 = "Audio/SFX/Collectables/SFX_Keys_Pickup_01";

			// Token: 0x040024F0 RID: 9456
			public const string SFX_RECORD_01 = "Audio/SFX/Collectables/SFX_Record_01";

			// Token: 0x040024F1 RID: 9457
			public const string SFX_RECORD_PICK_UP_VANISH_01 = "Audio/SFX/Collectables/SFX_Record_Pick_UP_Vanish_01";

			// Token: 0x040024F2 RID: 9458
			public const string SFX_TOY_01 = "Audio/SFX/Collectables/SFX_Toy_01";

			// Token: 0x040024F3 RID: 9459
			public const string SFX_TOY_PICK_UP_VANISH_01 = "Audio/SFX/Collectables/SFX_Toy_Pick_UP_Vanish_01";

			// Token: 0x040024F4 RID: 9460
			public const string SFX_WRENCH_01 = "Audio/SFX/Collectables/SFX_Wrench_01";

			// Token: 0x040024F5 RID: 9461
			public const string SFX_WRENCH_PICK_UP_VANISH_01 = "Audio/SFX/Collectables/SFX_Wrench_Pick_UP_Vanish_01";

			// Token: 0x040024F6 RID: 9462
			public const string SFX_DOOR_GENERIC_CLOSE_01 = "Audio/SFX/Door/SFX_Door_Generic_Close_01";

			// Token: 0x040024F7 RID: 9463
			public const string SFX_DOOR_GENERIC_OPEN_01 = "Audio/SFX/Door/SFX_Door_Generic_Open_01";

			// Token: 0x040024F8 RID: 9464
			public const string SFX_DOOR_SLAM_01 = "Audio/SFX/Door/SFX_Door_Slam_01";

			// Token: 0x040024F9 RID: 9465
			public const string SFX_DOOR_UNLOCK_OPEN_CLOSE_01 = "Audio/SFX/Door/SFX_Door_Unlock_Open_Close_01";

			// Token: 0x040024FA RID: 9466
			public const string SFX_DOOR_UNLOCK_OPEN_CLOSE_02 = "Audio/SFX/Door/SFX_Door_Unlock_Open_Close_02";

			// Token: 0x040024FB RID: 9467
			public const string FOL_FOOTSTEPS_BENDY_WOOD_01 = "Audio/SFX/Footsteps/Bendy/Ink/FOL_Footsteps_Bendy_Wood_01";

			// Token: 0x040024FC RID: 9468
			public const string FOL_FOOTSTEPS_BENDY_WOOD_02 = "Audio/SFX/Footsteps/Bendy/Ink/FOL_Footsteps_Bendy_Wood_02";

			// Token: 0x040024FD RID: 9469
			public const string FOL_FOOTSTEPS_BENDY_WOOD_03 = "Audio/SFX/Footsteps/Bendy/Ink/FOL_Footsteps_Bendy_Wood_03";

			// Token: 0x040024FE RID: 9470
			public const string FOL_FOOTSTEPS_BENDY_WOOD_04 = "Audio/SFX/Footsteps/Bendy/Ink/FOL_Footsteps_Bendy_Wood_04";

			// Token: 0x040024FF RID: 9471
			public const string FOL_FOOTSTEPS_BENDY_WOOD_05 = "Audio/SFX/Footsteps/Bendy/Ink/FOL_Footsteps_Bendy_Wood_05";

			// Token: 0x04002500 RID: 9472
			public const string FOL_FOOTSTEPS_BENDY_WOOD_06 = "Audio/SFX/Footsteps/Bendy/Ink/FOL_Footsteps_Bendy_Wood_06";

			// Token: 0x04002501 RID: 9473
			public const string FOL_FOOTSTEPS_BENDY_WOOD_07 = "Audio/SFX/Footsteps/Bendy/Ink/FOL_Footsteps_Bendy_Wood_07";

			// Token: 0x04002502 RID: 9474
			public const string FOL_FOOTSTEPS_BENDY_WOOD_08 = "Audio/SFX/Footsteps/Bendy/Ink/FOL_Footsteps_Bendy_Wood_08";

			// Token: 0x04002503 RID: 9475
			public const string FOL_FOOTSTEPS_BENDY_WOOD_09 = "Audio/SFX/Footsteps/Bendy/Ink/FOL_Footsteps_Bendy_Wood_09";

			// Token: 0x04002504 RID: 9476
			public const string FOL_FOOTSTEPS_BENDY_WOOD_10 = "Audio/SFX/Footsteps/Bendy/Ink/FOL_Footsteps_Bendy_Wood_10";

			// Token: 0x04002505 RID: 9477
			public const string BENDY_NEW_FOOTSTEPS_01 = "Audio/SFX/Footsteps/Bendy/Loud/Bendy_NewFootsteps_01";

			// Token: 0x04002506 RID: 9478
			public const string BENDY_NEW_FOOTSTEPS_02 = "Audio/SFX/Footsteps/Bendy/Loud/Bendy_NewFootsteps_02";

			// Token: 0x04002507 RID: 9479
			public const string BENDY_NEW_FOOTSTEPS_03 = "Audio/SFX/Footsteps/Bendy/Loud/Bendy_NewFootsteps_03";

			// Token: 0x04002508 RID: 9480
			public const string BENDY_NEW_FOOTSTEPS_04 = "Audio/SFX/Footsteps/Bendy/Loud/Bendy_NewFootsteps_04";

			// Token: 0x04002509 RID: 9481
			public const string FOL_FOOTSTEPS_BORIS_WOOD_01 = "Audio/SFX/Footsteps/Boris/Wood/FOL_Footsteps_Boris_Wood_01";

			// Token: 0x0400250A RID: 9482
			public const string FOL_FOOTSTEPS_BORIS_WOOD_02 = "Audio/SFX/Footsteps/Boris/Wood/FOL_Footsteps_Boris_Wood_02";

			// Token: 0x0400250B RID: 9483
			public const string FOL_FOOTSTEPS_BORIS_WOOD_03 = "Audio/SFX/Footsteps/Boris/Wood/FOL_Footsteps_Boris_Wood_03";

			// Token: 0x0400250C RID: 9484
			public const string FOL_FOOTSTEPS_BORIS_WOOD_04 = "Audio/SFX/Footsteps/Boris/Wood/FOL_Footsteps_Boris_Wood_04";

			// Token: 0x0400250D RID: 9485
			public const string FOL_FOOTSTEPS_BORIS_WOOD_05 = "Audio/SFX/Footsteps/Boris/Wood/FOL_Footsteps_Boris_Wood_05";

			// Token: 0x0400250E RID: 9486
			public const string FOL_FOOTSTEPS_BORIS_WOOD_06 = "Audio/SFX/Footsteps/Boris/Wood/FOL_Footsteps_Boris_Wood_06";

			// Token: 0x0400250F RID: 9487
			public const string FOL_FOOTSTEPS_BORIS_WOOD_07 = "Audio/SFX/Footsteps/Boris/Wood/FOL_Footsteps_Boris_Wood_07";

			// Token: 0x04002510 RID: 9488
			public const string FOL_FOOTSTEPS_BORIS_WOOD_08 = "Audio/SFX/Footsteps/Boris/Wood/FOL_Footsteps_Boris_Wood_08";

			// Token: 0x04002511 RID: 9489
			public const string FOL_FOOTSTEPS_BORIS_WOOD_09 = "Audio/SFX/Footsteps/Boris/Wood/FOL_Footsteps_Boris_Wood_09";

			// Token: 0x04002512 RID: 9490
			public const string FOL_FOOTSTEPS_BORIS_WOOD_10 = "Audio/SFX/Footsteps/Boris/Wood/FOL_Footsteps_Boris_Wood_10";

			// Token: 0x04002513 RID: 9491
			public const string CH_3SFXPROJECTIONISTDRYFOOTSTEP_01 = "Audio/SFX/Footsteps/ProjectionistDry/ch3_sfx_projectionist_dryfootstep01";

			// Token: 0x04002514 RID: 9492
			public const string CH_3SFXPROJECTIONISTDRYFOOTSTEP_02 = "Audio/SFX/Footsteps/ProjectionistDry/ch3_sfx_projectionist_dryfootstep02";

			// Token: 0x04002515 RID: 9493
			public const string CH_3SFXPROJECTIONISTDRYFOOTSTEP_03 = "Audio/SFX/Footsteps/ProjectionistDry/ch3_sfx_projectionist_dryfootstep03";

			// Token: 0x04002516 RID: 9494
			public const string CH_3SFXPROJECTIONISTDRYFOOTSTEP_04 = "Audio/SFX/Footsteps/ProjectionistDry/ch3_sfx_projectionist_dryfootstep04";

			// Token: 0x04002517 RID: 9495
			public const string CH_3SFXPROJECTIONISTDRYFOOTSTEP_05 = "Audio/SFX/Footsteps/ProjectionistDry/ch3_sfx_projectionist_dryfootstep05";

			// Token: 0x04002518 RID: 9496
			public const string CH_3SFXPROJECTIONISTDRYFOOTSTEP_06 = "Audio/SFX/Footsteps/ProjectionistDry/ch3_sfx_projectionist_dryfootstep06";

			// Token: 0x04002519 RID: 9497
			public const string CH_3SFXPROJECTIONISTDRYFOOTSTEP_07 = "Audio/SFX/Footsteps/ProjectionistDry/ch3_sfx_projectionist_dryfootstep07";

			// Token: 0x0400251A RID: 9498
			public const string CH_3SFXPROJECTIONISTDRYFOOTSTEP_08 = "Audio/SFX/Footsteps/ProjectionistDry/ch3_sfx_projectionist_dryfootstep08";

			// Token: 0x0400251B RID: 9499
			public const string CH_3SFXPROJECTIONISTDRYFOOTSTEP_09 = "Audio/SFX/Footsteps/ProjectionistDry/ch3_sfx_projectionist_dryfootstep09";

			// Token: 0x0400251C RID: 9500
			public const string CH_3SFXPROJECTIONISTDRYFOOTSTEP_10 = "Audio/SFX/Footsteps/ProjectionistDry/ch3_sfx_projectionist_dryfootstep10";

			// Token: 0x0400251D RID: 9501
			public const string CH_3SFXPROJECTIONISTWETFOOTSTEP_01 = "Audio/SFX/Footsteps/ProjectionistWater/ch3_sfx_projectionist_wetfootstep01";

			// Token: 0x0400251E RID: 9502
			public const string CH_3SFXPROJECTIONISTWETFOOTSTEP_02 = "Audio/SFX/Footsteps/ProjectionistWater/ch3_sfx_projectionist_wetfootstep02";

			// Token: 0x0400251F RID: 9503
			public const string CH_3SFXPROJECTIONISTWETFOOTSTEP_03 = "Audio/SFX/Footsteps/ProjectionistWater/ch3_sfx_projectionist_wetfootstep03";

			// Token: 0x04002520 RID: 9504
			public const string CH_3SFXPROJECTIONISTWETFOOTSTEP_04 = "Audio/SFX/Footsteps/ProjectionistWater/ch3_sfx_projectionist_wetfootstep04";

			// Token: 0x04002521 RID: 9505
			public const string CH_3SFXPROJECTIONISTWETFOOTSTEP_05 = "Audio/SFX/Footsteps/ProjectionistWater/ch3_sfx_projectionist_wetfootstep05";

			// Token: 0x04002522 RID: 9506
			public const string CH_3SFXPROJECTIONISTWETFOOTSTEP_06 = "Audio/SFX/Footsteps/ProjectionistWater/ch3_sfx_projectionist_wetfootstep06";

			// Token: 0x04002523 RID: 9507
			public const string CH_3SFXPROJECTIONISTWETFOOTSTEP_07 = "Audio/SFX/Footsteps/ProjectionistWater/ch3_sfx_projectionist_wetfootstep07";

			// Token: 0x04002524 RID: 9508
			public const string CH_3SFXPROJECTIONISTWETFOOTSTEP_08 = "Audio/SFX/Footsteps/ProjectionistWater/ch3_sfx_projectionist_wetfootstep08";

			// Token: 0x04002525 RID: 9509
			public const string CH_3SFXPROJECTIONISTWETFOOTSTEP_09 = "Audio/SFX/Footsteps/ProjectionistWater/ch3_sfx_projectionist_wetfootstep09";

			// Token: 0x04002526 RID: 9510
			public const string CH_3SFXPROJECTIONISTWETFOOTSTEP_10 = "Audio/SFX/Footsteps/ProjectionistWater/ch3_sfx_projectionist_wetfootstep10";

			// Token: 0x04002527 RID: 9511
			public const string FOL_FOOTSTEPS_SAMMY_WOOD_01 = "Audio/SFX/Footsteps/Sammy/Wood/FOL_Footsteps_Sammy_Wood_01";

			// Token: 0x04002528 RID: 9512
			public const string FOL_FOOTSTEPS_SAMMY_WOOD_02 = "Audio/SFX/Footsteps/Sammy/Wood/FOL_Footsteps_Sammy_Wood_02";

			// Token: 0x04002529 RID: 9513
			public const string FOL_FOOTSTEPS_SAMMY_WOOD_03 = "Audio/SFX/Footsteps/Sammy/Wood/FOL_Footsteps_Sammy_Wood_03";

			// Token: 0x0400252A RID: 9514
			public const string FOL_FOOTSTEPS_SAMMY_WOOD_04 = "Audio/SFX/Footsteps/Sammy/Wood/FOL_Footsteps_Sammy_Wood_04";

			// Token: 0x0400252B RID: 9515
			public const string FOL_FOOTSTEPS_SAMMY_WOOD_05 = "Audio/SFX/Footsteps/Sammy/Wood/FOL_Footsteps_Sammy_Wood_05";

			// Token: 0x0400252C RID: 9516
			public const string FOL_FOOTSTEPS_SAMMY_WOOD_06 = "Audio/SFX/Footsteps/Sammy/Wood/FOL_Footsteps_Sammy_Wood_06";

			// Token: 0x0400252D RID: 9517
			public const string FOL_FOOTSTEPS_SAMMY_WOOD_07 = "Audio/SFX/Footsteps/Sammy/Wood/FOL_Footsteps_Sammy_Wood_07";

			// Token: 0x0400252E RID: 9518
			public const string FOL_FOOTSTEPS_SAMMY_WOOD_08 = "Audio/SFX/Footsteps/Sammy/Wood/FOL_Footsteps_Sammy_Wood_08";

			// Token: 0x0400252F RID: 9519
			public const string FOL_FOOTSTEPS_SAMMY_WOOD_09 = "Audio/SFX/Footsteps/Sammy/Wood/FOL_Footsteps_Sammy_Wood_09";

			// Token: 0x04002530 RID: 9520
			public const string FOL_FOOTSTEPS_SAMMY_WOOD_10 = "Audio/SFX/Footsteps/Sammy/Wood/FOL_Footsteps_Sammy_Wood_10";

			// Token: 0x04002531 RID: 9521
			public const string SFX_BUTTON_PUSH_01 = "Audio/SFX/GenericButtons/SFX_Button_Push_01";

			// Token: 0x04002532 RID: 9522
			public const string SFX_BUTTON_PUSH_02 = "Audio/SFX/GenericButtons/SFX_Button_Push_02";

			// Token: 0x04002533 RID: 9523
			public const string SFX_BUTTON_PUSH_03 = "Audio/SFX/GenericButtons/SFX_Button_Push_03";

			// Token: 0x04002534 RID: 9524
			public const string SFX_INK_GUN_EMPTY = "Audio/SFX/Gun/SFX_Ink_Gun_Empty";

			// Token: 0x04002535 RID: 9525
			public const string SFX_INK_GUN_IMPACT = "Audio/SFX/Gun/SFX_Ink_Gun_Impact";

			// Token: 0x04002536 RID: 9526
			public const string SFX_INK_GUN_RELOAD = "Audio/SFX/Gun/SFX_Ink_Gun_Reload";

			// Token: 0x04002537 RID: 9527
			public const string SFX_INK_SHOOT = "Audio/SFX/Gun/SFX_Ink_Shoot";

			// Token: 0x04002538 RID: 9528
			public const string HENRY_DEAD_01_LOUD = "Audio/SFX/Henry/Death/HenryDead01LOUD";

			// Token: 0x04002539 RID: 9529
			public const string HENRY_DEAD_02_LOUD = "Audio/SFX/Henry/Death/HenryDead02LOUD";

			// Token: 0x0400253A RID: 9530
			public const string HENRY_DEAD_03_LOUD = "Audio/SFX/Henry/Death/HenryDead03LOUD";

			// Token: 0x0400253B RID: 9531
			public const string HENRY_HURT_01_LOUD = "Audio/SFX/Henry/Hurt/HenryHurt01LOUD";

			// Token: 0x0400253C RID: 9532
			public const string HENRY_HURT_02_LOUD = "Audio/SFX/Henry/Hurt/HenryHurt02LOUD";

			// Token: 0x0400253D RID: 9533
			public const string HENRY_HURT_03_LOUD = "Audio/SFX/Henry/Hurt/HenryHurt03LOUD";

			// Token: 0x0400253E RID: 9534
			public const string SFX_BANJO_NOTE_01 = "Audio/SFX/Instruments/Banjo/SFX_Banjo_Note_01";

			// Token: 0x0400253F RID: 9535
			public const string SFX_BANJO_NOTE_02 = "Audio/SFX/Instruments/Banjo/SFX_Banjo_Note_02";

			// Token: 0x04002540 RID: 9536
			public const string SFX_BANJO_NOTE_03 = "Audio/SFX/Instruments/Banjo/SFX_Banjo_Note_03";

			// Token: 0x04002541 RID: 9537
			public const string SFX_BANJO_NOTE_04 = "Audio/SFX/Instruments/Banjo/SFX_Banjo_Note_04";

			// Token: 0x04002542 RID: 9538
			public const string SFX_BANJO_NOTE_05 = "Audio/SFX/Instruments/Banjo/SFX_Banjo_Note_05";

			// Token: 0x04002543 RID: 9539
			public const string SFX_BANJO_NOTE_06 = "Audio/SFX/Instruments/Banjo/SFX_Banjo_Note_06";

			// Token: 0x04002544 RID: 9540
			public const string SFX_BANJO_NOTE_07 = "Audio/SFX/Instruments/Banjo/SFX_Banjo_Note_07";

			// Token: 0x04002545 RID: 9541
			public const string SFX_BANJO_NOTE_08 = "Audio/SFX/Instruments/Banjo/SFX_Banjo_Note_08";

			// Token: 0x04002546 RID: 9542
			public const string SFX_BANJO_NOTE_09 = "Audio/SFX/Instruments/Banjo/SFX_Banjo_Note_09";

			// Token: 0x04002547 RID: 9543
			public const string SFX_BANJO_NOTE_10 = "Audio/SFX/Instruments/Banjo/SFX_Banjo_Note_10";

			// Token: 0x04002548 RID: 9544
			public const string SFX_BASS_NOTE_01 = "Audio/SFX/Instruments/BassFiddle/SFX_Bass_Note_01";

			// Token: 0x04002549 RID: 9545
			public const string SFX_BASS_NOTE_02 = "Audio/SFX/Instruments/BassFiddle/SFX_Bass_Note_02";

			// Token: 0x0400254A RID: 9546
			public const string SFX_BASS_NOTE_03 = "Audio/SFX/Instruments/BassFiddle/SFX_Bass_Note_03";

			// Token: 0x0400254B RID: 9547
			public const string SFX_BASS_NOTE_04 = "Audio/SFX/Instruments/BassFiddle/SFX_Bass_Note_04";

			// Token: 0x0400254C RID: 9548
			public const string SFX_BASS_NOTE_05 = "Audio/SFX/Instruments/BassFiddle/SFX_Bass_Note_05";

			// Token: 0x0400254D RID: 9549
			public const string SFX_BASS_NOTE_06 = "Audio/SFX/Instruments/BassFiddle/SFX_Bass_Note_06";

			// Token: 0x0400254E RID: 9550
			public const string SFX_BASS_NOTE_07 = "Audio/SFX/Instruments/BassFiddle/SFX_Bass_Note_07";

			// Token: 0x0400254F RID: 9551
			public const string SFX_BASS_NOTE_08 = "Audio/SFX/Instruments/BassFiddle/SFX_Bass_Note_08";

			// Token: 0x04002550 RID: 9552
			public const string SFX_BASS_NOTE_09 = "Audio/SFX/Instruments/BassFiddle/SFX_Bass_Note_09";

			// Token: 0x04002551 RID: 9553
			public const string SFX_BASS_NOTE_10 = "Audio/SFX/Instruments/BassFiddle/SFX_Bass_Note_10";

			// Token: 0x04002552 RID: 9554
			public const string SFX_DRUM_NOTE_01 = "Audio/SFX/Instruments/Drum/SFX_Drum_Note_01";

			// Token: 0x04002553 RID: 9555
			public const string SFX_DRUM_NOTE_02 = "Audio/SFX/Instruments/Drum/SFX_Drum_Note_02";

			// Token: 0x04002554 RID: 9556
			public const string SFX_DRUM_NOTE_03 = "Audio/SFX/Instruments/Drum/SFX_Drum_Note_03";

			// Token: 0x04002555 RID: 9557
			public const string SFX_DRUM_NOTE_04 = "Audio/SFX/Instruments/Drum/SFX_Drum_Note_04";

			// Token: 0x04002556 RID: 9558
			public const string SFX_DRUM_NOTE_05 = "Audio/SFX/Instruments/Drum/SFX_Drum_Note_05";

			// Token: 0x04002557 RID: 9559
			public const string SFX_DRUM_NOTE_06 = "Audio/SFX/Instruments/Drum/SFX_Drum_Note_06";

			// Token: 0x04002558 RID: 9560
			public const string SFX_DRUM_NOTE_07 = "Audio/SFX/Instruments/Drum/SFX_Drum_Note_07";

			// Token: 0x04002559 RID: 9561
			public const string SFX_DRUM_NOTE_08 = "Audio/SFX/Instruments/Drum/SFX_Drum_Note_08";

			// Token: 0x0400255A RID: 9562
			public const string SFX_DRUM_NOTE_09 = "Audio/SFX/Instruments/Drum/SFX_Drum_Note_09";

			// Token: 0x0400255B RID: 9563
			public const string SFX_DRUM_NOTE_10 = "Audio/SFX/Instruments/Drum/SFX_Drum_Note_10";

			// Token: 0x0400255C RID: 9564
			public const string SFX_PIANOO_NOTE_01 = "Audio/SFX/Instruments/Piano/SFX_Pianoo_Note_01";

			// Token: 0x0400255D RID: 9565
			public const string SFX_PIANOO_NOTE_02 = "Audio/SFX/Instruments/Piano/SFX_Pianoo_Note_02";

			// Token: 0x0400255E RID: 9566
			public const string SFX_PIANOO_NOTE_03 = "Audio/SFX/Instruments/Piano/SFX_Pianoo_Note_03";

			// Token: 0x0400255F RID: 9567
			public const string SFX_PIANOO_NOTE_04 = "Audio/SFX/Instruments/Piano/SFX_Pianoo_Note_04";

			// Token: 0x04002560 RID: 9568
			public const string SFX_PIANOO_NOTE_05 = "Audio/SFX/Instruments/Piano/SFX_Pianoo_Note_05";

			// Token: 0x04002561 RID: 9569
			public const string SFX_PIANOO_NOTE_06 = "Audio/SFX/Instruments/Piano/SFX_Pianoo_Note_06";

			// Token: 0x04002562 RID: 9570
			public const string SFX_PIANOO_NOTE_07 = "Audio/SFX/Instruments/Piano/SFX_Pianoo_Note_07";

			// Token: 0x04002563 RID: 9571
			public const string SFX_PIANOO_NOTE_08 = "Audio/SFX/Instruments/Piano/SFX_Pianoo_Note_08";

			// Token: 0x04002564 RID: 9572
			public const string SFX_PIANOO_NOTE_09 = "Audio/SFX/Instruments/Piano/SFX_Pianoo_Note_09";

			// Token: 0x04002565 RID: 9573
			public const string SFX_PIANOO_NOTE_10 = "Audio/SFX/Instruments/Piano/SFX_Pianoo_Note_10";

			// Token: 0x04002566 RID: 9574
			public const string SFX_ORGAN_SCREAM_NOTE_01 = "Audio/SFX/Instruments/PipeOrgan/SFX_Organ_Scream_Note_01";

			// Token: 0x04002567 RID: 9575
			public const string SFX_ORGAN_SCREAM_NOTE_02 = "Audio/SFX/Instruments/PipeOrgan/SFX_Organ_Scream_Note_02";

			// Token: 0x04002568 RID: 9576
			public const string SFX_ORGAN_SCREAM_NOTE_03 = "Audio/SFX/Instruments/PipeOrgan/SFX_Organ_Scream_Note_03";

			// Token: 0x04002569 RID: 9577
			public const string SFX_ORGAN_SCREAM_NOTE_04 = "Audio/SFX/Instruments/PipeOrgan/SFX_Organ_Scream_Note_04";

			// Token: 0x0400256A RID: 9578
			public const string SFX_ORGAN_SCREAM_NOTE_05 = "Audio/SFX/Instruments/PipeOrgan/SFX_Organ_Scream_Note_05";

			// Token: 0x0400256B RID: 9579
			public const string SFX_ORGAN_SCREAM_NOTE_06 = "Audio/SFX/Instruments/PipeOrgan/SFX_Organ_Scream_Note_06";

			// Token: 0x0400256C RID: 9580
			public const string SFX_ORGAN_SCREAM_NOTE_07 = "Audio/SFX/Instruments/PipeOrgan/SFX_Organ_Scream_Note_07";

			// Token: 0x0400256D RID: 9581
			public const string SFX_ORGAN_SCREAM_NOTE_08 = "Audio/SFX/Instruments/PipeOrgan/SFX_Organ_Scream_Note_08";

			// Token: 0x0400256E RID: 9582
			public const string SFX_ORGAN_SCREAM_NOTE_09 = "Audio/SFX/Instruments/PipeOrgan/SFX_Organ_Scream_Note_09";

			// Token: 0x0400256F RID: 9583
			public const string SFX_ORGAN_SCREAM_NOTE_10 = "Audio/SFX/Instruments/PipeOrgan/SFX_Organ_Scream_Note_10";

			// Token: 0x04002570 RID: 9584
			public const string SFX_VIOLIN_NOTE_01 = "Audio/SFX/Instruments/Violin/SFX_Violin_Note_01";

			// Token: 0x04002571 RID: 9585
			public const string SFX_VIOLIN_NOTE_02 = "Audio/SFX/Instruments/Violin/SFX_Violin_Note_02";

			// Token: 0x04002572 RID: 9586
			public const string SFX_VIOLIN_NOTE_03 = "Audio/SFX/Instruments/Violin/SFX_Violin_Note_03";

			// Token: 0x04002573 RID: 9587
			public const string SFX_VIOLIN_NOTE_04 = "Audio/SFX/Instruments/Violin/SFX_Violin_Note_04";

			// Token: 0x04002574 RID: 9588
			public const string SFX_VIOLIN_NOTE_05 = "Audio/SFX/Instruments/Violin/SFX_Violin_Note_05";

			// Token: 0x04002575 RID: 9589
			public const string SFX_VIOLIN_NOTE_06 = "Audio/SFX/Instruments/Violin/SFX_Violin_Note_06";

			// Token: 0x04002576 RID: 9590
			public const string SFX_VIOLIN_NOTE_07 = "Audio/SFX/Instruments/Violin/SFX_Violin_Note_07";

			// Token: 0x04002577 RID: 9591
			public const string SFX_VIOLIN_NOTE_08 = "Audio/SFX/Instruments/Violin/SFX_Violin_Note_08";

			// Token: 0x04002578 RID: 9592
			public const string SFX_VIOLIN_NOTE_09 = "Audio/SFX/Instruments/Violin/SFX_Violin_Note_09";

			// Token: 0x04002579 RID: 9593
			public const string SFX_VIOLIN_NOTE_10 = "Audio/SFX/Instruments/Violin/SFX_Violin_Note_10";

			// Token: 0x0400257A RID: 9594
			public const string SFX_LIFT_ARRIVE = "Audio/SFX/Lift/SFX_Lift_Arrive";

			// Token: 0x0400257B RID: 9595
			public const string SFX_LIFT_DEPART = "Audio/SFX/Lift/SFX_Lift_Depart";

			// Token: 0x0400257C RID: 9596
			public const string SFX_LIFT_DING = "Audio/SFX/Lift/SFX_Lift_Ding";

			// Token: 0x0400257D RID: 9597
			public const string SFX_LIFT_LOOP = "Audio/SFX/Lift/SFX_Lift_Loop";

			// Token: 0x0400257E RID: 9598
			public const string SFX_GULP_SOUP_01 = "Audio/SFX/Soup/SFX_Gulp_Soup_01";

			// Token: 0x0400257F RID: 9599
			public const string SFX_GULP_SOUP_02 = "Audio/SFX/Soup/SFX_Gulp_Soup_02";

			// Token: 0x04002580 RID: 9600
			public const string SFX_GULP_SOUP_03 = "Audio/SFX/Soup/SFX_Gulp_Soup_03";

			// Token: 0x04002581 RID: 9601
			public const string SFX_GULP_SOUP_04 = "Audio/SFX/Soup/SFX_Gulp_Soup_04";

			// Token: 0x04002582 RID: 9602
			public const string SFX_GULP_SOUP_05 = "Audio/SFX/Soup/SFX_Gulp_Soup_05";

			// Token: 0x04002583 RID: 9603
			public const string SFX_GULP_SOUP_06 = "Audio/SFX/Soup/SFX_Gulp_Soup_06";

			// Token: 0x04002584 RID: 9604
			public const string SFX_GULP_SOUP_07 = "Audio/SFX/Soup/SFX_Gulp_Soup_07";

			// Token: 0x04002585 RID: 9605
			public const string SFX_AXE_PICK_UP_01 = "Audio/SFX/Weapons/Axe/SFX_Axe_Pick_Up_01";

			// Token: 0x04002586 RID: 9606
			public const string SFX_AXE_SWING_01 = "Audio/SFX/Weapons/Axe/SFX_Axe_Swing_01";

			// Token: 0x04002587 RID: 9607
			public const string SFX_AXE_SWING_02 = "Audio/SFX/Weapons/Axe/SFX_Axe_Swing_02";

			// Token: 0x04002588 RID: 9608
			public const string SFX_AXE_SWING_03 = "Audio/SFX/Weapons/Axe/SFX_Axe_Swing_03";

			// Token: 0x04002589 RID: 9609
			public const string SFX_AXE_SWING_04 = "Audio/SFX/Weapons/Axe/SFX_Axe_Swing_04";

			// Token: 0x0400258A RID: 9610
			public const string SFX_AXE_SWING_05 = "Audio/SFX/Weapons/Axe/SFX_Axe_Swing_05";

			// Token: 0x0400258B RID: 9611
			public const string SFX_AXE_SWING_06 = "Audio/SFX/Weapons/Axe/SFX_Axe_Swing_06";

			// Token: 0x0400258C RID: 9612
			public const string SFX_AXE_SWING_07 = "Audio/SFX/Weapons/Axe/SFX_Axe_Swing_07";

			// Token: 0x0400258D RID: 9613
			public const string SFX_AXE_SWING_08 = "Audio/SFX/Weapons/Axe/SFX_Axe_Swing_08";

			// Token: 0x0400258E RID: 9614
			public const string SFX_AXE_WOOD_HIT_CRACK_01 = "Audio/SFX/Weapons/Axe/SFX_Axe_Wood_Hit_Crack_01";

			// Token: 0x0400258F RID: 9615
			public const string SFX_AXE_WOOD_HIT_CRACK_02 = "Audio/SFX/Weapons/Axe/SFX_Axe_Wood_Hit_Crack_02";

			// Token: 0x04002590 RID: 9616
			public const string SFX_AXE_WOOD_HIT_CRACK_03 = "Audio/SFX/Weapons/Axe/SFX_Axe_Wood_Hit_Crack_03";

			// Token: 0x04002591 RID: 9617
			public const string SFX_AXE_WOOD_HIT_CRACK_04 = "Audio/SFX/Weapons/Axe/SFX_Axe_Wood_Hit_Crack_04";

			// Token: 0x04002592 RID: 9618
			public const string SFX_AXE_WOOD_HIT_CRACK_05 = "Audio/SFX/Weapons/Axe/SFX_Axe_Wood_Hit_Crack_05";

			// Token: 0x04002593 RID: 9619
			public const string SFX_AXE_WOOD_HIT_CRACK_06 = "Audio/SFX/Weapons/Axe/SFX_Axe_Wood_Hit_Crack_06";

			// Token: 0x04002594 RID: 9620
			public const string SFX_AXE_WOOD_HIT_CRACK_07 = "Audio/SFX/Weapons/Axe/SFX_Axe_Wood_Hit_Crack_07";

			// Token: 0x04002595 RID: 9621
			public const string SFX_AXE_WOOD_HIT_CRACK_08 = "Audio/SFX/Weapons/Axe/SFX_Axe_Wood_Hit_Crack_08";

			// Token: 0x04002596 RID: 9622
			public const string SFX_AXE_HIT_01 = "Audio/SFX/Weapons/Axe/Hit/SFX_Axe_Hit_01";

			// Token: 0x04002597 RID: 9623
			public const string SFX_AXE_HIT_02 = "Audio/SFX/Weapons/Axe/Hit/SFX_Axe_Hit_02";

			// Token: 0x04002598 RID: 9624
			public const string SFX_AXE_HIT_03 = "Audio/SFX/Weapons/Axe/Hit/SFX_Axe_Hit_03";

			// Token: 0x04002599 RID: 9625
			public const string SFX_AXE_HIT_04 = "Audio/SFX/Weapons/Axe/Hit/SFX_Axe_Hit_04";

			// Token: 0x0400259A RID: 9626
			public const string SFX_AXE_HIT_05 = "Audio/SFX/Weapons/Axe/Hit/SFX_Axe_Hit_05";

			// Token: 0x0400259B RID: 9627
			public const string SFX_AXE_HIT_06 = "Audio/SFX/Weapons/Axe/Hit/SFX_Axe_Hit_06";

			// Token: 0x0400259C RID: 9628
			public const string SFX_AXE_HIT_07 = "Audio/SFX/Weapons/Axe/Hit/SFX_Axe_Hit_07";

			// Token: 0x0400259D RID: 9629
			public const string SFX_AXE_HIT_08 = "Audio/SFX/Weapons/Axe/Hit/SFX_Axe_Hit_08";

			// Token: 0x0400259E RID: 9630
			public const string SFX_GENERIC_WEAPON_WHOOSH_01 = "Audio/SFX/Weapons/Generic/SFX_Generic_Weapon_Whoosh_01";

			// Token: 0x0400259F RID: 9631
			public const string SFX_GENERIC_WEAPON_WHOOSH_02 = "Audio/SFX/Weapons/Generic/SFX_Generic_Weapon_Whoosh_02";

			// Token: 0x040025A0 RID: 9632
			public const string SFX_GENERIC_WEAPON_WHOOSH_03 = "Audio/SFX/Weapons/Generic/SFX_Generic_Weapon_Whoosh_03";

			// Token: 0x040025A1 RID: 9633
			public const string SFX_GENT_PIPE_HIT_01 = "Audio/SFX/Weapons/GentPipe/SFX_GentPipe_Hit_01";

			// Token: 0x040025A2 RID: 9634
			public const string SFX_GENT_PIPE_HIT_02 = "Audio/SFX/Weapons/GentPipe/SFX_GentPipe_Hit_02";

			// Token: 0x040025A3 RID: 9635
			public const string SFX_GENT_PIPE_HIT_03 = "Audio/SFX/Weapons/GentPipe/SFX_GentPipe_Hit_03";

			// Token: 0x040025A4 RID: 9636
			public const string SFX_GENT_PIPE_HIT_04 = "Audio/SFX/Weapons/GentPipe/SFX_GentPipe_Hit_04";

			// Token: 0x040025A5 RID: 9637
			public const string SFX_GENT_PIPE_HIT_05 = "Audio/SFX/Weapons/GentPipe/SFX_GentPipe_Hit_05";

			// Token: 0x040025A6 RID: 9638
			public const string SFX_GENT_PIPE_HIT_06 = "Audio/SFX/Weapons/GentPipe/SFX_GentPipe_Hit_06";

			// Token: 0x040025A7 RID: 9639
			public const string SFX_GENT_PIPE_HIT_07 = "Audio/SFX/Weapons/GentPipe/SFX_GentPipe_Hit_07";

			// Token: 0x040025A8 RID: 9640
			public const string SFX_GENT_PIPE_HIT_08 = "Audio/SFX/Weapons/GentPipe/SFX_GentPipe_Hit_08";

			// Token: 0x040025A9 RID: 9641
			public const string SFX_GENT_PIPE_PICKUP = "Audio/SFX/Weapons/GentPipe/SFX_GentPipe_Pickup";

			// Token: 0x040025AA RID: 9642
			public const string CH_3SFSXENEMYBEINGHIT_01LOUD = "Audio/SFX/Weapons/HitEnemy/CH3_sfsx_enemybeinghit01-loud";

			// Token: 0x040025AB RID: 9643
			public const string CH_3SFSXENEMYBEINGHIT_02LOUD = "Audio/SFX/Weapons/HitEnemy/CH3_sfsx_enemybeinghit02-loud";

			// Token: 0x040025AC RID: 9644
			public const string CH_3SFSXENEMYBEINGHIT_03LOUD = "Audio/SFX/Weapons/HitEnemy/CH3_sfsx_enemybeinghit03-loud";

			// Token: 0x040025AD RID: 9645
			public const string SF_XWEAPON_SYRINGE_HIT_01 = "Audio/SFX/Weapons/InkTool/SFX_weapon_Syringe_Hit01";

			// Token: 0x040025AE RID: 9646
			public const string SF_XWEAPON_SYRINGE_HIT_02 = "Audio/SFX/Weapons/InkTool/SFX_weapon_Syringe_Hit02";

			// Token: 0x040025AF RID: 9647
			public const string SF_XWEAPON_SYRINGE_HIT_03 = "Audio/SFX/Weapons/InkTool/SFX_weapon_Syringe_Hit03";

			// Token: 0x040025B0 RID: 9648
			public const string SF_XWEAPON_SYRINGE_HIT_04 = "Audio/SFX/Weapons/InkTool/SFX_weapon_Syringe_Hit04";

			// Token: 0x040025B1 RID: 9649
			public const string SF_XWEAPON_SYRINGE_HIT_05 = "Audio/SFX/Weapons/InkTool/SFX_weapon_Syringe_Hit05";

			// Token: 0x040025B2 RID: 9650
			public const string SF_XWEAPON_SYRINGE_HIT_06 = "Audio/SFX/Weapons/InkTool/SFX_weapon_Syringe_Hit06";

			// Token: 0x040025B3 RID: 9651
			public const string SF_XWEAPON_SYRINGE_PICKUP = "Audio/SFX/Weapons/InkTool/SFX_weapon_Syringe_Pickup";

			// Token: 0x040025B4 RID: 9652
			public const string SF_XWEAPON_PLUNGER_HIT_01 = "Audio/SFX/Weapons/Plunger/SFX_weapon_Plunger_Hit01";

			// Token: 0x040025B5 RID: 9653
			public const string SF_XWEAPON_PLUNGER_HIT_02 = "Audio/SFX/Weapons/Plunger/SFX_weapon_Plunger_Hit02";

			// Token: 0x040025B6 RID: 9654
			public const string SF_XWEAPON_PLUNGER_HIT_03 = "Audio/SFX/Weapons/Plunger/SFX_weapon_Plunger_Hit03";

			// Token: 0x040025B7 RID: 9655
			public const string SF_XWEAPON_PLUNGER_HIT_04 = "Audio/SFX/Weapons/Plunger/SFX_weapon_Plunger_Hit04";

			// Token: 0x040025B8 RID: 9656
			public const string SF_XWEAPON_PLUNGER_HIT_05 = "Audio/SFX/Weapons/Plunger/SFX_weapon_Plunger_Hit05";

			// Token: 0x040025B9 RID: 9657
			public const string SF_XWEAPON_PLUNGER_HIT_06 = "Audio/SFX/Weapons/Plunger/SFX_weapon_Plunger_Hit06";

			// Token: 0x040025BA RID: 9658
			public const string SF_XWEAPON_PLUNGER_PICKUP = "Audio/SFX/Weapons/Plunger/SFX_weapon_Plunger_Pickup";

			// Token: 0x040025BB RID: 9659
			public const string SF_XWEAPON_WRENCH_HIT_01 = "Audio/SFX/Weapons/Wrench/SFX_weapon_Wrench_Hit01";

			// Token: 0x040025BC RID: 9660
			public const string SF_XWEAPON_WRENCH_HIT_02 = "Audio/SFX/Weapons/Wrench/SFX_weapon_Wrench_Hit02";

			// Token: 0x040025BD RID: 9661
			public const string SF_XWEAPON_WRENCH_HIT_03 = "Audio/SFX/Weapons/Wrench/SFX_weapon_Wrench_Hit03";

			// Token: 0x040025BE RID: 9662
			public const string SF_XWEAPON_WRENCH_HIT_04 = "Audio/SFX/Weapons/Wrench/SFX_weapon_Wrench_Hit04";

			// Token: 0x040025BF RID: 9663
			public const string SF_XWEAPON_WRENCH_HIT_05 = "Audio/SFX/Weapons/Wrench/SFX_weapon_Wrench_Hit05";

			// Token: 0x040025C0 RID: 9664
			public const string SF_XWEAPON_WRENCH_HIT_06 = "Audio/SFX/Weapons/Wrench/SFX_weapon_Wrench_Hit06";

			// Token: 0x040025C1 RID: 9665
			public const string SF_XWEAPON_WRENCH_PICKUP = "Audio/SFX/Weapons/Wrench/SFX_weapon_Wrench_Pickup";

			// Token: 0x040025C2 RID: 9666
			public const string SFXSAFESGOINGCRAZYLOOP = "Audio/TEMP/sfx_safes_going_crazy_loop";

			// Token: 0x040025C3 RID: 9667
			public const string TEMPDOOR = "Audio/TEMP/temp_door";

			// Token: 0x040025C4 RID: 9668
			public const string DIA_SAMMY_01 = "Audio/DIA/CH2/Sammy/DIA_Sammy_01";

			// Token: 0x040025C5 RID: 9669
			public const string EASTER_EGG_DA_GAMES_BUILD_OUR_MACHINE = "Audio/EasterEggs/EasterEggDAGamesBuildOurMachine";

			// Token: 0x040025C6 RID: 9670
			public const string EASTER_EGG_KYLE_BENDY_SONG = "Audio/EasterEggs/EasterEggKyleBendySong";

			// Token: 0x040025C7 RID: 9671
			public const string MUS_DRAWN_TO_DARKNESS = "Audio/MUS/CH1/MUS_DrawnToDarkness";

			// Token: 0x040025C8 RID: 9672
			public const string MUS_HELLFIRE_FOLLIES = "Audio/MUS/CH1/MUS_Hellfire_Follies";

			// Token: 0x040025C9 RID: 9673
			public const string MUS_TITLE_MUSIC_SKETCHES = "Audio/MUS/CH1/MUS_Title_Music_Sketches";

			// Token: 0x040025CA RID: 9674
			public const string SFX_INK_SQUIRT = "Audio/SFX/SFX_Ink_Squirt";

			// Token: 0x040025CB RID: 9675
			public const string SFX_WHOOSH = "Audio/SFX/SFX_Whoosh";

			// Token: 0x040025CC RID: 9676
			public const string CH_4_AUDIO_LOGGRANTTRANSFORMATION_TEMP = "Audio/DIA/CH4/AudioLogs/ch4_audiolog_grant";
		}

		// Token: 0x020005D3 RID: 1491
		public static class Prefabs
		{
			// Token: 0x040025CD RID: 9677
			public const string AUDIO_OBJECT_2_D = "GamePlay/Audio/AudioObject_2D";

			// Token: 0x040025CE RID: 9678
			public const string AUDIO_OBJECT_3_D = "GamePlay/Audio/AudioObject_3D";

			// Token: 0x040025CF RID: 9679
			public const string CH_3_GEAR = "GamePlay/CH3/CH3Gear";

			// Token: 0x040025D0 RID: 9680
			public const string CH_3_POWER_CORE = "GamePlay/CH3/CH3PowerCore";

			// Token: 0x040025D1 RID: 9681
			public const string CH_3_THICK_INK = "GamePlay/CH3/CH3ThickInk";

			// Token: 0x040025D2 RID: 9682
			public const string THE_END = "GamePlay/CH5/TheEnd";

			// Token: 0x040025D3 RID: 9683
			public const string CH_1_SECRET_MESSAGE = "GamePlay/Chapters/CH1_SecretMessage";

			// Token: 0x040025D4 RID: 9684
			public const string CH_2_SECRET_MESSAGE = "GamePlay/Chapters/CH2_SecretMessage";

			// Token: 0x040025D5 RID: 9685
			public const string CH_3_SECRET_MESSAGE = "GamePlay/Chapters/CH3_SecretMessage";

			// Token: 0x040025D6 RID: 9686
			public const string CH_4_SECRET_MESSAGE = "GamePlay/Chapters/CH4_SecretMessage";

			// Token: 0x040025D7 RID: 9687
			public const string CH_5_SECRET_MESSAGE = "GamePlay/Chapters/CH5_SecretMessage";

			// Token: 0x040025D8 RID: 9688
			public const string AI_ALICE_A = "GamePlay/Characters/Ai_AliceA";

			// Token: 0x040025D9 RID: 9689
			public const string AI_BENDY = "GamePlay/Characters/Ai_Bendy";

			// Token: 0x040025DA RID: 9690
			public const string AI_BENDY_CH_1 = "GamePlay/Characters/Ai_Bendy_CH1";

			// Token: 0x040025DB RID: 9691
			public const string AI_BENDY_CH_2 = "GamePlay/Characters/Ai_Bendy_CH2";

			// Token: 0x040025DC RID: 9692
			public const string AI_FISHER = "GamePlay/Characters/Ai_Fisher";

			// Token: 0x040025DD RID: 9693
			public const string AI_LOST_ONE_FIGHTER = "GamePlay/Characters/Ai_LostOneFighter";

			// Token: 0x040025DE RID: 9694
			public const string AI_LOST_ONE_FIGHTER_WEAPON = "GamePlay/Characters/Ai_LostOneFighter_Weapon";

			// Token: 0x040025DF RID: 9695
			public const string AI_PIPER = "GamePlay/Characters/Ai_Piper";

			// Token: 0x040025E0 RID: 9696
			public const string AI_PIPER_SPECIAL = "GamePlay/Characters/Ai_PiperSpecial";

			// Token: 0x040025E1 RID: 9697
			public const string AI_PROJECTIONIST = "GamePlay/Characters/Ai_Projectionist";

			// Token: 0x040025E2 RID: 9698
			public const string AI_PROJECTIONIST_SCARE = "GamePlay/Characters/Ai_ProjectionistScare";

			// Token: 0x040025E3 RID: 9699
			public const string AI_SAMMY_LAWRENCE = "GamePlay/Characters/Ai_SammyLawrence";

			// Token: 0x040025E4 RID: 9700
			public const string AI_SEARCHER = "GamePlay/Characters/Ai_Searcher";

			// Token: 0x040025E5 RID: 9701
			public const string AI_SEARCHER_BOSS = "GamePlay/Characters/Ai_Searcher_Boss";

			// Token: 0x040025E6 RID: 9702
			public const string AI_SEARCHER_INITIAL = "GamePlay/Characters/Ai_Searcher_Initial";

			// Token: 0x040025E7 RID: 9703
			public const string AI_SEARCHER_LOST_HARBOR = "GamePlay/Characters/Ai_Searcher_LostHarbor";

			// Token: 0x040025E8 RID: 9704
			public const string AI_SEARCHER_MINI_BOSS = "GamePlay/Characters/Ai_Searcher_MiniBoss";

			// Token: 0x040025E9 RID: 9705
			public const string AI_SEARCHER_MINI_BOSS_2 = "GamePlay/Characters/Ai_Searcher_MiniBoss2";

			// Token: 0x040025EA RID: 9706
			public const string AI_SEARCHER_POOL = "GamePlay/Characters/Ai_Searcher_Pool";

			// Token: 0x040025EB RID: 9707
			public const string AI_STRIKER = "GamePlay/Characters/Ai_Striker";

			// Token: 0x040025EC RID: 9708
			public const string AI_SWOLLEN_SEARCHER = "GamePlay/Characters/Ai_SwollenSearcher";

			// Token: 0x040025ED RID: 9709
			public const string AI_TOM = "GamePlay/Characters/Ai_Tom";

			// Token: 0x040025EE RID: 9710
			public const string BEAST_BENDY_AI = "GamePlay/Characters/BeastBendy_Ai";

			// Token: 0x040025EF RID: 9711
			public const string AI_ALICE_A_VAULT = "GamePlay/Characters/CH5/Ai_AliceA_Vault";

			// Token: 0x040025F0 RID: 9712
			public const string AI_FISHER_PATHER = "GamePlay/Characters/CH5/Ai_Fisher_Pather";

			// Token: 0x040025F1 RID: 9713
			public const string AI_PIPER_PATHER = "GamePlay/Characters/CH5/Ai_Piper_Pather";

			// Token: 0x040025F2 RID: 9714
			public const string AI_STRIKER_PATHER = "GamePlay/Characters/CH5/Ai_Striker_Pather";

			// Token: 0x040025F3 RID: 9715
			public const string AI_TOM_VAULT = "GamePlay/Characters/CH5/Ai_Tom_Vault";

			// Token: 0x040025F4 RID: 9716
			public const string DEAD_FISHER_01 = "GamePlay/Characters/Dead/Dead_Fisher_01";

			// Token: 0x040025F5 RID: 9717
			public const string DEAD_FISHER_TEMPLATE = "GamePlay/Characters/Dead/Dead_Fisher_Template";

			// Token: 0x040025F6 RID: 9718
			public const string DEAD_PIPER_01 = "GamePlay/Characters/Dead/Dead_Piper_01";

			// Token: 0x040025F7 RID: 9719
			public const string DEAD_PIPER_TEMPLATE = "GamePlay/Characters/Dead/Dead_Piper_Template";

			// Token: 0x040025F8 RID: 9720
			public const string DEAD_STRIKER_01 = "GamePlay/Characters/Dead/Dead_Striker_01";

			// Token: 0x040025F9 RID: 9721
			public const string DEAD_STRIKER_TEMPLATE = "GamePlay/Characters/Dead/Dead_Striker_Template";

			// Token: 0x040025FA RID: 9722
			public const string ENDING_PLAYER_CONTROLLER = "GamePlay/Characters/Player/EndingPlayerController";

			// Token: 0x040025FB RID: 9723
			public const string FINALE_CAMERA = "GamePlay/Characters/Player/FinaleCamera";

			// Token: 0x040025FC RID: 9724
			public const string PLAYER_CONTROLLER = "GamePlay/Characters/Player/PlayerController";

			// Token: 0x040025FD RID: 9725
			public const string AXE_HIT_EFFECT = "GamePlay/Decals/Axe_Hit_Effect";

			// Token: 0x040025FE RID: 9726
			public const string BLUNT_HIT_EFFECT = "GamePlay/Decals/Blunt_Hit_Effect";

			// Token: 0x040025FF RID: 9727
			public const string DEATH_INK_SPLAT = "GamePlay/Decals/DeathInkSplat";

			// Token: 0x04002600 RID: 9728
			public const string BORIS_INK_SPURT = "GamePlay/Particles/Boris_Ink_Spurt";

			// Token: 0x04002601 RID: 9729
			public const string DUST_PARTICLE_FIELD = "GamePlay/Particles/Dust_ParticleField";

			// Token: 0x04002602 RID: 9730
			public const string ENEMY_DEATH_INK = "GamePlay/Particles/Enemy_Death_Ink";

			// Token: 0x04002603 RID: 9731
			public const string INK_DROP_SPLASH_ONE_ONLY = "GamePlay/Particles/InkDropSplash_OneOnly";

			// Token: 0x04002604 RID: 9732
			public const string INK_HIT = "GamePlay/Particles/InkHit";

			// Token: 0x04002605 RID: 9733
			public const string INK_SPLASH_BIG = "GamePlay/Particles/InkSplash_Big";

			// Token: 0x04002606 RID: 9734
			public const string INK_SPLASH_LONG = "GamePlay/Particles/InkSplash_Long";

			// Token: 0x04002607 RID: 9735
			public const string INK_RAIN = "GamePlay/Particles/Ink_Rain";

			// Token: 0x04002608 RID: 9736
			public const string INK_RAIN_HIGH = "GamePlay/Particles/Ink_Rain_High";

			// Token: 0x04002609 RID: 9737
			public const string INK_RAIN_SMALL = "GamePlay/Particles/Ink_Rain_Small";

			// Token: 0x0400260A RID: 9738
			public const string SEARCHER_SPAWN_POOL = "GamePlay/Particles/Searcher_SpawnPool";

			// Token: 0x0400260B RID: 9739
			public const string SEARCHER_SPAWN_POOL_NO_DECAL = "GamePlay/Particles/Searcher_SpawnPool_NoDecal";

			// Token: 0x0400260C RID: 9740
			public const string SIMPLE_SMOKE = "GamePlay/Particles/Simple Smoke";

			// Token: 0x0400260D RID: 9741
			public const string SMOKE_PARTICLES = "GamePlay/Particles/SmokeParticles";

			// Token: 0x0400260E RID: 9742
			public const string SMOKE_PARTICLES_LOW = "GamePlay/Particles/SmokeParticles_Low";

			// Token: 0x0400260F RID: 9743
			public const string SMOKE_PARTICLES_MEDIUM = "GamePlay/Particles/SmokeParticles_Medium";

			// Token: 0x04002610 RID: 9744
			public const string SMOKE_PARTICLES_NORMAL = "GamePlay/Particles/SmokeParticles_Normal";

			// Token: 0x04002611 RID: 9745
			public const string SPARKS_ELEVATOR_FALL = "GamePlay/Particles/Sparks_ElevatorFall";

			// Token: 0x04002612 RID: 9746
			public const string SPARKS_SMALL = "GamePlay/Particles/Sparks_Small";

			// Token: 0x04002613 RID: 9747
			public const string SPARKS_STREAM = "GamePlay/Particles/Sparks_Stream";

			// Token: 0x04002614 RID: 9748
			public const string SPARKS_TRIGGER_ONLY = "GamePlay/Particles/Sparks_TriggerOnly";

			// Token: 0x04002615 RID: 9749
			public const string STEAM_JET = "GamePlay/Particles/SteamJet";

			// Token: 0x04002616 RID: 9750
			public const string STEAM_JET_TRIGGER_ONLY = "GamePlay/Particles/SteamJet_TriggerOnly";

			// Token: 0x04002617 RID: 9751
			public const string DEATH_CONTROLLER = "GamePlay/Scenes/DeathController";

			// Token: 0x04002618 RID: 9752
			public const string WEAPON_AXE = "GamePlay/Weapons/Weapon_Axe";

			// Token: 0x04002619 RID: 9753
			public const string WEAPON_AXE_NEW = "GamePlay/Weapons/Weapon_Axe_New";

			// Token: 0x0400261A RID: 9754
			public const string WEAPON_GENT = "GamePlay/Weapons/Weapon_Gent";

			// Token: 0x0400261B RID: 9755
			public const string WEAPON_INK_TOOL = "GamePlay/Weapons/Weapon_InkTool";

			// Token: 0x0400261C RID: 9756
			public const string WEAPON_PLUNGER = "GamePlay/Weapons/Weapon_Plunger";

			// Token: 0x0400261D RID: 9757
			public const string WEAPON_TOMMY_GUN = "GamePlay/Weapons/Weapon_TommyGun";

			// Token: 0x0400261E RID: 9758
			public const string WEAPON_TOMMY_GUN_MELT = "GamePlay/Weapons/Weapon_TommyGunMelt";

			// Token: 0x0400261F RID: 9759
			public const string WEAPON_WRENCH = "GamePlay/Weapons/Weapon_Wrench";

			// Token: 0x04002620 RID: 9760
			public const string SCREEN_BLOCKER_CONTROLLER = "UI/Blocker/ScreenBlockerController";

			// Token: 0x04002621 RID: 9761
			public const string SCREEN_WHITE_BLOCKER_CONTROLLER = "UI/Blocker/ScreenWhiteBlockerController";

			// Token: 0x04002622 RID: 9762
			public const string HURT_BORDERS_CONTROLLER = "UI/Borders/HurtBordersController";

			// Token: 0x04002623 RID: 9763
			public const string MAIN_CROSSHAIR_CONTROLLER = "UI/Crosshairs/MainCrosshairController";

			// Token: 0x04002624 RID: 9764
			public const string TUTORIAL_POPUP_CONTROLLER = "UI/Crosshairs/TutorialPopupController";

			// Token: 0x04002625 RID: 9765
			public const string UI_NAV_INPUT = "UI/Elements/UINavInput";

			// Token: 0x04002626 RID: 9766
			public const string MEATLY_LOGO = "UI/Intro/MeatlyLogo";

			// Token: 0x04002627 RID: 9767
			public const string ASYNC_LOADER = "UI/Loaders/AsyncLoader";

			// Token: 0x04002628 RID: 9768
			public const string GENERIC_LOADER_CONTROLLER = "UI/Loaders/GenericLoaderController";

			// Token: 0x04002629 RID: 9769
			public const string PRE_LOADER_CONTROLLER = "UI/Loaders/PreLoaderController";

			// Token: 0x0400262A RID: 9770
			public const string GAME_MENU_CONTROLLER = "UI/Menus/GameMenuController";

			// Token: 0x0400262B RID: 9771
			public const string OPTIONS_MENU_CONTROLLER = "UI/Menus/OptionsMenuController";

			// Token: 0x0400262C RID: 9772
			public const string AUDIO_LOG_MODAL_CONTROLLER = "UI/Modals/AudioLogModalController";

			// Token: 0x0400262D RID: 9773
			public const string CH_1_CONCLUSION_MODAL_CONTROLLER = "UI/Modals/CH1ConclusionModalController";

			// Token: 0x0400262E RID: 9774
			public const string CH_1_INTRO_MODAL_CONTROLLER = "UI/Modals/CH1IntroModalController";

			// Token: 0x0400262F RID: 9775
			public const string CHAPTER_TITLE_MODAL_CONTROLLER = "UI/Modals/ChapterTitleModalController";

			// Token: 0x04002630 RID: 9776
			public const string COLLECTABLE_MODAL_CONTROLLER = "UI/Modals/CollectableModalController";

			// Token: 0x04002631 RID: 9777
			public const string DLC_NOTIFICATION_CONTROLLER = "UI/Notifications/DLCNotificationController";

			// Token: 0x04002632 RID: 9778
			public const string OBJECTIVE_CONTROLLER = "UI/Objectives/ObjectiveController";

			// Token: 0x04002633 RID: 9779
			public const string ATTENTION_PROMPT_CONTROLLER = "UI/Prompts/AttentionPromptController";

			// Token: 0x04002634 RID: 9780
			public const string CONTROLS_PROMPT_CONTROLLER = "UI/Prompts/ControlsPromptController";

			// Token: 0x04002635 RID: 9781
			public const string QUIT_PROMPT_CONTROLLER = "UI/Prompts/QuitPromptController";

			// Token: 0x04002636 RID: 9782
			public const string MAIN_SUBTITLES_CONTROLLER = "UI/Subtitles/MainSubtitlesController";

			// Token: 0x04002637 RID: 9783
			public const string BRIGHTNESS_SCREEN = "UI/Views/BrightnessScreen";

			// Token: 0x04002638 RID: 9784
			public const string CREDITS_SCREEN = "UI/Views/CreditsScreen";

			// Token: 0x04002639 RID: 9785
			public const string SPLASH_SCREEN = "UI/Views/SplashScreen";

			// Token: 0x0400263A RID: 9786
			public const string TITLE_SCREEN = "UI/Views/TitleScreen";

			// Token: 0x0400263B RID: 9787
			public const string TITLE_SCREENOLD = "UI/Views/TitleScreen_old";

			// Token: 0x0400263C RID: 9788
			public const string CH_1_SOUNDBANK = "CH1 Soundbank";

			// Token: 0x0400263D RID: 9789
			public const string CH_2_SOUNDBANK = "CH2 Soundbank";

			// Token: 0x0400263E RID: 9790
			public const string CH_3_SOUNDBANK = "CH3 Soundbank";

			// Token: 0x0400263F RID: 9791
			public const string CH_4_SOUNDBANK = "CH4 Soundbank";

			// Token: 0x04002640 RID: 9792
			public const string CH_5_ENDING = "CH5 Ending";

			// Token: 0x04002641 RID: 9793
			public const string CH_5_SOUNDBANK = "CH5 Soundbank";

			// Token: 0x04002642 RID: 9794
			public const string S_13_AUDIO_MANAGER = "S13AudioManager";
		}

		// Token: 0x020005D4 RID: 1492
		public static class Scenes
		{
			// Token: 0x04002643 RID: 9795
			public const string EMPTY = "Empty";

			// Token: 0x04002644 RID: 9796
			public const string INITIALIZE_GAME = "InitializeGame";

			// Token: 0x04002645 RID: 9797
			public const string MEATLY_LOGO = "MeatlyLogo";

			// Token: 0x04002646 RID: 9798
			public const string RESET = "Reset";

			// Token: 0x04002647 RID: 9799
			public const string THE_END = "TheEnd";

			// Token: 0x04002648 RID: 9800
			public const string ARCHIVES = "Archives";

			// Token: 0x04002649 RID: 9801
			public const string CH_1 = "CH1";

			// Token: 0x0400264A RID: 9802
			public const string CH_1_FINALE = "CH1_Finale";

			// Token: 0x0400264B RID: 9803
			public const string CH_2 = "CH2";

			// Token: 0x0400264C RID: 9804
			public const string CH_3 = "CH3";

			// Token: 0x0400264D RID: 9805
			public const string CH_4 = "CH4";

			// Token: 0x0400264E RID: 9806
			public const string CH_5 = "CH5";

			// Token: 0x0400264F RID: 9807
			public const string SECRET_MESSAGES_CH_1 = "SecretMessages_CH1";

			// Token: 0x04002650 RID: 9808
			public const string SECRET_MESSAGES_CH_2 = "SecretMessages_CH2";

			// Token: 0x04002651 RID: 9809
			public const string SECRET_MESSAGES_CH_3 = "SecretMessages_CH3";

			// Token: 0x04002652 RID: 9810
			public const string SECRET_MESSAGES_CH_4 = "SecretMessages_CH4";

			// Token: 0x04002653 RID: 9811
			public const string SECRET_MESSAGES_CH_5 = "SecretMessages_CH5";

			// Token: 0x04002654 RID: 9812
			public const string ASYNC_LOADER = "AsyncLoader";

			// Token: 0x04002655 RID: 9813
			public const string SCREEN_BLOCKER = "ScreenBlocker";

			// Token: 0x04002656 RID: 9814
			public const string SCREEN_WHITE_BLOCKER = "ScreenWhiteBlocker";

			// Token: 0x04002657 RID: 9815
			public const string HURT_BORDERS = "HurtBorders";

			// Token: 0x04002658 RID: 9816
			public const string MAIN_CROSSHAIR = "MainCrosshair";

			// Token: 0x04002659 RID: 9817
			public const string TUTORIAL_POPUP = "TutorialPopup";

			// Token: 0x0400265A RID: 9818
			public const string GENERIC_LOADER = "GenericLoader";

			// Token: 0x0400265B RID: 9819
			public const string PRE_LOADER = "PreLoader";

			// Token: 0x0400265C RID: 9820
			public const string GAME_MENU = "GameMenu";

			// Token: 0x0400265D RID: 9821
			public const string OPTIONS_MENU = "OptionsMenu";

			// Token: 0x0400265E RID: 9822
			public const string AUDIO_LOG_MODAL = "AudioLogModal";

			// Token: 0x0400265F RID: 9823
			public const string CH_1_CONCLUSION_MODAL = "CH1ConclusionModal";

			// Token: 0x04002660 RID: 9824
			public const string CH_1_INTRO_MODAL = "CH1IntroModal";

			// Token: 0x04002661 RID: 9825
			public const string CHAPTER_TITLE_MODAL = "ChapterTitleModal";

			// Token: 0x04002662 RID: 9826
			public const string COLLECTABLE_MODAL = "CollectableModal";

			// Token: 0x04002663 RID: 9827
			public const string DLC_NOTIFICATION = "DLCNotification";

			// Token: 0x04002664 RID: 9828
			public const string OBJECTIVE_LAYOUT = "ObjectiveLayout";

			// Token: 0x04002665 RID: 9829
			public const string ATTENTION_PROMPT = "AttentionPrompt";

			// Token: 0x04002666 RID: 9830
			public const string CONTROLS_PROMPT = "ControlsPrompt";

			// Token: 0x04002667 RID: 9831
			public const string QUIT_PROMPT = "QuitPrompt";

			// Token: 0x04002668 RID: 9832
			public const string MAIN_SUBTITLES = "MainSubtitles";

			// Token: 0x04002669 RID: 9833
			public const string BRIGHTNESS_SCREEN = "BrightnessScreen";

			// Token: 0x0400266A RID: 9834
			public const string CREDITS_SCREEN = "CreditsScreen";

			// Token: 0x0400266B RID: 9835
			public const string SPLASH_SCREEN = "SplashScreen";

			// Token: 0x0400266C RID: 9836
			public const string TITLE_SCREEN = "TitleScreen";

			// Token: 0x0400266D RID: 9837
			public const string AI_DANGER_ROOM = "AI_Danger_Room";

			// Token: 0x0400266E RID: 9838
			public const string AUDIO_TEST_2_D_SIMPLE_EVENTS = "AudioTest_2DSimpleEvents";

			// Token: 0x0400266F RID: 9839
			public const string AUDIO_TEST_3_D_PLAYER_CONTROLLER = "AudioTest_3DPlayerController";

			// Token: 0x04002670 RID: 9840
			public const string NEW_3D_OBJECTS_SCENE = "New3dObjectsScene";

			// Token: 0x04002671 RID: 9841
			public const string TEST_BEAST_BENDY_AUDIO = "Test_BeastBendy_Audio";

			// Token: 0x04002672 RID: 9842
			public const string AUDIO_TEST_SCENE_PROJECTIONIST_BENDY_FIGHT = "AudioTestScene_ProjectionistBendyFight";

			// Token: 0x04002673 RID: 9843
			public const string APARTMENT = "Apartment";
		}

		// Token: 0x020005D5 RID: 1493
		public static class Materials
		{
			// Token: 0x04002674 RID: 9844
			public const string BRIGHTNESS_MATERIAL = "BrightnessMaterial";

			// Token: 0x04002675 RID: 9845
			public const string SPOT_FIX = "SpotFix";

			// Token: 0x04002676 RID: 9846
			public const string TOONIFY_MATERIAL = "Toonify_Material";

			// Token: 0x04002677 RID: 9847
			public const string IMAGE_EFFECT_VISION = "ImageEffect_Vision";

			// Token: 0x04002678 RID: 9848
			public const string ALPHA_BENDY_MATERIAL = "AlphaBendyMaterial";

			// Token: 0x04002679 RID: 9849
			public const string BETA_BORIS_BODY_MATERIAL = "BetaBorisBodyMaterial";

			// Token: 0x0400267A RID: 9850
			public const string CONCEPT_BENDY_BODY_MATERIAL = "ConceptBendyBodyMaterial";

			// Token: 0x0400267B RID: 9851
			public const string CONCEPT_BENDY_FACE_MATERIAL = "ConceptBendyFaceMaterial";

			// Token: 0x0400267C RID: 9852
			public const string CONCEPT_BENDY_MOUTH_MATERIAL = "ConceptBendyMouthMaterial";

			// Token: 0x0400267D RID: 9853
			public const string ORIGINALS_BLACK = "OriginalsBlack";

			// Token: 0x0400267E RID: 9854
			public const string ORIGINALS_TAN = "OriginalsTan";

			// Token: 0x0400267F RID: 9855
			public const string ALICE_MATERIAL = "AliceMaterial";

			// Token: 0x04002680 RID: 9856
			public const string ALICE_A_MATERIAL = "AliceAMaterial";

			// Token: 0x04002681 RID: 9857
			public const string ALICE_A_SWORD_MATERIAL = "AliceASwordMaterial";

			// Token: 0x04002682 RID: 9858
			public const string ARCHIVE_BEAST_BENDY_MATERIAL = "ArchiveBeastBendyMaterial";

			// Token: 0x04002683 RID: 9859
			public const string MAT_BEAST_BENDY = "Mat_BeastBendy";

			// Token: 0x04002684 RID: 9860
			public const string ARCHIVE_BENDY_MATERIAL = "ArchiveBendyMaterial";

			// Token: 0x04002685 RID: 9861
			public const string BENDY_MATERIAL = "Bendy_Material";

			// Token: 0x04002686 RID: 9862
			public const string MAT_BENDY_HAND = "Mat_BendyHand";

			// Token: 0x04002687 RID: 9863
			public const string MAT_BERTRUM = "Mat_Bertrum";

			// Token: 0x04002688 RID: 9864
			public const string MAT_BERTRUM_ARM = "Mat_Bertrum_Arm";

			// Token: 0x04002689 RID: 9865
			public const string MAT_BERTRUM_HEAD = "Mat_Bertrum_Head";

			// Token: 0x0400268A RID: 9866
			public const string CH_3_BORIS_EYES_BASIC_MAT = "CH3_Boris_Eyes_Basic_Mat";

			// Token: 0x0400268B RID: 9867
			public const string CH_3_BORIS_EYES_MAT = "CH3_Boris_Eyes_Mat";

			// Token: 0x0400268C RID: 9868
			public const string CH_3_BORIS_MAT = "CH3_Boris_Mat";

			// Token: 0x0400268D RID: 9869
			public const string DEAD_BORIS_MATERIAL = "DeadBorisMaterial";

			// Token: 0x0400268E RID: 9870
			public const string DEAD_BORIS_STRAPS = "DeadBorisStraps";

			// Token: 0x0400268F RID: 9871
			public const string ARCHIVES_BRUTE_BORIS_INK_MATERIAL = "ArchivesBruteBorisInkMaterial";

			// Token: 0x04002690 RID: 9872
			public const string BRUTE_BORIS_INK_MATERIAL = "Brute_Boris_Ink_Material";

			// Token: 0x04002691 RID: 9873
			public const string BRUTE_BORIS_MATERIAL = "Brute_Boris_Material";

			// Token: 0x04002692 RID: 9874
			public const string FISH_MAT = "Fish_Mat";

			// Token: 0x04002693 RID: 9875
			public const string CH_3_FISHER_MAT = "CH3_Fisher_Mat";

			// Token: 0x04002694 RID: 9876
			public const string LOST_ONES_BASIC = "LostOnes_Basic";

			// Token: 0x04002695 RID: 9877
			public const string MAT_LOST_ONES_EYES = "Mat_LostOnes_Eyes";

			// Token: 0x04002696 RID: 9878
			public const string CH_3PIPERMAT = "ch3_piper_mat";

			// Token: 0x04002697 RID: 9879
			public const string CH_3_PROJECTIONISTMAT = "CH3_Projectionist_mat";

			// Token: 0x04002698 RID: 9880
			public const string ARCHIVES_SAMMY_MATERIAL = "ArchivesSammyMaterial";

			// Token: 0x04002699 RID: 9881
			public const string MAT_SAMMY = "Mat_Sammy";

			// Token: 0x0400269A RID: 9882
			public const string ARCHIVES_SAMMY_LAWRENCE_MATERIAL = "ArchivesSammyLawrenceMaterial";

			// Token: 0x0400269B RID: 9883
			public const string MAT_SAMMY_LARENCE = "Mat_SammyLarence";

			// Token: 0x0400269C RID: 9884
			public const string ARCHIVE_SEARCHER_2_MATERIAL = "ArchiveSearcher2Material";

			// Token: 0x0400269D RID: 9885
			public const string SEARCHER_MATERIAL = "SearcherMaterial";

			// Token: 0x0400269E RID: 9886
			public const string CH_3STRIKERMAT = "ch3_striker_mat";

			// Token: 0x0400269F RID: 9887
			public const string TOM_EYES_MATERIAL = "TomEyesMaterial";

			// Token: 0x040026A0 RID: 9888
			public const string TOM_MATERIAL = "TomMaterial";

			// Token: 0x040026A1 RID: 9889
			public const string BENDY_MAT_V_1 = "Bendy_Mat_V1";

			// Token: 0x040026A2 RID: 9890
			public const string SEARCHER_MAT_V_1 = "Searcher_Mat_V1";

			// Token: 0x040026A3 RID: 9891
			public const string BASIC_BLUR = "BasicBlur";

			// Token: 0x040026A4 RID: 9892
			public const string BENDY_COSTUME_MAT = "Bendy_Costume_Mat";

			// Token: 0x040026A5 RID: 9893
			public const string BLACK = "Black";

			// Token: 0x040026A6 RID: 9894
			public const string BLACK_MAT = "BlackMat";

			// Token: 0x040026A7 RID: 9895
			public const string BLACK_TAPE = "BlackTape";

			// Token: 0x040026A8 RID: 9896
			public const string BLACK_SPEC = "Black_Spec";

			// Token: 0x040026A9 RID: 9897
			public const string BORIS_MATERIAL = "BorisMaterial";

			// Token: 0x040026AA RID: 9898
			public const string CABLE_MATERIAL = "CableMaterial";

			// Token: 0x040026AB RID: 9899
			public const string CANDLE_FLAMEMATERIAL = "Candle_Flame_material";

			// Token: 0x040026AC RID: 9900
			public const string CARTOON_PROJECTION = "CartoonProjection";

			// Token: 0x040026AD RID: 9901
			public const string COBWEB = "Cobweb";

			// Token: 0x040026AE RID: 9902
			public const string CURTAIN_MATERIAL = "CurtainMaterial";

			// Token: 0x040026AF RID: 9903
			public const string DARKNESS_VOLUME = "DarknessVolume";

			// Token: 0x040026B0 RID: 9904
			public const string DECAL_MATERIAL = "DecalMaterial";

			// Token: 0x040026B1 RID: 9905
			public const string DRIP = "Drip";

			// Token: 0x040026B2 RID: 9906
			public const string DRIP_ANGLE = "DripAngle";

			// Token: 0x040026B3 RID: 9907
			public const string DUST_PARTICLE = "DustParticle";

			// Token: 0x040026B4 RID: 9908
			public const string FACE = "Face";

			// Token: 0x040026B5 RID: 9909
			public const string FIRE = "Fire";

			// Token: 0x040026B6 RID: 9910
			public const string GENT_WEAPON_MAT = "Gent_Weapon_Mat";

			// Token: 0x040026B7 RID: 9911
			public const string GLASS = "Glass";

			// Token: 0x040026B8 RID: 9912
			public const string GLASS_GENERIC = "Glass_Generic";

			// Token: 0x040026B9 RID: 9913
			public const string GLASS_GENERIC_SOFT = "Glass_Generic_Soft";

			// Token: 0x040026BA RID: 9914
			public const string HIGHLIGHT_CABLE_MATERIAL = "HighlightCableMaterial";

			// Token: 0x040026BB RID: 9915
			public const string INK_BLACK = "InkBlack";

			// Token: 0x040026BC RID: 9916
			public const string INK_FLOW_TEXTURE_01 = "InkFlowTexture01";

			// Token: 0x040026BD RID: 9917
			public const string INK_MACHINE_MASTER_MATERIAL = "InkMachineMasterMaterial";

			// Token: 0x040026BE RID: 9918
			public const string INK_SPLASH_PARTICLE = "InkSplashParticle";

			// Token: 0x040026BF RID: 9919
			public const string INK_TUNNEL = "InkTunnel";

			// Token: 0x040026C0 RID: 9920
			public const string INK_TUNNEL_LIGHT = "InkTunnelLight";

			// Token: 0x040026C1 RID: 9921
			public const string INK_VALVE = "InkValve";

			// Token: 0x040026C2 RID: 9922
			public const string LIGHT = "Light";

			// Token: 0x040026C3 RID: 9923
			public const string LIGHT_MATERIAL = "LightMaterial";

			// Token: 0x040026C4 RID: 9924
			public const string LIGHT_OFF_MATERIAL = "LightOffMaterial";

			// Token: 0x040026C5 RID: 9925
			public const string MAT_BENDY_BOT = "Mat_BendyBot";

			// Token: 0x040026C6 RID: 9926
			public const string MAT_GIANT_BENDY_FACE = "Mat_GiantBendyFace";

			// Token: 0x040026C7 RID: 9927
			public const string MAT_PARK_MACHINERY = "Mat_ParkMachinery";

			// Token: 0x040026C8 RID: 9928
			public const string MEATLY_DECAL_WAVEY = "MeatlyDecalWavey";

			// Token: 0x040026C9 RID: 9929
			public const string MEATLY_FOLIAGE_MATERIAL_01 = "MeatlyFoliageMaterial_01";

			// Token: 0x040026CA RID: 9930
			public const string MEATLY_LOGO_MATERIAL = "MeatlyLogoMaterial";

			// Token: 0x040026CB RID: 9931
			public const string NEW_LIGHT_GLOW_MATERIAL = "NewLightGlow_Material";

			// Token: 0x040026CC RID: 9932
			public const string PARTICLE_INK_DRIP = "ParticleInk_Drip";

			// Token: 0x040026CD RID: 9933
			public const string PARTICLE_INK = "Particle_Ink";

			// Token: 0x040026CE RID: 9934
			public const string SCREEN = "Screen";

			// Token: 0x040026CF RID: 9935
			public const string SEARCHER_SPAWN_BUBBLY_INK = "SearcherSpawn_BubblyInk";

			// Token: 0x040026D0 RID: 9936
			public const string SEARCHER_SPAWN_BUBBLY_INK_PARTICLE = "SearcherSpawn_BubblyInkParticle";

			// Token: 0x040026D1 RID: 9937
			public const string SECRET_CHARACTER_MATERTIAL = "SecretCharacterMatertial";

			// Token: 0x040026D2 RID: 9938
			public const string SECRET_MESSAGE_HARD_MATERIAL = "SecretMessageHardMaterial";

			// Token: 0x040026D3 RID: 9939
			public const string SECRET_MESSAGE_MATERIAL = "SecretMessageMaterial";

			// Token: 0x040026D4 RID: 9940
			public const string SECRET_MESSAGE_PARTICLE = "SecretMessageParticle";

			// Token: 0x040026D5 RID: 9941
			public const string SECRET_VIEWER = "SecretViewer";

			// Token: 0x040026D6 RID: 9942
			public const string SEEING_TOOL_MAT = "SeeingToolMat";

			// Token: 0x040026D7 RID: 9943
			public const string SMOKE = "Smoke";

			// Token: 0x040026D8 RID: 9944
			public const string SPARKS = "Sparks";

			// Token: 0x040026D9 RID: 9945
			public const string TELEVISION_SCREEN = "TelevisionScreen";

			// Token: 0x040026DA RID: 9946
			public const string THEMEATLYMAT = "themeatly_mat";

			// Token: 0x040026DB RID: 9947
			public const string THICK_INK = "ThickInk";

			// Token: 0x040026DC RID: 9948
			public const string THICK_INK_HIGHLIGHT = "ThickInk_Highlight";

			// Token: 0x040026DD RID: 9949
			public const string TOILET_INK_WATER = "Toilet_Ink_Water";

			// Token: 0x040026DE RID: 9950
			public const string CH_1_COLLAPSE_INK_01 = "CH1_Collapse_Ink_01";

			// Token: 0x040026DF RID: 9951
			public const string CH_1_COLLAPSE_INK_02 = "CH1_Collapse_Ink_02";

			// Token: 0x040026E0 RID: 9952
			public const string CH_1_COLLAPSE_INK_03 = "CH1_Collapse_Ink_03";

			// Token: 0x040026E1 RID: 9953
			public const string CH_1_DOOR_INK_01 = "CH1_Door_Ink_01";

			// Token: 0x040026E2 RID: 9954
			public const string CH_1_DOOR_INK_02 = "CH1_Door_Ink_02";

			// Token: 0x040026E3 RID: 9955
			public const string CH_1_FLOWROOM_INK = "CH1_FlowroomInk";

			// Token: 0x040026E4 RID: 9956
			public const string CH_1_INK_FINALIE_RAISING_INK = "Ch1_InkFinalieRaisingInk";

			// Token: 0x040026E5 RID: 9957
			public const string CH_1_INK_FINALIE_CEILING = "CH1_InkFinalie_Ceiling";

			// Token: 0x040026E6 RID: 9958
			public const string CH_1_INK_FINALIE_DISOLVE_FLOOR = "CH1_InkFinalie_DisolveFloor";

			// Token: 0x040026E7 RID: 9959
			public const string CH_1_INK_FINALIE_WALL_INK = "CH1_InkFinalie_WallInk";

			// Token: 0x040026E8 RID: 9960
			public const string CH_1_INK_FINALIEWORLD = "Ch1_InkFinalie_world";

			// Token: 0x040026E9 RID: 9961
			public const string CH_1_INKFLOW_BREAK = "CH1_Inkflow_Break";

			// Token: 0x040026EA RID: 9962
			public const string CH_1_INK_FOLLOW = "CH1_Ink_Follow";

			// Token: 0x040026EB RID: 9963
			public const string CH_1STATIC_WALL_INK = "Ch1_static_WallInk";

			// Token: 0x040026EC RID: 9964
			public const string CH_1_VENT_INK_01 = "CH1_Vent_Ink_01";

			// Token: 0x040026ED RID: 9965
			public const string CH_1_VENT_INK_02 = "CH1_Vent_Ink_02";

			// Token: 0x040026EE RID: 9966
			public const string CH_1_VENT_INK_03 = "CH1_Vent_Ink_03";

			// Token: 0x040026EF RID: 9967
			public const string CH_1SPEW_REF = "ch1_spewRef";

			// Token: 0x040026F0 RID: 9968
			public const string CH_2_INK_FINALIE_CEILING = "CH2_InkFinalie_Ceiling";

			// Token: 0x040026F1 RID: 9969
			public const string CH_2_INK_FINALIE_DISOLVE_FLOOR = "CH2_InkFinalie_DisolveFloor";

			// Token: 0x040026F2 RID: 9970
			public const string CH_2_INK_FINALIE_WALL_INK = "Ch2_InkFinalie_WallInk";

			// Token: 0x040026F3 RID: 9971
			public const string CH_2_INK_FLOOR = "CH2_InkFloor";

			// Token: 0x040026F4 RID: 9972
			public const string CH_2_INK_WATER = "CH2_Ink_Water";

			// Token: 0x040026F5 RID: 9973
			public const string CH_2_INK_WAVES = "CH2_Ink_Waves";

			// Token: 0x040026F6 RID: 9974
			public const string CH_2_SAMMY_DIE_INK = "CH2_Sammy_Die_Ink";

			// Token: 0x040026F7 RID: 9975
			public const string CH_2_WALL_INK = "Ch2_WallInk";

			// Token: 0x040026F8 RID: 9976
			public const string CH_2_WALL_INKDOOR = "Ch2_WallInk_door";

			// Token: 0x040026F9 RID: 9977
			public const string CH_3_BENDY_INK_OVERLAY = "CH3_BendyInk_Overlay";

			// Token: 0x040026FA RID: 9978
			public const string CH_3_BENDY_STATUE = "CH3_BendyStatue";

			// Token: 0x040026FB RID: 9979
			public const string CH_3_GANGPOSTER_MAT = "CH3_Gangposter_Mat";

			// Token: 0x040026FC RID: 9980
			public const string CH_3_HENRYSECRETFLOOR = "CH3_Henry_secret_floor";

			// Token: 0x040026FD RID: 9981
			public const string CH_3_INK_FLOOR = "CH3_InkFloor";

			// Token: 0x040026FE RID: 9982
			public const string CH_3_INK_FOUNTAIN_01 = "Ch3_InkFountain_01";

			// Token: 0x040026FF RID: 9983
			public const string CH_3_INK_FOUNTAIN_02 = "Ch3_InkFountain_02";

			// Token: 0x04002700 RID: 9984
			public const string CH_3_INK_FOUNTAIN_03 = "Ch3_InkFountain_03";

			// Token: 0x04002701 RID: 9985
			public const string CH_3_INK_TOY = "CH3_InkToy";

			// Token: 0x04002702 RID: 9986
			public const string CH_3_INK_WALL = "CH3_Ink_Wall";

			// Token: 0x04002703 RID: 9987
			public const string CH_3_INK_WATER = "CH3_Ink_Water";

			// Token: 0x04002704 RID: 9988
			public const string CH_3_MIRROR_BATHROOM = "CH3_Mirror_Bathroom";

			// Token: 0x04002705 RID: 9989
			public const string CH_3_TOMMY_GUN_MELTING = "CH3_TommyGunMelting";

			// Token: 0x04002706 RID: 9990
			public const string CH_3_TV_OFF = "CH3_TV_Off";

			// Token: 0x04002707 RID: 9991
			public const string CH_4_ACCOUNTING_DARKNESS = "CH4_AccountingDarkness";

			// Token: 0x04002708 RID: 9992
			public const string CH_4_INK_BLOCKAGE = "CH4_InkBlockage";

			// Token: 0x04002709 RID: 9993
			public const string CH_4_INK_WATER = "CH4_Ink_Water";

			// Token: 0x0400270A RID: 9994
			public const string CH_4_JUMPSCARE_INK_FLOW = "CH4_Jumpscare_InkFlow";

			// Token: 0x0400270B RID: 9995
			public const string CH_4_MAINTENANCE_INK = "CH4_MaintenanceInk";

			// Token: 0x0400270C RID: 9996
			public const string CH_4_MAINT_INK = "CH4_Maint_Ink";

			// Token: 0x0400270D RID: 9997
			public const string CH_4_PIPE_STREAM_HEAVY = "CH4_Pipe_Stream_Heavy";

			// Token: 0x0400270E RID: 9998
			public const string CH_4_PIPE_STREAM_LIGHT = "CH4_Pipe_Stream_Light";

			// Token: 0x0400270F RID: 9999
			public const string CH_4_PROJECTIONIST_DEATH_SMEAR = "CH4_Projectionist_Death_Smear";

			// Token: 0x04002710 RID: 10000
			public const string CH_5_CHEST = "CH5_Chest";

			// Token: 0x04002711 RID: 10001
			public const string CH_5_FOUNTAIN = "CH5_Fountain";

			// Token: 0x04002712 RID: 10002
			public const string CH_5_GIANT_SPOUT = "CH5_GiantSpout";

			// Token: 0x04002713 RID: 10003
			public const string CH_5_INK_POD_FLOW = "CH5_InkPodFlow";

			// Token: 0x04002714 RID: 10004
			public const string CH_5_INK_POD_WATER = "CH5_InkPod_Water";

			// Token: 0x04002715 RID: 10005
			public const string CH_5_INK_FISH_WATER = "CH5_Ink_Fish_Water";

			// Token: 0x04002716 RID: 10006
			public const string CH_5_INK_FLOOR = "CH5_Ink_Floor";

			// Token: 0x04002717 RID: 10007
			public const string CH_5_INK_WATER_WAVES = "CH5_Ink_Water_Waves";

			// Token: 0x04002718 RID: 10008
			public const string CH_5_PILLAR = "CH5_Pillar";

			// Token: 0x04002719 RID: 10009
			public const string CH_5_PILLARBROKEN = "CH5_Pillar_broken";

			// Token: 0x0400271A RID: 10010
			public const string CH_5_SPOUT = "CH5_Spout";

			// Token: 0x0400271B RID: 10011
			public const string CH_5_WALL_INK = "CH5_Wall_Ink";

			// Token: 0x0400271C RID: 10012
			public const string CH_5_WATER = "CH5_Water";

			// Token: 0x0400271D RID: 10013
			public const string CH_5_WATER_TRANSPARENT = "CH5_Water_Transparent";

			// Token: 0x0400271E RID: 10014
			public const string CH_5_WATER_TUNNELS = "CH5_Water_Tunnels";

			// Token: 0x0400271F RID: 10015
			public const string BALLROOM_PAINTING_MATERIAL_01 = "BallroomPaintingMaterial_01";

			// Token: 0x04002720 RID: 10016
			public const string BALLROOM_PAINTING_MATERIAL_02 = "BallroomPaintingMaterial_02";

			// Token: 0x04002721 RID: 10017
			public const string BALLROOM_PAINTING_MATERIAL_03 = "BallroomPaintingMaterial_03";

			// Token: 0x04002722 RID: 10018
			public const string BALLROOM_PAINTING_MATERIAL_04 = "BallroomPaintingMaterial_04";

			// Token: 0x04002723 RID: 10019
			public const string BENDY_POSE_MATERIAL = "BendyPoseMaterial";

			// Token: 0x04002724 RID: 10020
			public const string BENDY_POSE_STATIC_MATERIAL_01 = "BendyPoseStaticMaterial_01";

			// Token: 0x04002725 RID: 10021
			public const string BENDY_POSE_STATIC_MATERIAL_02 = "BendyPoseStaticMaterial_02";

			// Token: 0x04002726 RID: 10022
			public const string BENDY_POSE_STATIC_MATERIAL_03 = "BendyPoseStaticMaterial_03";

			// Token: 0x04002727 RID: 10023
			public const string BENDY_POSE_STATIC_MATERIAL_04 = "BendyPoseStaticMaterial_04";

			// Token: 0x04002728 RID: 10024
			public const string CH_1_SECRET_MESSAGE_MATERIAL_01 = "CH1SecretMessageMaterial_01";

			// Token: 0x04002729 RID: 10025
			public const string CH_2_SECRET_MESSAGE_MATERIAL_01 = "CH2SecretMessageMaterial_01";

			// Token: 0x0400272A RID: 10026
			public const string CH_3_SECRET_MESSAGE_MATERIAL_01 = "CH3SecretMessageMaterial_01";

			// Token: 0x0400272B RID: 10027
			public const string CH_3_SECRET_MESSAGE_MATERIAL_02 = "CH3SecretMessageMaterial_02";

			// Token: 0x0400272C RID: 10028
			public const string CH_4_SECRET_MESSAGE_MATERIAL_01 = "CH4SecretMessageMaterial_01";

			// Token: 0x0400272D RID: 10029
			public const string CH_5_SECRET_MESSAGE_MATERIAL_01 = "CH5SecretMessageMaterial_01";

			// Token: 0x0400272E RID: 10030
			public const string CH_5_SECRET_MESSAGE_MATERIAL_02 = "CH5SecretMessageMaterial_02";

			// Token: 0x0400272F RID: 10031
			public const string CH_5_SECRET_MESSAGE_MATERIAL_03 = "CH5SecretMessageMaterial_03";

			// Token: 0x04002730 RID: 10032
			public const string HAUNTED_HOUSE_EYES_MATERIAL_01 = "HauntedHouseEyesMaterial_01";

			// Token: 0x04002731 RID: 10033
			public const string HAUNTED_HOUSE_EYES_MATERIAL_02 = "HauntedHouseEyesMaterial_02";

			// Token: 0x04002732 RID: 10034
			public const string HQ_DECAL_MATERIAL = "HQ_Decal_Material";

			// Token: 0x04002733 RID: 10035
			public const string INK_DECALDOUBLESIDED = "InkDecal_doublesided";

			// Token: 0x04002734 RID: 10036
			public const string MEATLY_DECAL_MATERIAL = "Meatly_Decal_Material";

			// Token: 0x04002735 RID: 10037
			public const string BENDY_THRONE_BASE_MASTER = "BendyThroneBaseMaster";

			// Token: 0x04002736 RID: 10038
			public const string BENDY_THRONE_MASTER = "BendyThroneMaster";

			// Token: 0x04002737 RID: 10039
			public const string HIGHLIGHT_EMPTY_ACTIVE_MATERIAL = "HighlightEmptyActiveMaterial";

			// Token: 0x04002738 RID: 10040
			public const string HIGHLIGHT_EMPTY_MATERIAL = "HighlightEmptyMaterial";

			// Token: 0x04002739 RID: 10041
			public const string HIGHLIGHT_MASTER_MATERIAL_01 = "HighlightMasterMaterial_01";

			// Token: 0x0400273A RID: 10042
			public const string HIGHLIGHT_MASTER_MATERIAL_02 = "HighlightMasterMaterial_02";

			// Token: 0x0400273B RID: 10043
			public const string HIGHLIGHT_MASTER_MATERIAL_03 = "HighlightMasterMaterial_03";

			// Token: 0x0400273C RID: 10044
			public const string HIGHLIGHT_MASTER_MATERIAL_04 = "HighlightMasterMaterial_04";

			// Token: 0x0400273D RID: 10045
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_01 = "HighlightMeatlyMasterMaterial_01";

			// Token: 0x0400273E RID: 10046
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_02 = "HighlightMeatlyMasterMaterial_02";

			// Token: 0x0400273F RID: 10047
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_03 = "HighlightMeatlyMasterMaterial_03";

			// Token: 0x04002740 RID: 10048
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_04 = "HighlightMeatlyMasterMaterial_04";

			// Token: 0x04002741 RID: 10049
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_05 = "HighlightMeatlyMasterMaterial_05";

			// Token: 0x04002742 RID: 10050
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_06 = "HighlightMeatlyMasterMaterial_06";

			// Token: 0x04002743 RID: 10051
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_07 = "HighlightMeatlyMasterMaterial_07";

			// Token: 0x04002744 RID: 10052
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_08 = "HighlightMeatlyMasterMaterial_08";

			// Token: 0x04002745 RID: 10053
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_09 = "HighlightMeatlyMasterMaterial_09";

			// Token: 0x04002746 RID: 10054
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_10 = "HighlightMeatlyMasterMaterial_10";

			// Token: 0x04002747 RID: 10055
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_11 = "HighlightMeatlyMasterMaterial_11";

			// Token: 0x04002748 RID: 10056
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_12 = "HighlightMeatlyMasterMaterial_12";

			// Token: 0x04002749 RID: 10057
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_13 = "HighlightMeatlyMasterMaterial_13";

			// Token: 0x0400274A RID: 10058
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_14 = "HighlightMeatlyMasterMaterial_14";

			// Token: 0x0400274B RID: 10059
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_15 = "HighlightMeatlyMasterMaterial_15";

			// Token: 0x0400274C RID: 10060
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_16 = "HighlightMeatlyMasterMaterial_16";

			// Token: 0x0400274D RID: 10061
			public const string HIGHLIGHT_MEATLY_MASTER_MATERIAL_17 = "HighlightMeatlyMasterMaterial_17";

			// Token: 0x0400274E RID: 10062
			public const string HIGHLIGHT_MOOD_MASTER_MATERIAL_01 = "HighlightMoodMasterMaterial_01";

			// Token: 0x0400274F RID: 10063
			public const string HIGHLIGHT_VALVE_PUZZLE_MASTER_MATERIAL = "HighlightValvePuzzleMasterMaterial";

			// Token: 0x04002750 RID: 10064
			public const string MASTER_INK_01 = "MasterInk_01";

			// Token: 0x04002751 RID: 10065
			public const string MASTER_INK_03 = "MasterInk_03";

			// Token: 0x04002752 RID: 10066
			public const string MASTER_MATERIAL_01 = "MasterMaterial_01";

			// Token: 0x04002753 RID: 10067
			public const string MASTER_MATERIAL_02 = "MasterMaterial_02";

			// Token: 0x04002754 RID: 10068
			public const string MASTER_MATERIAL_03 = "MasterMaterial_03";

			// Token: 0x04002755 RID: 10069
			public const string MASTER_MATERIAL_04 = "MasterMaterial_04";

			// Token: 0x04002756 RID: 10070
			public const string MASTER_MATERIAL_05 = "MasterMaterial_05";

			// Token: 0x04002757 RID: 10071
			public const string MEATLY_MASTER_MATERIAL_01 = "MeatlyMasterMaterial_01";

			// Token: 0x04002758 RID: 10072
			public const string MEATLY_MASTER_MATERIAL_01B = "MeatlyMasterMaterial_01_b";

			// Token: 0x04002759 RID: 10073
			public const string MEATLY_MASTER_MATERIAL_02 = "MeatlyMasterMaterial_02";

			// Token: 0x0400275A RID: 10074
			public const string MEATLY_MASTER_MATERIAL_03 = "MeatlyMasterMaterial_03";

			// Token: 0x0400275B RID: 10075
			public const string MEATLY_MASTER_MATERIAL_04 = "MeatlyMasterMaterial_04";

			// Token: 0x0400275C RID: 10076
			public const string MEATLY_MASTER_MATERIAL_05 = "MeatlyMasterMaterial_05";

			// Token: 0x0400275D RID: 10077
			public const string MEATLY_MASTER_MATERIAL_06 = "MeatlyMasterMaterial_06";

			// Token: 0x0400275E RID: 10078
			public const string MEATLY_MASTER_MATERIAL_07 = "MeatlyMasterMaterial_07";

			// Token: 0x0400275F RID: 10079
			public const string MEATLY_MASTER_MATERIAL_08 = "MeatlyMasterMaterial_08";

			// Token: 0x04002760 RID: 10080
			public const string MEATLY_MASTER_MATERIAL_09 = "MeatlyMasterMaterial_09";

			// Token: 0x04002761 RID: 10081
			public const string MEATLY_MASTER_MATERIAL_10 = "MeatlyMasterMaterial_10";

			// Token: 0x04002762 RID: 10082
			public const string MEATLY_MASTER_MATERIAL_11 = "MeatlyMasterMaterial_11";

			// Token: 0x04002763 RID: 10083
			public const string MEATLY_MASTER_MATERIAL_12 = "MeatlyMasterMaterial_12";

			// Token: 0x04002764 RID: 10084
			public const string MEATLY_MASTER_MATERIAL_13 = "MeatlyMasterMaterial_13";

			// Token: 0x04002765 RID: 10085
			public const string MEATLY_MASTER_MATERIAL_14 = "MeatlyMasterMaterial_14";

			// Token: 0x04002766 RID: 10086
			public const string MEATLY_MASTER_MATERIAL_15 = "MeatlyMasterMaterial_15";

			// Token: 0x04002767 RID: 10087
			public const string MEATLY_MASTER_MATERIAL_16 = "MeatlyMasterMaterial_16";

			// Token: 0x04002768 RID: 10088
			public const string MEATLY_MASTER_MATERIAL_17 = "MeatlyMasterMaterial_17";

			// Token: 0x04002769 RID: 10089
			public const string MOOD_MASTER_MATERIAL_01 = "MoodMasterMaterial_01";

			// Token: 0x0400276A RID: 10090
			public const string TOY_MACHINE_MASTER_MATERIAL_01 = "ToyMachineMasterMaterial_01";

			// Token: 0x0400276B RID: 10091
			public const string TOY_MACHINE_MASTER_MATERIAL_02 = "ToyMachineMasterMaterial_02";

			// Token: 0x0400276C RID: 10092
			public const string VALVE_PUZZLE_MASTER_MATERIAL = "ValvePuzzleMasterMaterial";

			// Token: 0x0400276D RID: 10093
			public const string MELT_TO_INK_BASIC = "MeltToInkBasic";

			// Token: 0x0400276E RID: 10094
			public const string DISSOLVE_MATERIAL = "DissolveMaterial";

			// Token: 0x0400276F RID: 10095
			public const string ENV_TRIGGER_MAT = "ENVTriggerMat";
		}

		// Token: 0x020005D6 RID: 1494
		public static class Shaders
		{
			// Token: 0x04002770 RID: 10096
			public const string MATTS_WIP_ATLAS_TILE = "Matts WIP/Atlas Tile";

			// Token: 0x04002771 RID: 10097
			public const string MEATLY_SHADERS_SPECIAL_SECRET_CHARACTER_HIGHLIGHT = "Meatly Shaders/Special/Secret  Character Highlight";

			// Token: 0x04002772 RID: 10098
			public const string MEATLY_SHADERS_SPECIAL_SECRET_MESSAGE_INK = "Meatly Shaders/Special/Secret Message Ink";

			// Token: 0x04002773 RID: 10099
			public const string MEATLY_SHADERS_SPECIAL_SECRET_MESSAGE_SCREEN = "Meatly Shaders/Special/Secret Message Screen";

			// Token: 0x04002774 RID: 10100
			public const string ASE_TEMPLATE_SHADERS_POST_PROCESS = "ASETemplateShaders/PostProcess";

			// Token: 0x04002775 RID: 10101
			public const string MATTS_WIP_WRONG_MATERIAL = "Matts WIP/Wrong Material";

			// Token: 0x04002776 RID: 10102
			public const string MATTS_WIP_WORLD_TILE = "Matts WIP/World Tile";

			// Token: 0x04002777 RID: 10103
			public const string MEATLY_SHADERS_SURFACES_GLASS = "Meatly Shaders/Surfaces/Glass";

			// Token: 0x04002778 RID: 10104
			public const string MEATLY_SHADERS_SURFACES_MIRROR = "Meatly Shaders/Surfaces/Mirror";

			// Token: 0x04002779 RID: 10105
			public const string MEATLY_SHADERS_CHARACTER_SHADERS_BENDY_MODEL_SHADER = "Meatly Shaders/Character Shaders/Bendy Model Shader";

			// Token: 0x0400277A RID: 10106
			public const string MEATLY_SHADERS_FABRICS_COBWEB = "Meatly Shaders/Fabrics/Cobweb";

			// Token: 0x0400277B RID: 10107
			public const string MEATLY_SHADERS_FABRICS_CURTAIN = "Meatly Shaders/Fabrics/Curtain";

			// Token: 0x0400277C RID: 10108
			public const string MEATLY_SHADERS_FX_DARKNESS_VOLUME = "Meatly Shaders/FX/Darkness Volume";

			// Token: 0x0400277D RID: 10109
			public const string MATTS_WIP_DISSOLVE = "Matts WIP/Dissolve";

			// Token: 0x0400277E RID: 10110
			public const string MEATLY_SHADERS_INK_MAIN_INK_SHADER = "Meatly Shaders/Ink/Main Ink Shader";

			// Token: 0x0400277F RID: 10111
			public const string MEATLY_SHADERS_FX_ELECTRIC_CABLES = "Meatly Shaders/FX/Electric Cables";

			// Token: 0x04002780 RID: 10112
			public const string MEATLY_SHADERS_FX_FIRE = "Meatly Shaders/FX/Fire";

			// Token: 0x04002781 RID: 10113
			public const string MEATLY_SHADERS_FX_CANDLE_SHADER = "Meatly Shaders/FX/Candle Shader";

			// Token: 0x04002782 RID: 10114
			public const string MEATLY_SHADERS_SURFACES_GLOW = "Meatly Shaders/Surfaces/Glow";

			// Token: 0x04002783 RID: 10115
			public const string MEATLY_SHADERS_INK_INK_DECAL_TWO_SIDED = "Meatly Shaders/Ink/Ink Decal Two Sided";

			// Token: 0x04002784 RID: 10116
			public const string MEATLY_SHADERS_CHARACTER_SHADERS_CHARACTER_INK = "Meatly Shaders/Character Shaders/Character Ink";

			// Token: 0x04002785 RID: 10117
			public const string MEATLY_SHADERS_FX_PROJECTION_MATERIAL = "Meatly Shaders/Fx/Projection Material";

			// Token: 0x04002786 RID: 10118
			public const string MEATLY_SHADERS_SURFACES_MEATLY_DECALS = "Meatly Shaders/Surfaces/Meatly Decals";

			// Token: 0x04002787 RID: 10119
			public const string MEATLY_SHADERS_SURFACES_MEATLY_DECALS_WAVE = "Meatly Shaders/Surfaces/Meatly Decals Wave";

			// Token: 0x04002788 RID: 10120
			public const string MEATLY_SHADERS_SURFACES_DIFFUSE = "Meatly Shaders/Surfaces/Diffuse";

			// Token: 0x04002789 RID: 10121
			public const string MEATLY_SHADERS_SURFACES_DIFFUSE_HIGHLIGHT = "Meatly Shaders/Surfaces/Diffuse Highlight";

			// Token: 0x0400278A RID: 10122
			public const string MEATLY_SHADERS_FX_TRANSPARENT_HIGHLIGHT = "Meatly Shaders/FX/Transparent Highlight";

			// Token: 0x0400278B RID: 10123
			public const string MEATLY_SHADERS_SPECIAL_LIGHT_FIXTURE = "Meatly Shaders/Special/Light Fixture";

			// Token: 0x0400278C RID: 10124
			public const string MEATLY_SHADERS_SURFACES_DIFFUSE_NO_BENDY_EFFECT = "Meatly Shaders/Surfaces/Diffuse - No Bendy Effect";

			// Token: 0x0400278D RID: 10125
			public const string MEATLY_SHADERS_SURFACES_DIFFUSE_PAN = "Meatly Shaders/Surfaces/Diffuse Pan";

			// Token: 0x0400278E RID: 10126
			public const string MEATLY_SHADERS_INK_MELT_TO_INK = "Meatly Shaders/Ink/Melt To Ink";

			// Token: 0x0400278F RID: 10127
			public const string MEATLY_SHADERS_INK_PARTICLE_INK = "Meatly Shaders/Ink/Particle Ink";

			// Token: 0x04002790 RID: 10128
			public const string MEATLY_SHADERS_FABRICS_PLANT = "Meatly Shaders/Fabrics/Plant";

			// Token: 0x04002791 RID: 10129
			public const string MATTS_WIP_SKETCHIFY = "Matts WIP/Sketchify";

			// Token: 0x04002792 RID: 10130
			public const string SKYBOX_SKYBOX_COLOR = "Skybox/Skybox Color";

			// Token: 0x04002793 RID: 10131
			public const string MEATLY_SHADERS_FX_SMOKE = "Meatly Shaders/FX/Smoke";

			// Token: 0x04002794 RID: 10132
			public const string MEATLY_SHADERS_SURFACES_WATER = "Meatly Shaders/Surfaces/Water";

			// Token: 0x04002795 RID: 10133
			public const string CUSTOM_BASIC_BLUR = "Custom/BasicBlur";

			// Token: 0x04002796 RID: 10134
			public const string HIDDEN_BRIGHTNESS = "Hidden/Brightness";

			// Token: 0x04002797 RID: 10135
			public const string HIDDEN_SPOT_CLAMP = "Hidden/SpotClamp";

			// Token: 0x04002798 RID: 10136
			public const string HIDDEN_TOONIFY = "Hidden  / Toonify";

			// Token: 0x04002799 RID: 10137
			public const string HIDDEN_VISION_EFFECT_CONSOLE = "Hidden / Vision Effect Console";

			// Token: 0x0400279A RID: 10138
			public const string HIDDEN_VISION_EFFECT = "Hidden / Vision Effect";
		}

		// Token: 0x020005D7 RID: 1495
		public static class Textures
		{
			// Token: 0x0400279B RID: 10139
			public const string CHAPTER_ONE_COLLECTABLES = "UI/ChapterOneCollectables/ChapterOneCollectables";

			// Token: 0x0400279C RID: 10140
			public const string COLLECTABLEBOOKICON = "UI/ObjectiveIcons/collectable_book_icon";

			// Token: 0x0400279D RID: 10141
			public const string COLLECTABLEDOLLICON = "UI/ObjectiveIcons/collectable_doll_icon";

			// Token: 0x0400279E RID: 10142
			public const string COLLECTABLEGEARICON = "UI/ObjectiveIcons/collectable_gear_icon";

			// Token: 0x0400279F RID: 10143
			public const string COLLECTABLEINKWELLICON = "UI/ObjectiveIcons/collectable_inkwell_icon";

			// Token: 0x040027A0 RID: 10144
			public const string COLLECTABLEKEYSICON = "UI/ObjectiveIcons/collectable_keys_icon";

			// Token: 0x040027A1 RID: 10145
			public const string COLLECTABLEKEYSLARGEICON = "UI/ObjectiveIcons/collectable_keys_large_icon";

			// Token: 0x040027A2 RID: 10146
			public const string COLLECTABLERECORDICON = "UI/ObjectiveIcons/collectable_record_icon";

			// Token: 0x040027A3 RID: 10147
			public const string COLLECTABLEWRENCHICON = "UI/ObjectiveIcons/collectable_wrench_icon";

			// Token: 0x040027A4 RID: 10148
			public const string CUTOUTICON = "UI/ObjectiveIcons/cutout_icon";

			// Token: 0x040027A5 RID: 10149
			public const string GEARICON = "UI/ObjectiveIcons/gear_icon";

			// Token: 0x040027A6 RID: 10150
			public const string HEARTICON = "UI/ObjectiveIcons/heart_icon";

			// Token: 0x040027A7 RID: 10151
			public const string POWERCOREICON = "UI/ObjectiveIcons/power_core_icon";

			// Token: 0x040027A8 RID: 10152
			public const string SOUPICON = "UI/ObjectiveIcons/soup_icon";

			// Token: 0x040027A9 RID: 10153
			public const string THICKINKICON = "UI/ObjectiveIcons/thick_ink_icon";

			// Token: 0x040027AA RID: 10154
			public const string EXCLAIMATIONMARKICON = "UI/SeeingToolPrompt/exclaimation_mark_icon";

			// Token: 0x040027AB RID: 10155
			public const string SEEINGTOOLICON = "UI/SeeingToolPrompt/seeing_tool_icon";
		}

		// Token: 0x020005D8 RID: 1496
		public static class Sprites
		{
			// Token: 0x020005D9 RID: 1497
			public class Lookup
			{
				// Token: 0x040027AC RID: 10156
				public const string CHAPTER_ONE_COLLECTABLES = "UI/ChapterOneCollectables/ChapterOneCollectables";

				// Token: 0x040027AD RID: 10157
				public const string COLLECTABLEBOOKICON = "UI/ObjectiveIcons/collectable_book_icon";

				// Token: 0x040027AE RID: 10158
				public const string COLLECTABLEDOLLICON = "UI/ObjectiveIcons/collectable_doll_icon";

				// Token: 0x040027AF RID: 10159
				public const string COLLECTABLEGEARICON = "UI/ObjectiveIcons/collectable_gear_icon";

				// Token: 0x040027B0 RID: 10160
				public const string COLLECTABLEINKWELLICON = "UI/ObjectiveIcons/collectable_inkwell_icon";

				// Token: 0x040027B1 RID: 10161
				public const string COLLECTABLEKEYSICON = "UI/ObjectiveIcons/collectable_keys_icon";

				// Token: 0x040027B2 RID: 10162
				public const string COLLECTABLEKEYSLARGEICON = "UI/ObjectiveIcons/collectable_keys_large_icon";

				// Token: 0x040027B3 RID: 10163
				public const string COLLECTABLERECORDICON = "UI/ObjectiveIcons/collectable_record_icon";

				// Token: 0x040027B4 RID: 10164
				public const string COLLECTABLEWRENCHICON = "UI/ObjectiveIcons/collectable_wrench_icon";

				// Token: 0x040027B5 RID: 10165
				public const string CUTOUTICON = "UI/ObjectiveIcons/cutout_icon";

				// Token: 0x040027B6 RID: 10166
				public const string GEARICON = "UI/ObjectiveIcons/gear_icon";

				// Token: 0x040027B7 RID: 10167
				public const string HEARTICON = "UI/ObjectiveIcons/heart_icon";

				// Token: 0x040027B8 RID: 10168
				public const string POWERCOREICON = "UI/ObjectiveIcons/power_core_icon";

				// Token: 0x040027B9 RID: 10169
				public const string SOUPICON = "UI/ObjectiveIcons/soup_icon";

				// Token: 0x040027BA RID: 10170
				public const string THICKINKICON = "UI/ObjectiveIcons/thick_ink_icon";

				// Token: 0x040027BB RID: 10171
				public const string EXCLAIMATIONMARKICON = "UI/SeeingToolPrompt/exclaimation_mark_icon";

				// Token: 0x040027BC RID: 10172
				public const string SEEINGTOOLICON = "UI/SeeingToolPrompt/seeing_tool_icon";
			}

			// Token: 0x020005DA RID: 1498
			public class Lists
			{
				// Token: 0x040027BD RID: 10173
				public const string COLLECTABLE_BOOK = "collectable_book";

				// Token: 0x040027BE RID: 10174
				public const string COLLECTABLE_DOLL = "collectable_doll";

				// Token: 0x040027BF RID: 10175
				public const string COLLECTABLE_GEAR = "collectable_gear";

				// Token: 0x040027C0 RID: 10176
				public const string COLLECTABLE_INKWELL = "collectable_inkwell";

				// Token: 0x040027C1 RID: 10177
				public const string COLLECTABLE_KEYS = "collectable_keys";

				// Token: 0x040027C2 RID: 10178
				public const string COLLECTABLE_RECORD = "collectable_record";

				// Token: 0x040027C3 RID: 10179
				public const string COLLECTABLE_WRENCH = "collectable_wrench";

				// Token: 0x040027C4 RID: 10180
				public const string COLLECTABLE_BOOK_ICON = "collectable_book_icon";

				// Token: 0x040027C5 RID: 10181
				public const string COLLECTABLE_DOLL_ICON = "collectable_doll_icon";

				// Token: 0x040027C6 RID: 10182
				public const string COLLECTABLE_GEAR_ICON = "collectable_gear_icon";

				// Token: 0x040027C7 RID: 10183
				public const string COLLECTABLE_INKWELL_ICON = "collectable_inkwell_icon";

				// Token: 0x040027C8 RID: 10184
				public const string COLLECTABLE_KEYS_ICON = "collectable_keys_icon";

				// Token: 0x040027C9 RID: 10185
				public const string COLLECTABLE_KEYS_LARGE_ICON = "collectable_keys_large_icon";

				// Token: 0x040027CA RID: 10186
				public const string COLLECTABLE_RECORD_ICON = "collectable_record_icon";

				// Token: 0x040027CB RID: 10187
				public const string COLLECTABLE_WRENCH_ICON = "collectable_wrench_icon";

				// Token: 0x040027CC RID: 10188
				public const string CUTOUT_ICON = "cutout_icon";

				// Token: 0x040027CD RID: 10189
				public const string GEAR_ICON = "gear_icon";

				// Token: 0x040027CE RID: 10190
				public const string HEART_ICON = "heart_icon";

				// Token: 0x040027CF RID: 10191
				public const string POWER_CORE_ICON = "power_core_icon";

				// Token: 0x040027D0 RID: 10192
				public const string SOUP_ICON = "soup_icon";

				// Token: 0x040027D1 RID: 10193
				public const string THICK_INK_ICON = "thick_ink_icon";

				// Token: 0x040027D2 RID: 10194
				public const string EXCLAIMATION_MARK_ICON = "exclaimation_mark_icon";

				// Token: 0x040027D3 RID: 10195
				public const string SEEING_TOOL_ICON = "seeing_tool_icon";
			}
		}

		// Token: 0x020005DB RID: 1499
		public static class ScriptableObjects
		{
			// Token: 0x040027D4 RID: 10196
			public const string PROJECT_SETTINGS = "ProjectSettings";

			// Token: 0x040027D5 RID: 10197
			public const string VERSION_SETTINGS = "VersionSettings";
		}

		// Token: 0x020005DC RID: 1500
		public static class S13Audio
		{
			// Token: 0x040027D6 RID: 10198
			public const string S13AMBIENTLOOPTRIGGER_TEMPLATE = "S13AmbientLoopTrigger_TEMPLATE";

			// Token: 0x040027D7 RID: 10199
			public const string AMB_INK_BUBBLES_ELEVATOR = "amb_ink_bubbles_elevator";

			// Token: 0x040027D8 RID: 10200
			public const string AMB_INK_PIPE_ELEVATOR = "amb_ink_pipe_elevator";

			// Token: 0x040027D9 RID: 10201
			public const string AMB_WOOD_DEEP_CREAK = "amb_wood_deep_creak";

			// Token: 0x040027DA RID: 10202
			public const string AMB_WOOD_SMALL = "amb_wood_small";

			// Token: 0x040027DB RID: 10203
			public const string ANIM_PROJECTIONIST_FIGHT = "anim_projectionist_fight";

			// Token: 0x040027DC RID: 10204
			public const string FOLEY_ALICE_FALLS = "foley_alice_falls";

			// Token: 0x040027DD RID: 10205
			public const string STEP_DIRT = "step_dirt";

			// Token: 0x040027DE RID: 10206
			public const string STEP_TILE = "step_tile";

			// Token: 0x040027DF RID: 10207
			public const string STEP_WOOD = "step_wood";

			// Token: 0x040027E0 RID: 10208
			public const string STEP_METAL = "step_metal";

			// Token: 0x040027E1 RID: 10209
			public const string STEP_INK = "step_ink";

			// Token: 0x040027E2 RID: 10210
			public const string HIT = "hit";

			// Token: 0x040027E3 RID: 10211
			public const string LAND_DIRT = "land_dirt";

			// Token: 0x040027E4 RID: 10212
			public const string LAND_TILE = "land_tile";

			// Token: 0x040027E5 RID: 10213
			public const string LAND_WOOD = "land_wood";

			// Token: 0x040027E6 RID: 10214
			public const string LAND_METAL = "land_metal";

			// Token: 0x040027E7 RID: 10215
			public const string JUMP = "jump";

			// Token: 0x040027E8 RID: 10216
			public const string STEP_WATER = "step_water";

			// Token: 0x040027E9 RID: 10217
			public const string VENT = "vent";

			// Token: 0x040027EA RID: 10218
			public const string PICKUP = "pickup";

			// Token: 0x040027EB RID: 10219
			public const string LAND_WATER = "land_water";

			// Token: 0x040027EC RID: 10220
			public const string FOLEY_BANG_HEAD = "foley_bang_head";

			// Token: 0x040027ED RID: 10221
			public const string FOLEY_PIPE_MENACE = "foley_pipe_menace";

			// Token: 0x040027EE RID: 10222
			public const string LOSTONE_CRYING = "lostone_crying";

			// Token: 0x040027EF RID: 10223
			public const string THRUST = "thrust";

			// Token: 0x040027F0 RID: 10224
			public const string FALL = "fall";

			// Token: 0x040027F1 RID: 10225
			public const string CLOSED = "closed";

			// Token: 0x040027F2 RID: 10226
			public const string OPEN = "open";

			// Token: 0x040027F3 RID: 10227
			public const string SMASH = "smash";

			// Token: 0x040027F4 RID: 10228
			public const string GUSH = "gush";

			// Token: 0x040027F5 RID: 10229
			public const string SPIN = "spin";

			// Token: 0x040027F6 RID: 10230
			public const string ATTACK1 = "attack1";

			// Token: 0x040027F7 RID: 10231
			public const string ATTACK2 = "attack2";

			// Token: 0x040027F8 RID: 10232
			public const string HURT1 = "hurt1";

			// Token: 0x040027F9 RID: 10233
			public const string HURT2 = "hurt2";

			// Token: 0x040027FA RID: 10234
			public const string HURT3 = "hurt3";

			// Token: 0x040027FB RID: 10235
			public const string HURT4 = "hurt4";

			// Token: 0x040027FC RID: 10236
			public const string ENGINE_IDLE_LOOP = "engine_idle_loop";

			// Token: 0x040027FD RID: 10237
			public const string ENGINE_WORK_ON = "engine_work_on";

			// Token: 0x040027FE RID: 10238
			public const string ENGINE_WORK_LOOP = "engine_work_loop";

			// Token: 0x040027FF RID: 10239
			public const string ENGINE_WORK_OFF = "engine_work_off";

			// Token: 0x04002800 RID: 10240
			public const string ENGINE_START = "engine_start";

			// Token: 0x04002801 RID: 10241
			public const string ENGINE_STOP = "engine_stop";

			// Token: 0x04002802 RID: 10242
			public const string CONTROL_FORWARD = "control_forward";

			// Token: 0x04002803 RID: 10243
			public const string CONTROL_BACK = "control_back";

			// Token: 0x04002804 RID: 10244
			public const string CONTROL_START = "control_start";

			// Token: 0x04002805 RID: 10245
			public const string CONTROL_STOP = "control_stop";

			// Token: 0x04002806 RID: 10246
			public const string CONTROL_STEER = "control_steer";

			// Token: 0x04002807 RID: 10247
			public const string CONTROL_LOOP = "control_loop";

			// Token: 0x04002808 RID: 10248
			public const string WATER_MOVES = "water_moves";

			// Token: 0x04002809 RID: 10249
			public const string WATER_MOVING_LOOP = "water_moving_loop";

			// Token: 0x0400280A RID: 10250
			public const string WATER_IDLE = "water_idle";

			// Token: 0x0400280B RID: 10251
			public const string INK_CLOGGED = "ink_clogged";

			// Token: 0x0400280C RID: 10252
			public const string INK_REMOVED = "ink_removed";

			// Token: 0x0400280D RID: 10253
			public const string FOOTSTEPS = "footsteps";

			// Token: 0x0400280E RID: 10254
			public const string BATTLE_FALL = "battle_fall";

			// Token: 0x0400280F RID: 10255
			public const string DEATH_FINAL = "death_final";

			// Token: 0x04002810 RID: 10256
			public const string REVEAL = "reveal";

			// Token: 0x04002811 RID: 10257
			public const string CHARGE = "charge";

			// Token: 0x04002812 RID: 10258
			public const string LAND = "land";

			// Token: 0x04002813 RID: 10259
			public const string POUND = "pound";

			// Token: 0x04002814 RID: 10260
			public const string TOSS = "toss";

			// Token: 0x04002815 RID: 10261
			public const string BOUNCE = "bounce";

			// Token: 0x04002816 RID: 10262
			public const string DROP = "drop";

			// Token: 0x04002817 RID: 10263
			public const string IMPACT = "impact";

			// Token: 0x04002818 RID: 10264
			public const string DIALOGUE = "dialogue";

			// Token: 0x04002819 RID: 10265
			public const string CLOSE = "close";

			// Token: 0x0400281A RID: 10266
			public const string FIRE = "fire";

			// Token: 0x0400281B RID: 10267
			public const string BELL = "bell";

			// Token: 0x0400281C RID: 10268
			public const string RESET = "reset";

			// Token: 0x0400281D RID: 10269
			public const string SLIDE = "slide";

			// Token: 0x0400281E RID: 10270
			public const string SWING = "swing";

			// Token: 0x0400281F RID: 10271
			public const string RUN = "run";

			// Token: 0x04002820 RID: 10272
			public const string FLOW = "flow";

			// Token: 0x04002821 RID: 10273
			public const string ADD_INK = "add_ink";

			// Token: 0x04002822 RID: 10274
			public const string SELECT = "select";

			// Token: 0x04002823 RID: 10275
			public const string MAKING = "making";

			// Token: 0x04002824 RID: 10276
			public const string HIDE = "hide";

			// Token: 0x04002825 RID: 10277
			public const string APPEAR = "appear";

			// Token: 0x04002826 RID: 10278
			public const string DEATH = "death";

			// Token: 0x04002827 RID: 10279
			public const string BAD = "bad";

			// Token: 0x04002828 RID: 10280
			public const string GOOD = "good";

			// Token: 0x04002829 RID: 10281
			public const string SFX_BARREL_INK_GUSH = "sfx_barrel_ink_gush";

			// Token: 0x0400282A RID: 10282
			public const string SFX_BARREL_SMASHED = "sfx_barrel_smashed";

			// Token: 0x0400282B RID: 10283
			public const string SFX_BERT_ARM_DESTROYED1 = "sfx_bert_arm_destroyed 1";

			// Token: 0x0400282C RID: 10284
			public const string SFX_BERT_ARM_DESTROYED2 = "sfx_bert_arm_destroyed 2";

			// Token: 0x0400282D RID: 10285
			public const string SFX_BERT_ARM_DESTROYED3 = "sfx_bert_arm_destroyed 3";

			// Token: 0x0400282E RID: 10286
			public const string SFX_BERT_ARM_DESTROYED4 = "sfx_bert_arm_destroyed 4";

			// Token: 0x0400282F RID: 10287
			public const string SFX_BLADE_THRUST = "sfx_blade_thrust";

			// Token: 0x04002830 RID: 10288
			public const string SFX_BOOK_FALLS = "sfx_book_falls";

			// Token: 0x04002831 RID: 10289
			public const string SFX_BOOK_PUSHED = "sfx_book_pushed";

			// Token: 0x04002832 RID: 10290
			public const string SFX_BOX_CRASH = "sfx_box_crash";

			// Token: 0x04002833 RID: 10291
			public const string SFX_BOX_FALLS = "sfx_box_falls";

			// Token: 0x04002834 RID: 10292
			public const string GEAR_FIT = "gear_fit";

			// Token: 0x04002835 RID: 10293
			public const string START = "start";

			// Token: 0x04002836 RID: 10294
			public const string RUNNING = "running";

			// Token: 0x04002837 RID: 10295
			public const string STOP = "stop";

			// Token: 0x04002838 RID: 10296
			public const string ENTER = "enter";

			// Token: 0x04002839 RID: 10297
			public const string ROPE = "rope";

			// Token: 0x0400283A RID: 10298
			public const string BREAKDOWN = "breakdown";

			// Token: 0x0400283B RID: 10299
			public const string END = "end";

			// Token: 0x0400283C RID: 10300
			public const string EXIT = "exit";

			// Token: 0x0400283D RID: 10301
			public const string SWAY = "sway";

			// Token: 0x0400283E RID: 10302
			public const string SFX_CRATE_SMASHED = "sfx_crate_smashed";

			// Token: 0x0400283F RID: 10303
			public const string SFX_DART_LAND = "sfx_dart_land";

			// Token: 0x04002840 RID: 10304
			public const string SFX_DOOR_SLIDES_OPEN = "sfx_door_slides_open";

			// Token: 0x04002841 RID: 10305
			public const string SFX_FAIR_GAME_STALLS_OPEN = "sfx_fair_game_stalls_open";

			// Token: 0x04002842 RID: 10306
			public const string SFX_HAUNTED_HOUSE_GATE_OPEN = "sfx_haunted_house_gate_open";

			// Token: 0x04002843 RID: 10307
			public const string SFX_HAUNTED_HOUSE_POPUPS = "sfx_haunted_house_popups";

			// Token: 0x04002844 RID: 10308
			public const string SFX_INK_MAKER_BLOB = "sfx_ink_maker_blob";

			// Token: 0x04002845 RID: 10309
			public const string SFX_INK_MAKER_MADE_CERAMIC = "sfx_ink_maker_made_ceramic";

			// Token: 0x04002846 RID: 10310
			public const string SFX_INK_MAKER_MADE_METAL = "sfx_ink_maker_made_metal";

			// Token: 0x04002847 RID: 10311
			public const string SFX_INK_MAKER_MADE_WOOD = "sfx_ink_maker_made_wood";

			// Token: 0x04002848 RID: 10312
			public const string SFX_LIGHTBULB_DETAIL = "sfx_lightbulb_detail";

			// Token: 0x04002849 RID: 10313
			public const string SFX_PANEL_FLIP_OPEN = "sfx_panel_flip_open";

			// Token: 0x0400284A RID: 10314
			public const string SFX_POOL_BALL_HIT = "sfx_pool_ball_hit";

			// Token: 0x0400284B RID: 10315
			public const string SFX_RECORDPLAYER = "sfx_recordplayer";

			// Token: 0x0400284C RID: 10316
			public const string SFX_SPOTLIGHT_ON = "sfx_spotlight_on";

			// Token: 0x0400284D RID: 10317
			public const string SFX_STEAM_BURST = "sfx_steam_burst";

			// Token: 0x0400284E RID: 10318
			public const string SFX_THICK_INK_COLLECTED = "sfx_thick_ink_collected";

			// Token: 0x0400284F RID: 10319
			public const string SFX_VENT_ENTER = "sfx_vent_enter";

			// Token: 0x04002850 RID: 10320
			public const string SFX_VENT_EXIT = "sfx_vent_exit";

			// Token: 0x04002851 RID: 10321
			public const string SFX_WAREHOUSE_TURNS_ON = "sfx_warehouse_turns_on";

			// Token: 0x04002852 RID: 10322
			public const string AMB_CAGE_IDLE_MOVES = "amb_cage_idle_moves";

			// Token: 0x04002853 RID: 10323
			public const string AMB_DARK_TRANSITION = "amb_dark_transition";

			// Token: 0x04002854 RID: 10324
			public const string AMB_FIRE = "amb_fire";

			// Token: 0x04002855 RID: 10325
			public const string AMB_INK_PILAR = "amb_ink_pilar";

			// Token: 0x04002856 RID: 10326
			public const string AMB_INK_RAIN_TMG = "amb_ink_rain_tmg";

			// Token: 0x04002857 RID: 10327
			public const string AMB_PANEL_HUM = "amb_panel_hum";

			// Token: 0x04002858 RID: 10328
			public const string AMB_ROPE_IDLE = "amb_rope_idle";

			// Token: 0x04002859 RID: 10329
			public const string AMB_SMALL_GEARS_LOOP = "amb_small_gears_loop";

			// Token: 0x0400285A RID: 10330
			public const string AMB_SWITCHES_IDLE = "amb_switches_idle";

			// Token: 0x0400285B RID: 10331
			public const string AMB_TILE_3GEARS = "amb_tile_3gears";

			// Token: 0x0400285C RID: 10332
			public const string AMB_TILE_MECH1 = "amb_tile_mech1";

			// Token: 0x0400285D RID: 10333
			public const string AMB_TILE_MECH2 = "amb_tile_mech2";

			// Token: 0x0400285E RID: 10334
			public const string AMB_TILE_MECH3 = "amb_tile_mech3";

			// Token: 0x0400285F RID: 10335
			public const string AMB_TILE_WALL_MECH = "amb_tile_wall_mech";

			// Token: 0x04002860 RID: 10336
			public const string AMB_VENT_AIR_LOOP = "amb_vent_air_loop";

			// Token: 0x04002861 RID: 10337
			public const string AMB_WOOD_LIGHT_CREAK = "amb_wood_light_creak";

			// Token: 0x04002862 RID: 10338
			public const string AMB_AIRY_OUTDOOR_LOOP = "amb_airy_outdoor_loop";

			// Token: 0x04002863 RID: 10339
			public const string AMB_BENDY_CREEPING_LOOP = "amb_bendy_creeping_loop";

			// Token: 0x04002864 RID: 10340
			public const string AMB_BOOK_PAPERS_01 = "amb_book_papers_01";

			// Token: 0x04002865 RID: 10341
			public const string AMB_BOOK_PAPERS_02 = "amb_book_papers_02";

			// Token: 0x04002866 RID: 10342
			public const string AMB_BOOK_PAPERS_03 = "amb_book_papers_03";

			// Token: 0x04002867 RID: 10343
			public const string AMB_BOOK_PAPERS_04 = "amb_book_papers_04";

			// Token: 0x04002868 RID: 10344
			public const string AMB_BOOK_PAPERS_05 = "amb_book_papers_05";

			// Token: 0x04002869 RID: 10345
			public const string AMB_BRIDGE_BLEND_LOOP = "amb_bridge_blend_loop";

			// Token: 0x0400286A RID: 10346
			public const string AMB_CAGE_IDLE_MOVES_01 = "amb_cage_idle_moves_01";

			// Token: 0x0400286B RID: 10347
			public const string AMB_CAGE_IDLE_MOVES_02 = "amb_cage_idle_moves_02";

			// Token: 0x0400286C RID: 10348
			public const string AMB_CAGE_IDLE_MOVES_03 = "amb_cage_idle_moves_03";

			// Token: 0x0400286D RID: 10349
			public const string AMB_CAGE_IDLE_MOVES_04 = "amb_cage_idle_moves_04";

			// Token: 0x0400286E RID: 10350
			public const string AMB_CAGE_IDLE_MOVES_05 = "amb_cage_idle_moves_05";

			// Token: 0x0400286F RID: 10351
			public const string AMB_CAGE_IDLE_MOVES_06 = "amb_cage_idle_moves_06";

			// Token: 0x04002870 RID: 10352
			public const string AMB_CAGE_IDLE_MOVES_07 = "amb_cage_idle_moves_07";

			// Token: 0x04002871 RID: 10353
			public const string AMB_CHAINS_LOOP = "amb_chains_loop";

			// Token: 0x04002872 RID: 10354
			public const string AMB_CHAIN_CLINKS_01 = "amb_chain_clinks_01";

			// Token: 0x04002873 RID: 10355
			public const string AMB_CHAIN_CLINKS_02 = "amb_chain_clinks_02";

			// Token: 0x04002874 RID: 10356
			public const string AMB_CHAIN_CLINKS_03 = "amb_chain_clinks_03";

			// Token: 0x04002875 RID: 10357
			public const string AMB_CHAIN_CLINKS_04 = "amb_chain_clinks_04";

			// Token: 0x04002876 RID: 10358
			public const string AMB_CHAIN_CLINKS_05 = "amb_chain_clinks_05";

			// Token: 0x04002877 RID: 10359
			public const string AMB_CHAIN_CLINKS_06 = "amb_chain_clinks_06";

			// Token: 0x04002878 RID: 10360
			public const string AMB_CHAPTER1_BAKE = "amb_chapter1_bake";

			// Token: 0x04002879 RID: 10361
			public const string AMB_CLOSEUP_ROOMTONE_LOOP = "amb_closeup_roomtone_loop";

			// Token: 0x0400287A RID: 10362
			public const string AMB_DEEP_HOLLOW_TONAL_LOOP = "amb_deep_hollow_tonal_loop";

			// Token: 0x0400287B RID: 10363
			public const string AMB_FIRE_LOOP = "amb_fire_loop";

			// Token: 0x0400287C RID: 10364
			public const string AMB_GIANT_INK_BAKED_LOOP = "amb_giant_ink_baked_loop";

			// Token: 0x0400287D RID: 10365
			public const string AMB_INDUSTRIAL_ECHOES_LOOP = "amb_industrial_echoes_loop";

			// Token: 0x0400287E RID: 10366
			public const string AMB_INK_PIPE_LOOP = "amb_ink_pipe_loop";

			// Token: 0x0400287F RID: 10367
			public const string AMB_INK_SLIME_IDLE_LOOP = "amb_ink_slime_idle_loop";

			// Token: 0x04002880 RID: 10368
			public const string AMB_INK_WATERFALL_LOOP = "amb_ink_waterfall_loop";

			// Token: 0x04002881 RID: 10369
			public const string AMB_JOEY_DISHES = "amb_joey_dishes";

			// Token: 0x04002882 RID: 10370
			public const string AMB_JOEY_KITCHEN = "amb_joey_kitchen";

			// Token: 0x04002883 RID: 10371
			public const string AMB_METAL_IDLE_01 = "amb_metal_idle_01";

			// Token: 0x04002884 RID: 10372
			public const string AMB_METAL_IDLE_02 = "amb_metal_idle_02";

			// Token: 0x04002885 RID: 10373
			public const string AMB_METAL_IDLE_03 = "amb_metal_idle_03";

			// Token: 0x04002886 RID: 10374
			public const string AMB_METAL_IDLE_04 = "amb_metal_idle_04";

			// Token: 0x04002887 RID: 10375
			public const string AMB_METAL_IDLE_05 = "amb_metal_idle_05";

			// Token: 0x04002888 RID: 10376
			public const string AMB_METAL_IDLE_06 = "amb_metal_idle_06";

			// Token: 0x04002889 RID: 10377
			public const string AMB_METAL_IDLE_07 = "amb_metal_idle_07";

			// Token: 0x0400288A RID: 10378
			public const string AMB_METAL_IDLE_08 = "amb_metal_idle_08";

			// Token: 0x0400288B RID: 10379
			public const string AMB_METAL_IDLE_09 = "amb_metal_idle_09";

			// Token: 0x0400288C RID: 10380
			public const string AMB_ORIGINAL_AMBIENCE_LOOP = "amb_original_ambience_loop";

			// Token: 0x0400288D RID: 10381
			public const string AMB_ORIGINAL_HORROR_LOOP = "amb_original_horror_loop";

			// Token: 0x0400288E RID: 10382
			public const string AMB_PROP_LIGHT_FLICKER = "amb_prop_light_flicker";

			// Token: 0x0400288F RID: 10383
			public const string AMB_ROPE_CREAKS_01 = "amb_rope_creaks_01";

			// Token: 0x04002890 RID: 10384
			public const string AMB_ROPE_CREAKS_02 = "amb_rope_creaks_02";

			// Token: 0x04002891 RID: 10385
			public const string AMB_ROPE_CREAKS_03 = "amb_rope_creaks_03";

			// Token: 0x04002892 RID: 10386
			public const string AMB_ROPE_CREAKS_04 = "amb_rope_creaks_04";

			// Token: 0x04002893 RID: 10387
			public const string AMB_ROPE_CREAKS_05 = "amb_rope_creaks_05";

			// Token: 0x04002894 RID: 10388
			public const string AMB_ROPE_CREAKS_06 = "amb_rope_creaks_06";

			// Token: 0x04002895 RID: 10389
			public const string AMB_ROPE_CREAKS_07 = "amb_rope_creaks_07";

			// Token: 0x04002896 RID: 10390
			public const string AMB_ROPE_CREAKS_08 = "amb_rope_creaks_08";

			// Token: 0x04002897 RID: 10391
			public const string AMB_ROPE_CREAKS_09 = "amb_rope_creaks_09";

			// Token: 0x04002898 RID: 10392
			public const string AMB_ROPE_CREAKS_10 = "amb_rope_creaks_10";

			// Token: 0x04002899 RID: 10393
			public const string AMB_ROPE_CREAKS_11 = "amb_rope_creaks_11";

			// Token: 0x0400289A RID: 10394
			public const string AMB_STEADY_WORLD_AIR_LOOP = "amb_steady_world_air_loop";

			// Token: 0x0400289B RID: 10395
			public const string AMB_STONES_FALLING_DISTANT_01 = "amb_stones_falling_distant_01";

			// Token: 0x0400289C RID: 10396
			public const string AMB_STONES_FALLING_DISTANT_02 = "amb_stones_falling_distant_02";

			// Token: 0x0400289D RID: 10397
			public const string AMB_STONES_FALLING_DISTANT_03 = "amb_stones_falling_distant_03";

			// Token: 0x0400289E RID: 10398
			public const string AMB_STONES_FALLING_DISTANT_04 = "amb_stones_falling_distant_04";

			// Token: 0x0400289F RID: 10399
			public const string AMB_STONES_FALLING_DISTANT_05 = "amb_stones_falling_distant_05";

			// Token: 0x040028A0 RID: 10400
			public const string AMB_STONES_FALLING_DISTANT_06 = "amb_stones_falling_distant_06";

			// Token: 0x040028A1 RID: 10401
			public const string AMB_STONE_CRUMBLE_MOVE_01 = "amb_stone_crumble_move_01";

			// Token: 0x040028A2 RID: 10402
			public const string AMB_STONE_CRUMBLE_MOVE_02 = "amb_stone_crumble_move_02";

			// Token: 0x040028A3 RID: 10403
			public const string AMB_STONE_CRUMBLE_MOVE_03 = "amb_stone_crumble_move_03";

			// Token: 0x040028A4 RID: 10404
			public const string AMB_STONE_CRUMBLE_MOVE_04 = "amb_stone_crumble_move_04";

			// Token: 0x040028A5 RID: 10405
			public const string AMB_STONE_CRUMBLE_MOVE_05 = "amb_stone_crumble_move_05";

			// Token: 0x040028A6 RID: 10406
			public const string AMB_STONE_CRUMBLE_MOVE_06 = "amb_stone_crumble_move_06";

			// Token: 0x040028A7 RID: 10407
			public const string AMB_STONE_CRUMBLE_MOVE_07 = "amb_stone_crumble_move_07";

			// Token: 0x040028A8 RID: 10408
			public const string AMB_STONE_CRUMBLE_MOVE_08 = "amb_stone_crumble_move_08";

			// Token: 0x040028A9 RID: 10409
			public const string AMB_STONE_CRUMBLE_MOVE_09 = "amb_stone_crumble_move_09";

			// Token: 0x040028AA RID: 10410
			public const string AMB_SWITCHES_01 = "amb_switches_01";

			// Token: 0x040028AB RID: 10411
			public const string AMB_SWITCHES_02 = "amb_switches_02";

			// Token: 0x040028AC RID: 10412
			public const string AMB_SWITCHES_03 = "amb_switches_03";

			// Token: 0x040028AD RID: 10413
			public const string AMB_SWITCHES_04 = "amb_switches_04";

			// Token: 0x040028AE RID: 10414
			public const string AMB_SWITCHES_05 = "amb_switches_05";

			// Token: 0x040028AF RID: 10415
			public const string AMB_THRONE_ROOM_LOOP = "amb_throne_room_loop";

			// Token: 0x040028B0 RID: 10416
			public const string AMB_TUNNEL_LOOP = "amb_tunnel_loop";

			// Token: 0x040028B1 RID: 10417
			public const string AMB_VENT_AIR_RATTLE_LOOP = "amb_vent_air_rattle_loop";

			// Token: 0x040028B2 RID: 10418
			public const string AMB_VENT_PING_01 = "amb_vent_ping_01";

			// Token: 0x040028B3 RID: 10419
			public const string AMB_VENT_PING_02 = "amb_vent_ping_02";

			// Token: 0x040028B4 RID: 10420
			public const string AMB_VENT_RATTLES_01 = "amb_vent_rattles_01";

			// Token: 0x040028B5 RID: 10421
			public const string AMB_VENT_RATTLES_02 = "amb_vent_rattles_02";

			// Token: 0x040028B6 RID: 10422
			public const string AMB_VENT_RATTLES_03 = "amb_vent_rattles_03";

			// Token: 0x040028B7 RID: 10423
			public const string AMB_VENT_RATTLES_04 = "amb_vent_rattles_04";

			// Token: 0x040028B8 RID: 10424
			public const string AMB_VENT_RATTLES_05 = "amb_vent_rattles_05";

			// Token: 0x040028B9 RID: 10425
			public const string AMB_VENT_RATTLES_06 = "amb_vent_rattles_06";

			// Token: 0x040028BA RID: 10426
			public const string AMB_VENT_RATTLES_07 = "amb_vent_rattles_07";

			// Token: 0x040028BB RID: 10427
			public const string AMB_WATER_DRIP_01 = "amb_water_drip_01";

			// Token: 0x040028BC RID: 10428
			public const string AMB_WATER_DRIP_02 = "amb_water_drip_02";

			// Token: 0x040028BD RID: 10429
			public const string AMB_WATER_DRIP_03 = "amb_water_drip_03";

			// Token: 0x040028BE RID: 10430
			public const string AMB_WATER_DRIP_04 = "amb_water_drip_04";

			// Token: 0x040028BF RID: 10431
			public const string AMB_WATER_DRIP_05 = "amb_water_drip_05";

			// Token: 0x040028C0 RID: 10432
			public const string AMB_WATER_DRIP_06 = "amb_water_drip_06";

			// Token: 0x040028C1 RID: 10433
			public const string AMB_WATER_FLOODED_LOOP = "amb_water_flooded_loop";

			// Token: 0x040028C2 RID: 10434
			public const string AMB_WIND_LOW_HOWLS = "amb_wind_low_howls";

			// Token: 0x040028C3 RID: 10435
			public const string AMB_WIND_TONES_LOOP = "amb_wind_tones_loop";

			// Token: 0x040028C4 RID: 10436
			public const string AMB_WOOD_DEEP_CREAK_01 = "amb_wood_deep_creak_01";

			// Token: 0x040028C5 RID: 10437
			public const string AMB_WOOD_DEEP_CREAK_02 = "amb_wood_deep_creak_02";

			// Token: 0x040028C6 RID: 10438
			public const string AMB_WOOD_DEEP_CREAK_03 = "amb_wood_deep_creak_03";

			// Token: 0x040028C7 RID: 10439
			public const string AMB_WOOD_DEEP_CREAK_04 = "amb_wood_deep_creak_04";

			// Token: 0x040028C8 RID: 10440
			public const string AMB_WOOD_DEEP_CREAK_05 = "amb_wood_deep_creak_05";

			// Token: 0x040028C9 RID: 10441
			public const string AMB_WOOD_DEEP_CREAK_06 = "amb_wood_deep_creak_06";

			// Token: 0x040028CA RID: 10442
			public const string AMB_WOOD_SMALL_01 = "amb_wood_small_01";

			// Token: 0x040028CB RID: 10443
			public const string AMB_WOOD_SMALL_02 = "amb_wood_small_02";

			// Token: 0x040028CC RID: 10444
			public const string AMB_WOOD_SMALL_03 = "amb_wood_small_03";

			// Token: 0x040028CD RID: 10445
			public const string AMB_WOOD_SMALL_04 = "amb_wood_small_04";

			// Token: 0x040028CE RID: 10446
			public const string AMB_WOOD_SMALL_05 = "amb_wood_small_05";

			// Token: 0x040028CF RID: 10447
			public const string AMB_WOOD_SMALL_06 = "amb_wood_small_06";

			// Token: 0x040028D0 RID: 10448
			public const string DIA_ALLISON_BATTLESOUND_01 = "dia_allison_battlesound_01";

			// Token: 0x040028D1 RID: 10449
			public const string DIA_ALLISON_BATTLESOUND_02 = "dia_allison_battlesound_02";

			// Token: 0x040028D2 RID: 10450
			public const string DIA_ALLISON_BATTLESOUND_03 = "dia_allison_battlesound_03";

			// Token: 0x040028D3 RID: 10451
			public const string DIA_ALLISON_BATTLESOUND_04 = "dia_allison_battlesound_04";

			// Token: 0x040028D4 RID: 10452
			public const string DIA_SAMMY_SAMMYBATTLESOUND_01 = "dia_sammy_sammybattlesound_01";

			// Token: 0x040028D5 RID: 10453
			public const string DIA_SAMMY_SAMMYBATTLESOUND_02 = "dia_sammy_sammybattlesound_02";

			// Token: 0x040028D6 RID: 10454
			public const string DIA_SAMMY_SAMMYBATTLESOUND_03 = "dia_sammy_sammybattlesound_03";

			// Token: 0x040028D7 RID: 10455
			public const string DIA_SAMMY_SAMMYBATTLESOUND_04 = "dia_sammy_sammybattlesound_04";

			// Token: 0x040028D8 RID: 10456
			public const string DIA_SAMMY_SAMMYBATTLESOUND_05 = "dia_sammy_sammybattlesound_05";

			// Token: 0x040028D9 RID: 10457
			public const string DIA_SAMMY_SAMMYBATTLESOUND_06 = "dia_sammy_sammybattlesound_06";

			// Token: 0x040028DA RID: 10458
			public const string DIA_SAMMY_SAMMYBATTLESOUND_07 = "dia_sammy_sammybattlesound_07";

			// Token: 0x040028DB RID: 10459
			public const string DIA_SAMMY_SAMMYBATTLESOUND_08 = "dia_sammy_sammybattlesound_08";

			// Token: 0x040028DC RID: 10460
			public const string DIA_SAMMY_SAMMYBATTLESOUND_09 = "dia_sammy_sammybattlesound_09";

			// Token: 0x040028DD RID: 10461
			public const string DIA_SAMMY_SAMMYBATTLESOUND_10 = "dia_sammy_sammybattlesound_10";

			// Token: 0x040028DE RID: 10462
			public const string FOLEY_ALLISON_MOVES_LOOP = "foley_allison_moves_loop";

			// Token: 0x040028DF RID: 10463
			public const string FOLEY_ALLISON_STEP_ALL_LIGHT_01 = "foley_allison_step_all_light_01";

			// Token: 0x040028E0 RID: 10464
			public const string FOLEY_ALLISON_STEP_ALL_LIGHT_02 = "foley_allison_step_all_light_02";

			// Token: 0x040028E1 RID: 10465
			public const string FOLEY_ALLISON_STEP_ALL_LIGHT_03 = "foley_allison_step_all_light_03";

			// Token: 0x040028E2 RID: 10466
			public const string FOLEY_ALLISON_STEP_ALL_LIGHT_04 = "foley_allison_step_all_light_04";

			// Token: 0x040028E3 RID: 10467
			public const string FOLEY_ALLISON_STEP_ALL_LIGHT_05 = "foley_allison_step_all_light_05";

			// Token: 0x040028E4 RID: 10468
			public const string FOLEY_ALLISON_STEP_ALL_LIGHT_06 = "foley_allison_step_all_light_06";

			// Token: 0x040028E5 RID: 10469
			public const string FOLEY_ALLISON_STEP_ALL_LIGHT_07 = "foley_allison_step_all_light_07";

			// Token: 0x040028E6 RID: 10470
			public const string FOLEY_ALLISON_STEP_ALL_LIGHT_08 = "foley_allison_step_all_light_08";

			// Token: 0x040028E7 RID: 10471
			public const string FOLEY_ALLISON_STEP_ALL_LIGHT_09 = "foley_allison_step_all_light_09";

			// Token: 0x040028E8 RID: 10472
			public const string FOLEY_ALLISON_STEP_ALL_RUN_01 = "foley_allison_step_all_run_01";

			// Token: 0x040028E9 RID: 10473
			public const string FOLEY_ALLISON_STEP_ALL_RUN_02 = "foley_allison_step_all_run_02";

			// Token: 0x040028EA RID: 10474
			public const string FOLEY_ALLISON_STEP_ALL_RUN_03 = "foley_allison_step_all_run_03";

			// Token: 0x040028EB RID: 10475
			public const string FOLEY_ALLISON_STEP_ALL_RUN_04 = "foley_allison_step_all_run_04";

			// Token: 0x040028EC RID: 10476
			public const string FOLEY_ALLISON_STEP_ALL_RUN_05 = "foley_allison_step_all_run_05";

			// Token: 0x040028ED RID: 10477
			public const string FOLEY_ALLISON_STEP_ALL_RUN_06 = "foley_allison_step_all_run_06";

			// Token: 0x040028EE RID: 10478
			public const string FOLEY_ALLISON_STEP_ALL_RUN_07 = "foley_allison_step_all_run_07";

			// Token: 0x040028EF RID: 10479
			public const string FOLEY_ALLISON_STEP_ALL_RUN_08 = "foley_allison_step_all_run_08";

			// Token: 0x040028F0 RID: 10480
			public const string FOLEY_ALLISON_STEP_ALL_SCUFF_01 = "foley_allison_step_all_scuff_01";

			// Token: 0x040028F1 RID: 10481
			public const string FOLEY_ALLISON_STEP_ALL_SCUFF_02 = "foley_allison_step_all_scuff_02";

			// Token: 0x040028F2 RID: 10482
			public const string FOLEY_ALLISON_STEP_ALL_SCUFF_03 = "foley_allison_step_all_scuff_03";

			// Token: 0x040028F3 RID: 10483
			public const string FOLEY_ALLISON_STEP_ALL_SCUFF_04 = "foley_allison_step_all_scuff_04";

			// Token: 0x040028F4 RID: 10484
			public const string FOLEY_ALLISON_STEP_ALL_SCUFF_05 = "foley_allison_step_all_scuff_05";

			// Token: 0x040028F5 RID: 10485
			public const string FOLEY_ALLISON_STEP_ALL_SCUFF_06 = "foley_allison_step_all_scuff_06";

			// Token: 0x040028F6 RID: 10486
			public const string FOLEY_ALLISON_STEP_ALL_SCUFF_07 = "foley_allison_step_all_scuff_07";

			// Token: 0x040028F7 RID: 10487
			public const string FOLEY_ALLISON_STEP_ALL_WALK_01 = "foley_allison_step_all_walk_01";

			// Token: 0x040028F8 RID: 10488
			public const string FOLEY_ALLISON_STEP_ALL_WALK_02 = "foley_allison_step_all_walk_02";

			// Token: 0x040028F9 RID: 10489
			public const string FOLEY_ALLISON_STEP_ALL_WALK_03 = "foley_allison_step_all_walk_03";

			// Token: 0x040028FA RID: 10490
			public const string FOLEY_ALLISON_STEP_ALL_WALK_04 = "foley_allison_step_all_walk_04";

			// Token: 0x040028FB RID: 10491
			public const string FOLEY_ALLISON_STEP_ALL_WALK_05 = "foley_allison_step_all_walk_05";

			// Token: 0x040028FC RID: 10492
			public const string FOLEY_ALLISON_STEP_ALL_WALK_06 = "foley_allison_step_all_walk_06";

			// Token: 0x040028FD RID: 10493
			public const string FOLEY_ALLISON_STEP_ALL_WALK_07 = "foley_allison_step_all_walk_07";

			// Token: 0x040028FE RID: 10494
			public const string FOLEY_ALLISON_STEP_ALL_WALK_08 = "foley_allison_step_all_walk_08";

			// Token: 0x040028FF RID: 10495
			public const string FOLEY_BANG_HEAD_01 = "foley_bang_head_01";

			// Token: 0x04002900 RID: 10496
			public const string FOLEY_BANG_HEAD_02 = "foley_bang_head_02";

			// Token: 0x04002901 RID: 10497
			public const string FOLEY_BANG_HEAD_03 = "foley_bang_head_03";

			// Token: 0x04002902 RID: 10498
			public const string FOLEY_BANG_HEAD_04 = "foley_bang_head_04";

			// Token: 0x04002903 RID: 10499
			public const string FOLEY_BEAST_STEP_ALL_RUN_01 = "foley_beast_step_all_run_01";

			// Token: 0x04002904 RID: 10500
			public const string FOLEY_BEAST_STEP_ALL_RUN_02 = "foley_beast_step_all_run_02";

			// Token: 0x04002905 RID: 10501
			public const string FOLEY_BEAST_STEP_ALL_RUN_03 = "foley_beast_step_all_run_03";

			// Token: 0x04002906 RID: 10502
			public const string FOLEY_BEAST_STEP_ALL_RUN_04 = "foley_beast_step_all_run_04";

			// Token: 0x04002907 RID: 10503
			public const string FOLEY_BEAST_STEP_ALL_RUN_05 = "foley_beast_step_all_run_05";

			// Token: 0x04002908 RID: 10504
			public const string FOLEY_BEAST_STEP_ALL_RUN_06 = "foley_beast_step_all_run_06";

			// Token: 0x04002909 RID: 10505
			public const string FOLEY_BEAST_STEP_ALL_WALK_01 = "foley_beast_step_all_walk_01";

			// Token: 0x0400290A RID: 10506
			public const string FOLEY_BEAST_STEP_ALL_WALK_02 = "foley_beast_step_all_walk_02";

			// Token: 0x0400290B RID: 10507
			public const string FOLEY_BEAST_STEP_ALL_WALK_03 = "foley_beast_step_all_walk_03";

			// Token: 0x0400290C RID: 10508
			public const string FOLEY_BEAST_STEP_ALL_WALK_04 = "foley_beast_step_all_walk_04";

			// Token: 0x0400290D RID: 10509
			public const string FOLEY_BEAST_STEP_ALL_WALK_05 = "foley_beast_step_all_walk_05";

			// Token: 0x0400290E RID: 10510
			public const string FOLEY_BEAST_STEP_ALL_WALK_06 = "foley_beast_step_all_walk_06";

			// Token: 0x0400290F RID: 10511
			public const string FOLEY_LOSTONE_STEP_ALL_01 = "foley_lostone_step_all_01";

			// Token: 0x04002910 RID: 10512
			public const string FOLEY_LOSTONE_STEP_ALL_02 = "foley_lostone_step_all_02";

			// Token: 0x04002911 RID: 10513
			public const string FOLEY_LOSTONE_STEP_ALL_03 = "foley_lostone_step_all_03";

			// Token: 0x04002912 RID: 10514
			public const string FOLEY_LOSTONE_STEP_ALL_04 = "foley_lostone_step_all_04";

			// Token: 0x04002913 RID: 10515
			public const string FOLEY_LOSTONE_STEP_ALL_05 = "foley_lostone_step_all_05";

			// Token: 0x04002914 RID: 10516
			public const string FOLEY_LOSTONE_STEP_ALL_06 = "foley_lostone_step_all_06";

			// Token: 0x04002915 RID: 10517
			public const string FOLEY_LOSTONE_STEP_ALL_07 = "foley_lostone_step_all_07";

			// Token: 0x04002916 RID: 10518
			public const string FOLEY_LOSTONE_STEP_ALL_08 = "foley_lostone_step_all_08";

			// Token: 0x04002917 RID: 10519
			public const string FOLEY_LOSTONE_STEP_ALL_09 = "foley_lostone_step_all_09";

			// Token: 0x04002918 RID: 10520
			public const string FOLEY_LOSTONE_SWIPE_01 = "foley_lostone_swipe_01";

			// Token: 0x04002919 RID: 10521
			public const string FOLEY_LOSTONE_SWIPE_02 = "foley_lostone_swipe_02";

			// Token: 0x0400291A RID: 10522
			public const string FOLEY_LOSTONE_SWIPE_03 = "foley_lostone_swipe_03";

			// Token: 0x0400291B RID: 10523
			public const string FOLEY_LOSTONE_SWIPE_04 = "foley_lostone_swipe_04";

			// Token: 0x0400291C RID: 10524
			public const string FOLEY_LOSTONE_SWIPE_05 = "foley_lostone_swipe_05";

			// Token: 0x0400291D RID: 10525
			public const string FOLEY_LOSTONE_SWIPE_06 = "foley_lostone_swipe_06";

			// Token: 0x0400291E RID: 10526
			public const string FOLEY_PIPE_MENACE_01 = "foley_pipe_menace_01";

			// Token: 0x0400291F RID: 10527
			public const string FOLEY_PIPE_MENACE_02 = "foley_pipe_menace_02";

			// Token: 0x04002920 RID: 10528
			public const string FOLEY_PIPE_MENACE_03 = "foley_pipe_menace_03";

			// Token: 0x04002921 RID: 10529
			public const string FOLEY_PIPE_MENACE_04 = "foley_pipe_menace_04";

			// Token: 0x04002922 RID: 10530
			public const string FOLEY_PLAYER_JUMP_01 = "foley_player_jump_01";

			// Token: 0x04002923 RID: 10531
			public const string FOLEY_PLAYER_JUMP_02 = "foley_player_jump_02";

			// Token: 0x04002924 RID: 10532
			public const string FOLEY_PLAYER_JUMP_03 = "foley_player_jump_03";

			// Token: 0x04002925 RID: 10533
			public const string FOLEY_PLAYER_JUMP_04 = "foley_player_jump_04";

			// Token: 0x04002926 RID: 10534
			public const string FOLEY_PLAYER_JUMP_05 = "foley_player_jump_05";

			// Token: 0x04002927 RID: 10535
			public const string FOLEY_PLAYER_JUMP_06 = "foley_player_jump_06";

			// Token: 0x04002928 RID: 10536
			public const string FOLEY_PLAYER_LAND_DIRT_01 = "foley_player_land_dirt_01";

			// Token: 0x04002929 RID: 10537
			public const string FOLEY_PLAYER_LAND_DIRT_02 = "foley_player_land_dirt_02";

			// Token: 0x0400292A RID: 10538
			public const string FOLEY_PLAYER_LAND_DIRT_03 = "foley_player_land_dirt_03";

			// Token: 0x0400292B RID: 10539
			public const string FOLEY_PLAYER_LAND_DIRT_04 = "foley_player_land_dirt_04";

			// Token: 0x0400292C RID: 10540
			public const string FOLEY_PLAYER_LAND_DIRT_05 = "foley_player_land_dirt_05";

			// Token: 0x0400292D RID: 10541
			public const string FOLEY_PLAYER_LAND_DIRT_06 = "foley_player_land_dirt_06";

			// Token: 0x0400292E RID: 10542
			public const string FOLEY_PLAYER_LAND_INK_01 = "foley_player_land_ink_01";

			// Token: 0x0400292F RID: 10543
			public const string FOLEY_PLAYER_LAND_INK_02 = "foley_player_land_ink_02";

			// Token: 0x04002930 RID: 10544
			public const string FOLEY_PLAYER_LAND_INK_03 = "foley_player_land_ink_03";

			// Token: 0x04002931 RID: 10545
			public const string FOLEY_PLAYER_LAND_INK_04 = "foley_player_land_ink_04";

			// Token: 0x04002932 RID: 10546
			public const string FOLEY_PLAYER_LAND_INK_05 = "foley_player_land_ink_05";

			// Token: 0x04002933 RID: 10547
			public const string FOLEY_PLAYER_LAND_INK_06 = "foley_player_land_ink_06";

			// Token: 0x04002934 RID: 10548
			public const string FOLEY_PLAYER_LAND_METAL_01 = "foley_player_land_metal_01";

			// Token: 0x04002935 RID: 10549
			public const string FOLEY_PLAYER_LAND_METAL_02 = "foley_player_land_metal_02";

			// Token: 0x04002936 RID: 10550
			public const string FOLEY_PLAYER_LAND_METAL_03 = "foley_player_land_metal_03";

			// Token: 0x04002937 RID: 10551
			public const string FOLEY_PLAYER_LAND_METAL_04 = "foley_player_land_metal_04";

			// Token: 0x04002938 RID: 10552
			public const string FOLEY_PLAYER_LAND_METAL_05 = "foley_player_land_metal_05";

			// Token: 0x04002939 RID: 10553
			public const string FOLEY_PLAYER_LAND_TILE_01 = "foley_player_land_tile_01";

			// Token: 0x0400293A RID: 10554
			public const string FOLEY_PLAYER_LAND_TILE_02 = "foley_player_land_tile_02";

			// Token: 0x0400293B RID: 10555
			public const string FOLEY_PLAYER_LAND_TILE_03 = "foley_player_land_tile_03";

			// Token: 0x0400293C RID: 10556
			public const string FOLEY_PLAYER_LAND_TILE_04 = "foley_player_land_tile_04";

			// Token: 0x0400293D RID: 10557
			public const string FOLEY_PLAYER_LAND_TILE_05 = "foley_player_land_tile_05";

			// Token: 0x0400293E RID: 10558
			public const string FOLEY_PLAYER_LAND_TILE_06 = "foley_player_land_tile_06";

			// Token: 0x0400293F RID: 10559
			public const string FOLEY_PLAYER_LAND_WOOD_01 = "foley_player_land_wood_01";

			// Token: 0x04002940 RID: 10560
			public const string FOLEY_PLAYER_LAND_WOOD_02 = "foley_player_land_wood_02";

			// Token: 0x04002941 RID: 10561
			public const string FOLEY_PLAYER_LAND_WOOD_03 = "foley_player_land_wood_03";

			// Token: 0x04002942 RID: 10562
			public const string FOLEY_PLAYER_LAND_WOOD_04 = "foley_player_land_wood_04";

			// Token: 0x04002943 RID: 10563
			public const string FOLEY_PLAYER_PICKUP_COMMON_01 = "foley_player_pickup_common_01";

			// Token: 0x04002944 RID: 10564
			public const string FOLEY_PLAYER_PICKUP_COMMON_02 = "foley_player_pickup_common_02";

			// Token: 0x04002945 RID: 10565
			public const string FOLEY_PLAYER_PICKUP_COMMON_03 = "foley_player_pickup_common_03";

			// Token: 0x04002946 RID: 10566
			public const string FOLEY_PLAYER_PICKUP_COMMON_04 = "foley_player_pickup_common_04";

			// Token: 0x04002947 RID: 10567
			public const string FOLEY_PLAYER_PICKUP_COMMON_05 = "foley_player_pickup_common_05";

			// Token: 0x04002948 RID: 10568
			public const string FOLEY_PLAYER_STEP_DIRT_01 = "foley_player_step_dirt_01";

			// Token: 0x04002949 RID: 10569
			public const string FOLEY_PLAYER_STEP_DIRT_02 = "foley_player_step_dirt_02";

			// Token: 0x0400294A RID: 10570
			public const string FOLEY_PLAYER_STEP_DIRT_03 = "foley_player_step_dirt_03";

			// Token: 0x0400294B RID: 10571
			public const string FOLEY_PLAYER_STEP_DIRT_04 = "foley_player_step_dirt_04";

			// Token: 0x0400294C RID: 10572
			public const string FOLEY_PLAYER_STEP_DIRT_05 = "foley_player_step_dirt_05";

			// Token: 0x0400294D RID: 10573
			public const string FOLEY_PLAYER_STEP_DIRT_06 = "foley_player_step_dirt_06";

			// Token: 0x0400294E RID: 10574
			public const string FOLEY_PLAYER_STEP_DIRT_07 = "foley_player_step_dirt_07";

			// Token: 0x0400294F RID: 10575
			public const string FOLEY_PLAYER_STEP_DIRT_08 = "foley_player_step_dirt_08";

			// Token: 0x04002950 RID: 10576
			public const string FOLEY_PLAYER_STEP_DIRT_09 = "foley_player_step_dirt_09";

			// Token: 0x04002951 RID: 10577
			public const string FOLEY_PLAYER_STEP_DIRT_10 = "foley_player_step_dirt_10";

			// Token: 0x04002952 RID: 10578
			public const string FOLEY_PLAYER_STEP_INK_01 = "foley_player_step_ink_01";

			// Token: 0x04002953 RID: 10579
			public const string FOLEY_PLAYER_STEP_INK_02 = "foley_player_step_ink_02";

			// Token: 0x04002954 RID: 10580
			public const string FOLEY_PLAYER_STEP_INK_03 = "foley_player_step_ink_03";

			// Token: 0x04002955 RID: 10581
			public const string FOLEY_PLAYER_STEP_INK_04 = "foley_player_step_ink_04";

			// Token: 0x04002956 RID: 10582
			public const string FOLEY_PLAYER_STEP_INK_05 = "foley_player_step_ink_05";

			// Token: 0x04002957 RID: 10583
			public const string FOLEY_PLAYER_STEP_INK_06 = "foley_player_step_ink_06";

			// Token: 0x04002958 RID: 10584
			public const string FOLEY_PLAYER_STEP_METAL_01 = "foley_player_step_metal_01";

			// Token: 0x04002959 RID: 10585
			public const string FOLEY_PLAYER_STEP_METAL_02 = "foley_player_step_metal_02";

			// Token: 0x0400295A RID: 10586
			public const string FOLEY_PLAYER_STEP_METAL_03 = "foley_player_step_metal_03";

			// Token: 0x0400295B RID: 10587
			public const string FOLEY_PLAYER_STEP_METAL_04 = "foley_player_step_metal_04";

			// Token: 0x0400295C RID: 10588
			public const string FOLEY_PLAYER_STEP_METAL_05 = "foley_player_step_metal_05";

			// Token: 0x0400295D RID: 10589
			public const string FOLEY_PLAYER_STEP_METAL_06 = "foley_player_step_metal_06";

			// Token: 0x0400295E RID: 10590
			public const string FOLEY_PLAYER_STEP_METAL_07 = "foley_player_step_metal_07";

			// Token: 0x0400295F RID: 10591
			public const string FOLEY_PLAYER_STEP_METAL_08 = "foley_player_step_metal_08";

			// Token: 0x04002960 RID: 10592
			public const string FOLEY_PLAYER_STEP_METAL_09 = "foley_player_step_metal_09";

			// Token: 0x04002961 RID: 10593
			public const string FOLEY_PLAYER_STEP_METAL_10 = "foley_player_step_metal_10";

			// Token: 0x04002962 RID: 10594
			public const string FOLEY_PLAYER_STEP_TILE_01 = "foley_player_step_tile_01";

			// Token: 0x04002963 RID: 10595
			public const string FOLEY_PLAYER_STEP_TILE_02 = "foley_player_step_tile_02";

			// Token: 0x04002964 RID: 10596
			public const string FOLEY_PLAYER_STEP_TILE_03 = "foley_player_step_tile_03";

			// Token: 0x04002965 RID: 10597
			public const string FOLEY_PLAYER_STEP_TILE_04 = "foley_player_step_tile_04";

			// Token: 0x04002966 RID: 10598
			public const string FOLEY_PLAYER_STEP_TILE_05 = "foley_player_step_tile_05";

			// Token: 0x04002967 RID: 10599
			public const string FOLEY_PLAYER_STEP_TILE_06 = "foley_player_step_tile_06";

			// Token: 0x04002968 RID: 10600
			public const string FOLEY_PLAYER_STEP_TILE_07 = "foley_player_step_tile_07";

			// Token: 0x04002969 RID: 10601
			public const string FOLEY_PLAYER_STEP_TILE_08 = "foley_player_step_tile_08";

			// Token: 0x0400296A RID: 10602
			public const string FOLEY_PLAYER_STEP_TILE_09 = "foley_player_step_tile_09";

			// Token: 0x0400296B RID: 10603
			public const string FOLEY_PLAYER_STEP_TILE_10 = "foley_player_step_tile_10";

			// Token: 0x0400296C RID: 10604
			public const string FOLEY_PLAYER_STEP_WOOD_01 = "foley_player_step_wood_01";

			// Token: 0x0400296D RID: 10605
			public const string FOLEY_PLAYER_STEP_WOOD_02 = "foley_player_step_wood_02";

			// Token: 0x0400296E RID: 10606
			public const string FOLEY_PLAYER_STEP_WOOD_03 = "foley_player_step_wood_03";

			// Token: 0x0400296F RID: 10607
			public const string FOLEY_PLAYER_STEP_WOOD_04 = "foley_player_step_wood_04";

			// Token: 0x04002970 RID: 10608
			public const string FOLEY_PLAYER_STEP_WOOD_05 = "foley_player_step_wood_05";

			// Token: 0x04002971 RID: 10609
			public const string FOLEY_PLAYER_STEP_WOOD_06 = "foley_player_step_wood_06";

			// Token: 0x04002972 RID: 10610
			public const string FOLEY_PLAYER_STEP_WOOD_07 = "foley_player_step_wood_07";

			// Token: 0x04002973 RID: 10611
			public const string FOLEY_PLAYER_STEP_WOOD_08 = "foley_player_step_wood_08";

			// Token: 0x04002974 RID: 10612
			public const string FOLEY_PLAYER_STEP_WOOD_09 = "foley_player_step_wood_09";

			// Token: 0x04002975 RID: 10613
			public const string FOLEY_PLAYER_STEP_WOOD_10 = "foley_player_step_wood_10";

			// Token: 0x04002976 RID: 10614
			public const string FOLEY_TOM_MOVES_LOOP = "foley_tom_moves_loop";

			// Token: 0x04002977 RID: 10615
			public const string FOLEY_TOM_STEP_ALL_LIGHT_01 = "foley_tom_step_all_light_01";

			// Token: 0x04002978 RID: 10616
			public const string FOLEY_TOM_STEP_ALL_LIGHT_02 = "foley_tom_step_all_light_02";

			// Token: 0x04002979 RID: 10617
			public const string FOLEY_TOM_STEP_ALL_LIGHT_03 = "foley_tom_step_all_light_03";

			// Token: 0x0400297A RID: 10618
			public const string FOLEY_TOM_STEP_ALL_LIGHT_04 = "foley_tom_step_all_light_04";

			// Token: 0x0400297B RID: 10619
			public const string FOLEY_TOM_STEP_ALL_LIGHT_05 = "foley_tom_step_all_light_05";

			// Token: 0x0400297C RID: 10620
			public const string FOLEY_TOM_STEP_ALL_LIGHT_06 = "foley_tom_step_all_light_06";

			// Token: 0x0400297D RID: 10621
			public const string FOLEY_TOM_STEP_ALL_LIGHT_07 = "foley_tom_step_all_light_07";

			// Token: 0x0400297E RID: 10622
			public const string FOLEY_TOM_STEP_ALL_LIGHT_08 = "foley_tom_step_all_light_08";

			// Token: 0x0400297F RID: 10623
			public const string FOLEY_TOM_STEP_ALL_LIGHT_09 = "foley_tom_step_all_light_09";

			// Token: 0x04002980 RID: 10624
			public const string FOLEY_TOM_STEP_ALL_RUN_01 = "foley_tom_step_all_run_01";

			// Token: 0x04002981 RID: 10625
			public const string FOLEY_TOM_STEP_ALL_RUN_02 = "foley_tom_step_all_run_02";

			// Token: 0x04002982 RID: 10626
			public const string FOLEY_TOM_STEP_ALL_RUN_03 = "foley_tom_step_all_run_03";

			// Token: 0x04002983 RID: 10627
			public const string FOLEY_TOM_STEP_ALL_RUN_04 = "foley_tom_step_all_run_04";

			// Token: 0x04002984 RID: 10628
			public const string FOLEY_TOM_STEP_ALL_RUN_05 = "foley_tom_step_all_run_05";

			// Token: 0x04002985 RID: 10629
			public const string FOLEY_TOM_STEP_ALL_RUN_06 = "foley_tom_step_all_run_06";

			// Token: 0x04002986 RID: 10630
			public const string FOLEY_TOM_STEP_ALL_RUN_07 = "foley_tom_step_all_run_07";

			// Token: 0x04002987 RID: 10631
			public const string FOLEY_TOM_STEP_ALL_RUN_08 = "foley_tom_step_all_run_08";

			// Token: 0x04002988 RID: 10632
			public const string FOLEY_TOM_STEP_ALL_RUN_09 = "foley_tom_step_all_run_09";

			// Token: 0x04002989 RID: 10633
			public const string FOLEY_TOM_STEP_ALL_RUN_10 = "foley_tom_step_all_run_10";

			// Token: 0x0400298A RID: 10634
			public const string FOLEY_TOM_STEP_ALL_RUN_11 = "foley_tom_step_all_run_11";

			// Token: 0x0400298B RID: 10635
			public const string FOLEY_TOM_STEP_ALL_RUN_12 = "foley_tom_step_all_run_12";

			// Token: 0x0400298C RID: 10636
			public const string FOLEY_TOM_STEP_ALL_SCUFF_01 = "foley_tom_step_all_scuff_01";

			// Token: 0x0400298D RID: 10637
			public const string FOLEY_TOM_STEP_ALL_SCUFF_02 = "foley_tom_step_all_scuff_02";

			// Token: 0x0400298E RID: 10638
			public const string FOLEY_TOM_STEP_ALL_SCUFF_03 = "foley_tom_step_all_scuff_03";

			// Token: 0x0400298F RID: 10639
			public const string FOLEY_TOM_STEP_ALL_SCUFF_04 = "foley_tom_step_all_scuff_04";

			// Token: 0x04002990 RID: 10640
			public const string FOLEY_TOM_STEP_ALL_SCUFF_05 = "foley_tom_step_all_scuff_05";

			// Token: 0x04002991 RID: 10641
			public const string FOLEY_TOM_STEP_ALL_SCUFF_06 = "foley_tom_step_all_scuff_06";

			// Token: 0x04002992 RID: 10642
			public const string FOLEY_TOM_STEP_ALL_WALK_01 = "foley_tom_step_all_walk_01";

			// Token: 0x04002993 RID: 10643
			public const string FOLEY_TOM_STEP_ALL_WALK_02 = "foley_tom_step_all_walk_02";

			// Token: 0x04002994 RID: 10644
			public const string FOLEY_TOM_STEP_ALL_WALK_03 = "foley_tom_step_all_walk_03";

			// Token: 0x04002995 RID: 10645
			public const string FOLEY_TOM_STEP_ALL_WALK_04 = "foley_tom_step_all_walk_04";

			// Token: 0x04002996 RID: 10646
			public const string FOLEY_TOM_STEP_ALL_WALK_05 = "foley_tom_step_all_walk_05";

			// Token: 0x04002997 RID: 10647
			public const string FOLEY_TOM_STEP_ALL_WALK_06 = "foley_tom_step_all_walk_06";

			// Token: 0x04002998 RID: 10648
			public const string FOLEY_TOM_STEP_ALL_WALK_07 = "foley_tom_step_all_walk_07";

			// Token: 0x04002999 RID: 10649
			public const string FOLEY_TOM_STEP_ALL_WALK_08 = "foley_tom_step_all_walk_08";

			// Token: 0x0400299A RID: 10650
			public const string FOLEY_TOM_STEP_ALL_WALK_09 = "foley_tom_step_all_walk_09";

			// Token: 0x0400299B RID: 10651
			public const string FOLEY_TOM_STEP_ALL_WALK_10 = "foley_tom_step_all_walk_10";

			// Token: 0x0400299C RID: 10652
			public const string FOLEY_VENT_MOVE_01 = "foley_vent_move_01";

			// Token: 0x0400299D RID: 10653
			public const string FOLEY_VENT_MOVE_02 = "foley_vent_move_02";

			// Token: 0x0400299E RID: 10654
			public const string FOLEY_VENT_MOVE_03 = "foley_vent_move_03";

			// Token: 0x0400299F RID: 10655
			public const string FOLEY_VENT_MOVE_04 = "foley_vent_move_04";

			// Token: 0x040029A0 RID: 10656
			public const string FOLEY_VENT_MOVE_05 = "foley_vent_move_05";

			// Token: 0x040029A1 RID: 10657
			public const string FOLEY_VENT_MOVE_06 = "foley_vent_move_06";

			// Token: 0x040029A2 RID: 10658
			public const string FOLEY_VENT_MOVE_07 = "foley_vent_move_07";

			// Token: 0x040029A3 RID: 10659
			public const string FOLEY_VENT_MOVE_08 = "foley_vent_move_08";

			// Token: 0x040029A4 RID: 10660
			public const string FOLEY_VENT_MOVE_09 = "foley_vent_move_09";

			// Token: 0x040029A5 RID: 10661
			public const string FOLEY_VENT_MOVE_10 = "foley_vent_move_10";

			// Token: 0x040029A6 RID: 10662
			public const string FOLEY_VENT_MOVE_11 = "foley_vent_move_11";

			// Token: 0x040029A7 RID: 10663
			public const string FOLEY_VENT_MOVE_12 = "foley_vent_move_12";

			// Token: 0x040029A8 RID: 10664
			public const string FOLEY_VENT_MOVE_13 = "foley_vent_move_13";

			// Token: 0x040029A9 RID: 10665
			public const string FOLEY_WATER_MOVE_01 = "foley_water_move_01";

			// Token: 0x040029AA RID: 10666
			public const string FOLEY_WATER_MOVE_02 = "foley_water_move_02";

			// Token: 0x040029AB RID: 10667
			public const string FOLEY_WATER_MOVE_03 = "foley_water_move_03";

			// Token: 0x040029AC RID: 10668
			public const string FOLEY_WATER_MOVE_04 = "foley_water_move_04";

			// Token: 0x040029AD RID: 10669
			public const string FOLEY_WATER_MOVE_05 = "foley_water_move_05";

			// Token: 0x040029AE RID: 10670
			public const string FOLEY_WATER_MOVE_06 = "foley_water_move_06";

			// Token: 0x040029AF RID: 10671
			public const string FOLEY_WEAPON_BLADE_SWIPE_01 = "foley_weapon_blade_swipe_01";

			// Token: 0x040029B0 RID: 10672
			public const string FOLEY_WEAPON_BLADE_SWIPE_02 = "foley_weapon_blade_swipe_02";

			// Token: 0x040029B1 RID: 10673
			public const string FOLEY_WEAPON_BLADE_SWIPE_03 = "foley_weapon_blade_swipe_03";

			// Token: 0x040029B2 RID: 10674
			public const string FOLEY_WEAPON_BLADE_SWIPE_04 = "foley_weapon_blade_swipe_04";

			// Token: 0x040029B3 RID: 10675
			public const string FOLEY_WEAPON_PIPE_SWIPE_01 = "foley_weapon_pipe_swipe_01";

			// Token: 0x040029B4 RID: 10676
			public const string FOLEY_WEAPON_PIPE_SWIPE_02 = "foley_weapon_pipe_swipe_02";

			// Token: 0x040029B5 RID: 10677
			public const string FOLEY_WEAPON_PIPE_SWIPE_03 = "foley_weapon_pipe_swipe_03";

			// Token: 0x040029B6 RID: 10678
			public const string FOLEY_WEAPON_PIPE_SWIPE_04 = "foley_weapon_pipe_swipe_04";

			// Token: 0x040029B7 RID: 10679
			public const string FOLEY_WET_TINY_SPLAT_DRIP_01 = "foley_wet_tiny_splat_drip_01";

			// Token: 0x040029B8 RID: 10680
			public const string FOLEY_WET_TINY_SPLAT_DRIP_02 = "foley_wet_tiny_splat_drip_02";

			// Token: 0x040029B9 RID: 10681
			public const string FOLEY_WET_TINY_SPLAT_DRIP_03 = "foley_wet_tiny_splat_drip_03";

			// Token: 0x040029BA RID: 10682
			public const string FOLEY_WET_TINY_SPLAT_DRIP_04 = "foley_wet_tiny_splat_drip_04";

			// Token: 0x040029BB RID: 10683
			public const string FOLEY_WET_TINY_SPLAT_DRIP_05 = "foley_wet_tiny_splat_drip_05";

			// Token: 0x040029BC RID: 10684
			public const string FOLEY_WET_TINY_SPLAT_DRIP_06 = "foley_wet_tiny_splat_drip_06";

			// Token: 0x040029BD RID: 10685
			public const string LOSTONE_CRYING_01 = "lostone_crying_01";

			// Token: 0x040029BE RID: 10686
			public const string LOSTONE_CRYING_02 = "lostone_crying_02";

			// Token: 0x040029BF RID: 10687
			public const string LOSTONE_CRYING_03 = "lostone_crying_03";

			// Token: 0x040029C0 RID: 10688
			public const string LOSTONE_CRYING_04 = "lostone_crying_04";

			// Token: 0x040029C1 RID: 10689
			public const string LOSTONE_CRYING_05 = "lostone_crying_05";

			// Token: 0x040029C2 RID: 10690
			public const string LOSTONE_CRYING_06 = "lostone_crying_06";

			// Token: 0x040029C3 RID: 10691
			public const string LOSTONE_CRYING_07 = "lostone_crying_07";

			// Token: 0x040029C4 RID: 10692
			public const string LOSTONE_CRYING_08 = "lostone_crying_08";

			// Token: 0x040029C5 RID: 10693
			public const string LOSTONE_CRYING_09 = "lostone_crying_09";

			// Token: 0x040029C6 RID: 10694
			public const string LOSTONE_CRYING_10 = "lostone_crying_10";

			// Token: 0x040029C7 RID: 10695
			public const string LOSTONE_CRYING_11 = "lostone_crying_11";

			// Token: 0x040029C8 RID: 10696
			public const string LOSTONE_CRYING_12 = "lostone_crying_12";

			// Token: 0x040029C9 RID: 10697
			public const string LOSTONE_CRYING_13 = "lostone_crying_13";

			// Token: 0x040029CA RID: 10698
			public const string M_SAMMY_REVEALED = "m_sammy_revealed";

			// Token: 0x040029CB RID: 10699
			public const string SFX_ALICE_BOAT_DESTROYED = "sfx_alice_boat_destroyed";

			// Token: 0x040029CC RID: 10700
			public const string SFX_AXE_HITS_PANEL_1 = "sfx_axe_hits_panel_1";

			// Token: 0x040029CD RID: 10701
			public const string SFX_AXE_HITS_PANEL_2 = "sfx_axe_hits_panel_2";

			// Token: 0x040029CE RID: 10702
			public const string SFX_AXE_HITS_PANEL_3 = "sfx_axe_hits_panel_3";

			// Token: 0x040029CF RID: 10703
			public const string SFX_AXE_HITS_PANEL_4 = "sfx_axe_hits_panel_4";

			// Token: 0x040029D0 RID: 10704
			public const string SFX_AXE_MENACE = "sfx_axe_menace";

			// Token: 0x040029D1 RID: 10705
			public const string SFX_AXE_SWING_01 = "sfx_axe_swing_01";

			// Token: 0x040029D2 RID: 10706
			public const string SFX_AXE_SWING_02 = "sfx_axe_swing_02";

			// Token: 0x040029D3 RID: 10707
			public const string SFX_AXE_SWING_03 = "sfx_axe_swing_03";

			// Token: 0x040029D4 RID: 10708
			public const string SFX_AXE_SWING_04 = "sfx_axe_swing_04";

			// Token: 0x040029D5 RID: 10709
			public const string SFX_AXE_SWING_05 = "sfx_axe_swing_05";

			// Token: 0x040029D6 RID: 10710
			public const string SFX_AXE_SWING_06 = "sfx_axe_swing_06";

			// Token: 0x040029D7 RID: 10711
			public const string SFX_AXE_SWING_07 = "sfx_axe_swing_07";

			// Token: 0x040029D8 RID: 10712
			public const string SFX_AXE_SWING_08 = "sfx_axe_swing_08";

			// Token: 0x040029D9 RID: 10713
			public const string SFX_BALL_BOUNCE = "sfx_ball_bounce";

			// Token: 0x040029DA RID: 10714
			public const string SFX_BALL_DROP = "sfx_ball_drop";

			// Token: 0x040029DB RID: 10715
			public const string SFX_BALL_HIT = "sfx_ball_hit";

			// Token: 0x040029DC RID: 10716
			public const string SFX_BALL_PICKUP = "sfx_ball_pickup";

			// Token: 0x040029DD RID: 10717
			public const string SFX_BARREL_INK_SPLASH_01 = "sfx_barrel_ink_splash_01";

			// Token: 0x040029DE RID: 10718
			public const string SFX_BARREL_INK_SPLASH_02 = "sfx_barrel_ink_splash_02";

			// Token: 0x040029DF RID: 10719
			public const string SFX_BARREL_INK_SPLASH_03 = "sfx_barrel_ink_splash_03";

			// Token: 0x040029E0 RID: 10720
			public const string SFX_BARREL_INK_SPLASH_04 = "sfx_barrel_ink_splash_04";

			// Token: 0x040029E1 RID: 10721
			public const string SFX_BATTERY_ADDED = "sfx_battery_added";

			// Token: 0x040029E2 RID: 10722
			public const string SFX_BEAST_BENDY_ATTACK_01 = "sfx_beast_bendy_attack_01";

			// Token: 0x040029E3 RID: 10723
			public const string SFX_BEAST_BENDY_ATTACK_02 = "sfx_beast_bendy_attack_02";

			// Token: 0x040029E4 RID: 10724
			public const string SFX_BEAST_BENDY_ATTACK_03 = "sfx_beast_bendy_attack_03";

			// Token: 0x040029E5 RID: 10725
			public const string SFX_BEAST_BENDY_ATTACK_04 = "sfx_beast_bendy_attack_04";

			// Token: 0x040029E6 RID: 10726
			public const string SFX_BEAST_BENDY_ATTACK_05 = "sfx_beast_bendy_attack_05";

			// Token: 0x040029E7 RID: 10727
			public const string SFX_BEAST_BENDY_ATTACK_06 = "sfx_beast_bendy_attack_06";

			// Token: 0x040029E8 RID: 10728
			public const string SFX_BEAST_BENDY_DEATH = "sfx_beast_bendy_death";

			// Token: 0x040029E9 RID: 10729
			public const string SFX_BEAST_BENDY_REVEAL = "sfx_beast_bendy_reveal";

			// Token: 0x040029EA RID: 10730
			public const string SFX_BENDY_CH5_SCENE07 = "sfx_bendy_CH5_scene07";

			// Token: 0x040029EB RID: 10731
			public const string SFX_BERT_ARM_DEBRIS_01 = "sfx_bert_arm_debris_01";

			// Token: 0x040029EC RID: 10732
			public const string SFX_BERT_ARM_DEBRIS_02 = "sfx_bert_arm_debris_02";

			// Token: 0x040029ED RID: 10733
			public const string SFX_BERT_ARM_DEBRIS_03 = "sfx_bert_arm_debris_03";

			// Token: 0x040029EE RID: 10734
			public const string SFX_BERT_ARM_DEBRIS_04 = "sfx_bert_arm_debris_04";

			// Token: 0x040029EF RID: 10735
			public const string SFX_BERT_ARM_DEBRIS_05 = "sfx_bert_arm_debris_05";

			// Token: 0x040029F0 RID: 10736
			public const string SFX_BERT_ARM_DEBRIS_06 = "sfx_bert_arm_debris_06";

			// Token: 0x040029F1 RID: 10737
			public const string SFX_BERT_ARM_DESTROYED_01 = "sfx_bert_arm_destroyed_01";

			// Token: 0x040029F2 RID: 10738
			public const string SFX_BERT_ARM_DESTROYED_02 = "sfx_bert_arm_destroyed_02";

			// Token: 0x040029F3 RID: 10739
			public const string SFX_BERT_ARM_DESTROYED_03 = "sfx_bert_arm_destroyed_03";

			// Token: 0x040029F4 RID: 10740
			public const string SFX_BERT_ARM_DESTROYED_04 = "sfx_bert_arm_destroyed_04";

			// Token: 0x040029F5 RID: 10741
			public const string SFX_BERT_ARM_DESTROYED_05 = "sfx_bert_arm_destroyed_05";

			// Token: 0x040029F6 RID: 10742
			public const string SFX_BERT_ARM_SLAM_01 = "sfx_bert_arm_slam_01";

			// Token: 0x040029F7 RID: 10743
			public const string SFX_BERT_ARM_SLAM_02 = "sfx_bert_arm_slam_02";

			// Token: 0x040029F8 RID: 10744
			public const string SFX_BERT_ARM_SLAM_03 = "sfx_bert_arm_slam_03";

			// Token: 0x040029F9 RID: 10745
			public const string SFX_BERT_ARM_SLAM_04 = "sfx_bert_arm_slam_04";

			// Token: 0x040029FA RID: 10746
			public const string SFX_BERT_ARM_SLAM_05 = "sfx_bert_arm_slam_05";

			// Token: 0x040029FB RID: 10747
			public const string SFX_BERT_ARM_SLAM_06 = "sfx_bert_arm_slam_06";

			// Token: 0x040029FC RID: 10748
			public const string SFX_BERT_ARM_SPIN_01 = "sfx_bert_arm_spin_01";

			// Token: 0x040029FD RID: 10749
			public const string SFX_BERT_ARM_SPIN_02 = "sfx_bert_arm_spin_02";

			// Token: 0x040029FE RID: 10750
			public const string SFX_BERT_ARM_SPIN_03 = "sfx_bert_arm_spin_03";

			// Token: 0x040029FF RID: 10751
			public const string SFX_BERT_ARM_SPIN_04 = "sfx_bert_arm_spin_04";

			// Token: 0x04002A00 RID: 10752
			public const string SFX_BERT_ARM_SPIN_05 = "sfx_bert_arm_spin_05";

			// Token: 0x04002A01 RID: 10753
			public const string SFX_BERT_ARM_SPIN_06 = "sfx_bert_arm_spin_06";

			// Token: 0x04002A02 RID: 10754
			public const string SFX_BERT_BOSS_FINALE = "sfx_bert_boss_finale";

			// Token: 0x04002A03 RID: 10755
			public const string SFX_BERT_BOSS_STARTUP = "sfx_bert_boss_startup";

			// Token: 0x04002A04 RID: 10756
			public const string SFX_BERT_HUB_IDLE_LOOP = "sfx_bert_hub_idle_loop";

			// Token: 0x04002A05 RID: 10757
			public const string SFX_BERT_HUB_SPIN_LOOP = "sfx_bert_hub_spin_loop";

			// Token: 0x04002A06 RID: 10758
			public const string SFX_BERT_HURT_01 = "sfx_bert_hurt_01";

			// Token: 0x04002A07 RID: 10759
			public const string SFX_BERT_HURT_02 = "sfx_bert_hurt_02";

			// Token: 0x04002A08 RID: 10760
			public const string SFX_BERT_HURT_03 = "sfx_bert_hurt_03";

			// Token: 0x04002A09 RID: 10761
			public const string SFX_BERT_HURT_04 = "sfx_bert_hurt_04";

			// Token: 0x04002A0A RID: 10762
			public const string SFX_BERT_STEAM_BURSTS_01 = "sfx_bert_steam_bursts_01";

			// Token: 0x04002A0B RID: 10763
			public const string SFX_BERT_STEAM_BURSTS_02 = "sfx_bert_steam_bursts_02";

			// Token: 0x04002A0C RID: 10764
			public const string SFX_BERT_STEAM_BURSTS_03 = "sfx_bert_steam_bursts_03";

			// Token: 0x04002A0D RID: 10765
			public const string SFX_BERT_STEAM_BURSTS_04 = "sfx_bert_steam_bursts_04";

			// Token: 0x04002A0E RID: 10766
			public const string SFX_BERT_STEAM_BURSTS_05 = "sfx_bert_steam_bursts_05";

			// Token: 0x04002A0F RID: 10767
			public const string SFX_BERT_STEAM_BURSTS_06 = "sfx_bert_steam_bursts_06";

			// Token: 0x04002A10 RID: 10768
			public const string SFX_BOAT_ALLISON_TOM_AWAY = "sfx_boat_allison_tom_away";

			// Token: 0x04002A11 RID: 10769
			public const string SFX_BOAT_CONTROL_BACK = "sfx_boat_control_back";

			// Token: 0x04002A12 RID: 10770
			public const string SFX_BOAT_CONTROL_FORWARD = "sfx_boat_control_forward";

			// Token: 0x04002A13 RID: 10771
			public const string SFX_BOAT_CONTROL_START = "sfx_boat_control_start";

			// Token: 0x04002A14 RID: 10772
			public const string SFX_BOAT_CONTROL_STEER = "sfx_boat_control_steer";

			// Token: 0x04002A15 RID: 10773
			public const string SFX_BOAT_CONTROL_STOP = "sfx_boat_control_stop";

			// Token: 0x04002A16 RID: 10774
			public const string SFX_BOAT_DESTROYED = "sfx_boat_destroyed";

			// Token: 0x04002A17 RID: 10775
			public const string SFX_BOAT_ENGINE_IDLE_LOOP_TEMP = "sfx_boat_engine_idle_loop_TEMP";

			// Token: 0x04002A18 RID: 10776
			public const string SFX_BOAT_ENGINE_START_TEMP = "sfx_boat_engine_start_TEMP";

			// Token: 0x04002A19 RID: 10777
			public const string SFX_BOAT_ENGINE_STOP_TEMP = "sfx_boat_engine_stop_TEMP";

			// Token: 0x04002A1A RID: 10778
			public const string SFX_BOAT_ENGINE_THROTTLE_OFF_ONESHOT_TEMP = "sfx_boat_engine_throttle_off_oneshot_TEMP";

			// Token: 0x04002A1B RID: 10779
			public const string SFX_BOAT_ENGINE_THROTTLE_ON_LOOP_TEMP = "sfx_boat_engine_throttle_on_loop_TEMP";

			// Token: 0x04002A1C RID: 10780
			public const string SFX_BOAT_ENGINE_THROTTLE_ON_ONESHOT_TEMP = "sfx_boat_engine_throttle_on_oneshot_TEMP";

			// Token: 0x04002A1D RID: 10781
			public const string SFX_BOAT_ENTER = "sfx_boat_enter";

			// Token: 0x04002A1E RID: 10782
			public const string SFX_BOAT_IDLE_LOOP = "sfx_boat_idle_loop";

			// Token: 0x04002A1F RID: 10783
			public const string SFX_BOAT_SLIDE1 = "sfx_boat_slide1";

			// Token: 0x04002A20 RID: 10784
			public const string SFX_BOAT_SLIDE2 = "sfx_boat_slide2";

			// Token: 0x04002A21 RID: 10785
			public const string SFX_BOAT_THROTTLE_OFF_ONESHOT = "sfx_boat_throttle_off_oneshot";

			// Token: 0x04002A22 RID: 10786
			public const string SFX_BOAT_THROTTLE_ON_LOOP = "sfx_boat_throttle_on_loop";

			// Token: 0x04002A23 RID: 10787
			public const string SFX_BOAT_THROTTLE_ON_ONESHOT = "sfx_boat_throttle_on_oneshot";

			// Token: 0x04002A24 RID: 10788
			public const string SFX_BOOK_FALLS_01 = "sfx_book_falls_01";

			// Token: 0x04002A25 RID: 10789
			public const string SFX_BOOK_FALLS_02 = "sfx_book_falls_02";

			// Token: 0x04002A26 RID: 10790
			public const string SFX_BOOK_FALLS_03 = "sfx_book_falls_03";

			// Token: 0x04002A27 RID: 10791
			public const string SFX_BOOK_PUSH_01 = "sfx_book_push_01";

			// Token: 0x04002A28 RID: 10792
			public const string SFX_BOOK_PUSH_02 = "sfx_book_push_02";

			// Token: 0x04002A29 RID: 10793
			public const string SFX_BOOK_PUSH_03 = "sfx_book_push_03";

			// Token: 0x04002A2A RID: 10794
			public const string SFX_BOOK_PUSH_04 = "sfx_book_push_04";

			// Token: 0x04002A2B RID: 10795
			public const string SFX_BORIS_ATTACKS_01 = "sfx_boris_attacks_01";

			// Token: 0x04002A2C RID: 10796
			public const string SFX_BORIS_ATTACKS_02 = "sfx_boris_attacks_02";

			// Token: 0x04002A2D RID: 10797
			public const string SFX_BORIS_ATTACKS_03 = "sfx_boris_attacks_03";

			// Token: 0x04002A2E RID: 10798
			public const string SFX_BORIS_ATTACKS_04 = "sfx_boris_attacks_04";

			// Token: 0x04002A2F RID: 10799
			public const string SFX_BORIS_ATTACKS_05 = "sfx_boris_attacks_05";

			// Token: 0x04002A30 RID: 10800
			public const string SFX_BORIS_BATTLE_FALL = "sfx_boris_battle_fall";

			// Token: 0x04002A31 RID: 10801
			public const string SFX_BORIS_CHARGE = "sfx_boris_charge";

			// Token: 0x04002A32 RID: 10802
			public const string SFX_BORIS_DEATH_FINAL = "sfx_boris_death_final";

			// Token: 0x04002A33 RID: 10803
			public const string SFX_BORIS_FOOTSTEPS_01 = "sfx_boris_footsteps_01";

			// Token: 0x04002A34 RID: 10804
			public const string SFX_BORIS_FOOTSTEPS_02 = "sfx_boris_footsteps_02";

			// Token: 0x04002A35 RID: 10805
			public const string SFX_BORIS_FOOTSTEPS_03 = "sfx_boris_footsteps_03";

			// Token: 0x04002A36 RID: 10806
			public const string SFX_BORIS_FOOTSTEPS_04 = "sfx_boris_footsteps_04";

			// Token: 0x04002A37 RID: 10807
			public const string SFX_BORIS_FOOTSTEPS_05 = "sfx_boris_footsteps_05";

			// Token: 0x04002A38 RID: 10808
			public const string SFX_BORIS_FOOTSTEPS_06 = "sfx_boris_footsteps_06";

			// Token: 0x04002A39 RID: 10809
			public const string SFX_BORIS_FOOTSTEPS_07 = "sfx_boris_footsteps_07";

			// Token: 0x04002A3A RID: 10810
			public const string SFX_BORIS_FOOTSTEPS_08 = "sfx_boris_footsteps_08";

			// Token: 0x04002A3B RID: 10811
			public const string SFX_BORIS_FOOTSTEPS_09 = "sfx_boris_footsteps_09";

			// Token: 0x04002A3C RID: 10812
			public const string SFX_BORIS_HIT_01 = "sfx_boris_hit_01";

			// Token: 0x04002A3D RID: 10813
			public const string SFX_BORIS_HIT_02 = "sfx_boris_hit_02";

			// Token: 0x04002A3E RID: 10814
			public const string SFX_BORIS_HIT_03 = "sfx_boris_hit_03";

			// Token: 0x04002A3F RID: 10815
			public const string SFX_BORIS_HIT_04 = "sfx_boris_hit_04";

			// Token: 0x04002A40 RID: 10816
			public const string SFX_BORIS_INK_GUSH_01 = "sfx_boris_ink_gush_01";

			// Token: 0x04002A41 RID: 10817
			public const string SFX_BORIS_INK_GUSH_02 = "sfx_boris_ink_gush_02";

			// Token: 0x04002A42 RID: 10818
			public const string SFX_BORIS_INK_GUSH_03 = "sfx_boris_ink_gush_03";

			// Token: 0x04002A43 RID: 10819
			public const string SFX_BORIS_INK_GUSH_04 = "sfx_boris_ink_gush_04";

			// Token: 0x04002A44 RID: 10820
			public const string SFX_BORIS_INK_GUSH_05 = "sfx_boris_ink_gush_05";

			// Token: 0x04002A45 RID: 10821
			public const string SFX_BORIS_INK_GUSH_06 = "sfx_boris_ink_gush_06";

			// Token: 0x04002A46 RID: 10822
			public const string SFX_BORIS_JUMP = "sfx_boris_jump";

			// Token: 0x04002A47 RID: 10823
			public const string SFX_BORIS_LAND_ATTACK = "sfx_boris_land_attack";

			// Token: 0x04002A48 RID: 10824
			public const string SFX_BORIS_POUND_ATTACK = "sfx_boris_pound_attack";

			// Token: 0x04002A49 RID: 10825
			public const string SFX_BORIS_REVEAL = "sfx_boris_reveal";

			// Token: 0x04002A4A RID: 10826
			public const string SFX_BRIDGE_MACHINE_BREAKDOWN = "sfx_bridge_machine_breakdown";

			// Token: 0x04002A4B RID: 10827
			public const string SFX_BRIDGE_MACHINE_END = "sfx_bridge_machine_end";

			// Token: 0x04002A4C RID: 10828
			public const string SFX_BRIDGE_MACHINE_ENTER = "sfx_bridge_machine_enter";

			// Token: 0x04002A4D RID: 10829
			public const string SFX_BRIDGE_MACHINE_EXIT = "sfx_bridge_machine_exit";

			// Token: 0x04002A4E RID: 10830
			public const string SFX_BRIDGE_MACHINE_GEAR_FIT = "sfx_bridge_machine_gear_fit";

			// Token: 0x04002A4F RID: 10831
			public const string SFX_BRIDGE_MACHINE_ROPE = "sfx_bridge_machine_rope";

			// Token: 0x04002A50 RID: 10832
			public const string SFX_BRIDGE_MACHINE_RUNNING = "sfx_bridge_machine_running";

			// Token: 0x04002A51 RID: 10833
			public const string SFX_BRIDGE_MACHINE_START = "sfx_bridge_machine_start";

			// Token: 0x04002A52 RID: 10834
			public const string SFX_BRIDGE_MACHINE_STOP = "sfx_bridge_machine_stop";

			// Token: 0x04002A53 RID: 10835
			public const string SFX_CAN_LANDING_01 = "sfx_can_landing_01";

			// Token: 0x04002A54 RID: 10836
			public const string SFX_CAN_LANDING_02 = "sfx_can_landing_02";

			// Token: 0x04002A55 RID: 10837
			public const string SFX_CAN_LANDING_03 = "sfx_can_landing_03";

			// Token: 0x04002A56 RID: 10838
			public const string SFX_CAN_LANDING_04 = "sfx_can_landing_04";

			// Token: 0x04002A57 RID: 10839
			public const string SFX_CAN_LANDING_05 = "sfx_can_landing_05";

			// Token: 0x04002A58 RID: 10840
			public const string SFX_CAN_LANDING_06 = "sfx_can_landing_06";

			// Token: 0x04002A59 RID: 10841
			public const string SFX_CAN_LANDING_07 = "sfx_can_landing_07";

			// Token: 0x04002A5A RID: 10842
			public const string SFX_CAN_PICKUP_01 = "sfx_can_pickup_01";

			// Token: 0x04002A5B RID: 10843
			public const string SFX_CAN_PICKUP_02 = "sfx_can_pickup_02";

			// Token: 0x04002A5C RID: 10844
			public const string SFX_CAN_PICKUP_03 = "sfx_can_pickup_03";

			// Token: 0x04002A5D RID: 10845
			public const string SFX_CAN_PICKUP_04 = "sfx_can_pickup_04";

			// Token: 0x04002A5E RID: 10846
			public const string SFX_CAN_PICKUP_05 = "sfx_can_pickup_05";

			// Token: 0x04002A5F RID: 10847
			public const string SFX_CAN_PICKUP_06 = "sfx_can_pickup_06";

			// Token: 0x04002A60 RID: 10848
			public const string SFX_CAN_PICKUP_07 = "sfx_can_pickup_07";

			// Token: 0x04002A61 RID: 10849
			public const string SFX_CAN_PICKUP_08 = "sfx_can_pickup_08";

			// Token: 0x04002A62 RID: 10850
			public const string SFX_CAN_PICKUP_09 = "sfx_can_pickup_09";

			// Token: 0x04002A63 RID: 10851
			public const string SFX_CAN_PICKUP_10 = "sfx_can_pickup_10";

			// Token: 0x04002A64 RID: 10852
			public const string SFX_CAN_TOSS_01 = "sfx_can_toss_01";

			// Token: 0x04002A65 RID: 10853
			public const string SFX_CAN_TOSS_02 = "sfx_can_toss_02";

			// Token: 0x04002A66 RID: 10854
			public const string SFX_CAN_TOSS_03 = "sfx_can_toss_03";

			// Token: 0x04002A67 RID: 10855
			public const string SFX_CAN_TOSS_04 = "sfx_can_toss_04";

			// Token: 0x04002A68 RID: 10856
			public const string SFX_CAN_TOSS_05 = "sfx_can_toss_05";

			// Token: 0x04002A69 RID: 10857
			public const string SFX_CAN_TOSS_06 = "sfx_can_toss_06";

			// Token: 0x04002A6A RID: 10858
			public const string SFX_CAN_TOSS_07 = "sfx_can_toss_07";

			// Token: 0x04002A6B RID: 10859
			public const string SFX_CART_IMPACT_01 = "sfx_cart_impact_01";

			// Token: 0x04002A6C RID: 10860
			public const string SFX_CART_IMPACT_02 = "sfx_cart_impact_02";

			// Token: 0x04002A6D RID: 10861
			public const string SFX_CART_IMPACT_03 = "sfx_cart_impact_03";

			// Token: 0x04002A6E RID: 10862
			public const string SFX_CART_IMPACT_04 = "sfx_cart_impact_04";

			// Token: 0x04002A6F RID: 10863
			public const string SFX_CART_IMPACT_05 = "sfx_cart_impact_05";

			// Token: 0x04002A70 RID: 10864
			public const string SFX_CART_IMPACT_06 = "sfx_cart_impact_06";

			// Token: 0x04002A71 RID: 10865
			public const string SFX_CH1_CAVEIN_MIX = "sfx_ch1_cavein_mix";

			// Token: 0x04002A72 RID: 10866
			public const string SFX_CREEPY_SOUNDS_01 = "sfx_creepy_sounds_01";

			// Token: 0x04002A73 RID: 10867
			public const string SFX_CREEPY_SOUNDS_02 = "sfx_creepy_sounds_02";

			// Token: 0x04002A74 RID: 10868
			public const string SFX_CREEPY_SOUNDS_03 = "sfx_creepy_sounds_03";

			// Token: 0x04002A75 RID: 10869
			public const string SFX_CREEPY_SOUNDS_04 = "sfx_creepy_sounds_04";

			// Token: 0x04002A76 RID: 10870
			public const string SFX_CREEPY_SOUNDS_05 = "sfx_creepy_sounds_05";

			// Token: 0x04002A77 RID: 10871
			public const string SFX_CREEPY_SOUNDS_06 = "sfx_creepy_sounds_06";

			// Token: 0x04002A78 RID: 10872
			public const string SFX_CREEPY_SOUNDS_07 = "sfx_creepy_sounds_07";

			// Token: 0x04002A79 RID: 10873
			public const string SFX_CREEPY_SOUNDS_08 = "sfx_creepy_sounds_08";

			// Token: 0x04002A7A RID: 10874
			public const string SFX_CREEPY_SOUNDS_09 = "sfx_creepy_sounds_09";

			// Token: 0x04002A7B RID: 10875
			public const string SFX_CREEPY_SOUNDS_10 = "sfx_creepy_sounds_10";

			// Token: 0x04002A7C RID: 10876
			public const string SFX_CREEPY_SOUNDS_11 = "sfx_creepy_sounds_11";

			// Token: 0x04002A7D RID: 10877
			public const string SFX_CREEPY_SOUNDS_12 = "sfx_creepy_sounds_12";

			// Token: 0x04002A7E RID: 10878
			public const string SFX_CREEPY_SOUNDS_13 = "sfx_creepy_sounds_13";

			// Token: 0x04002A7F RID: 10879
			public const string SFX_CREEP_LAUGH = "sfx_creep_laugh";

			// Token: 0x04002A80 RID: 10880
			public const string SFX_DART_DROP = "sfx_dart_drop";

			// Token: 0x04002A81 RID: 10881
			public const string SFX_DART_PICKUP = "sfx_dart_pickup";

			// Token: 0x04002A82 RID: 10882
			public const string SFX_DEATH_TUNNEL_LOOP = "sfx_death_tunnel_loop";

			// Token: 0x04002A83 RID: 10883
			public const string SFX_DOOR_METAL_ROLLING_OPEN = "sfx_door_metal_rolling_open";

			// Token: 0x04002A84 RID: 10884
			public const string SFX_DOOR_QUEST_GATE_CLOSE = "sfx_door_quest_gate_close";

			// Token: 0x04002A85 RID: 10885
			public const string SFX_DOOR_QUEST_GATE_OPEN = "sfx_door_quest_gate_open";

			// Token: 0x04002A86 RID: 10886
			public const string SFX_FAIR_GAME_LOSE_BUZZ = "sfx_fair_game_lose_buzz";

			// Token: 0x04002A87 RID: 10887
			public const string SFX_FAIR_GAME_WIN_BELLS = "sfx_fair_game_win_bells";

			// Token: 0x04002A88 RID: 10888
			public const string SFX_FAIR_GAME_WIN_MIX = "sfx_fair_game_win_mix";

			// Token: 0x04002A89 RID: 10889
			public const string SFX_FALLING_ROAR = "sfx_falling_roar";

			// Token: 0x04002A8A RID: 10890
			public const string SFX_GROUND_SHAKE = "sfx_ground_shake";

			// Token: 0x04002A8B RID: 10891
			public const string SFX_GROUND_SHAKE_START = "sfx_ground_shake_start";

			// Token: 0x04002A8C RID: 10892
			public const string SFX_HAMMER_BELL = "sfx_hammer_bell";

			// Token: 0x04002A8D RID: 10893
			public const string SFX_HAMMER_DROP = "sfx_hammer_drop";

			// Token: 0x04002A8E RID: 10894
			public const string SFX_HAMMER_HIT = "sfx_hammer_hit";

			// Token: 0x04002A8F RID: 10895
			public const string SFX_HAMMER_PICKUP = "sfx_hammer_pickup";

			// Token: 0x04002A90 RID: 10896
			public const string SFX_HAMMER_RESET = "sfx_hammer_reset";

			// Token: 0x04002A91 RID: 10897
			public const string SFX_HAMMER_SLIDE = "sfx_hammer_slide";

			// Token: 0x04002A92 RID: 10898
			public const string SFX_HAUNTED_HOUSE_CART_ENTER = "sfx_haunted_house_cart_enter";

			// Token: 0x04002A93 RID: 10899
			public const string SFX_HAUNTED_HOUSE_CART_LOOP = "sfx_haunted_house_cart_loop";

			// Token: 0x04002A94 RID: 10900
			public const string SFX_HAUNTED_HOUSE_CART_SMASH = "sfx_haunted_house_cart_smash";

			// Token: 0x04002A95 RID: 10901
			public const string SFX_HAUNTED_HOUSE_CART_START = "sfx_haunted_house_cart_start";

			// Token: 0x04002A96 RID: 10902
			public const string SFX_HAUNTED_HOUSE_GATE_OPEN_01 = "sfx_haunted_house_gate_open_01";

			// Token: 0x04002A97 RID: 10903
			public const string SFX_HAUNTED_HOUSE_GATE_OPEN_02 = "sfx_haunted_house_gate_open_02";

			// Token: 0x04002A98 RID: 10904
			public const string SFX_HAUNTED_HOUSE_GATE_OPEN_03 = "sfx_haunted_house_gate_open_03";

			// Token: 0x04002A99 RID: 10905
			public const string SFX_HAUNTED_HOUSE_POPUPS_01 = "sfx_haunted_house_popups_01";

			// Token: 0x04002A9A RID: 10906
			public const string SFX_HAUNTED_HOUSE_POPUPS_02 = "sfx_haunted_house_popups_02";

			// Token: 0x04002A9B RID: 10907
			public const string SFX_HAUNTED_HOUSE_POPUPS_03 = "sfx_haunted_house_popups_03";

			// Token: 0x04002A9C RID: 10908
			public const string SFX_HAUNTED_HOUSE_POPUPS_04 = "sfx_haunted_house_popups_04";

			// Token: 0x04002A9D RID: 10909
			public const string SFX_HAUNTED_HOUSE_POPUPS_05 = "sfx_haunted_house_popups_05";

			// Token: 0x04002A9E RID: 10910
			public const string SFX_HAUNTED_HOUSE_POPUPS_06 = "sfx_haunted_house_popups_06";

			// Token: 0x04002A9F RID: 10911
			public const string SFX_HAUNTED_LAUGH_GROUP_01 = "sfx_haunted_laugh_group_01";

			// Token: 0x04002AA0 RID: 10912
			public const string SFX_HAUNTED_LAUGH_GROUP_02 = "sfx_haunted_laugh_group_02";

			// Token: 0x04002AA1 RID: 10913
			public const string SFX_HAUNTED_LAUGH_GROUP_03 = "sfx_haunted_laugh_group_03";

			// Token: 0x04002AA2 RID: 10914
			public const string SFX_HAUNTED_LAUGH_GROUP_04 = "sfx_haunted_laugh_group_04";

			// Token: 0x04002AA3 RID: 10915
			public const string SFX_HAUNTED_LAUGH_GROUP_05 = "sfx_haunted_laugh_group_05";

			// Token: 0x04002AA4 RID: 10916
			public const string SFX_HAUNTED_LAUGH_GROUP_06 = "sfx_haunted_laugh_group_06";

			// Token: 0x04002AA5 RID: 10917
			public const string SFX_HEADBANG_ECHO_LFE_01 = "sfx_headbang_echo_lfe_01";

			// Token: 0x04002AA6 RID: 10918
			public const string SFX_HEADBANG_ECHO_LFE_02 = "sfx_headbang_echo_lfe_02";

			// Token: 0x04002AA7 RID: 10919
			public const string SFX_HEADBANG_ECHO_LFE_03 = "sfx_headbang_echo_lfe_03";

			// Token: 0x04002AA8 RID: 10920
			public const string SFX_HEADBANG_ECHO_LFE_04 = "sfx_headbang_echo_lfe_04";

			// Token: 0x04002AA9 RID: 10921
			public const string SFX_HEADBANG_ECHO_LFE_05 = "sfx_headbang_echo_lfe_05";

			// Token: 0x04002AAA RID: 10922
			public const string SFX_HEADBANG_ECHO_LFE_06 = "sfx_headbang_echo_lfe_06";

			// Token: 0x04002AAB RID: 10923
			public const string SFX_HEADBANG_ECHO_LFE_07 = "sfx_headbang_echo_lfe_07";

			// Token: 0x04002AAC RID: 10924
			public const string SFX_HIDDEN_DOOR_SLIDE = "sfx_hidden_door_slide";

			// Token: 0x04002AAD RID: 10925
			public const string SFX_HORROR_VISION_LOOP_01 = "sfx_horror_vision_loop_01";

			// Token: 0x04002AAE RID: 10926
			public const string SFX_HORROR_VISION_LOOP_02 = "sfx_horror_vision_loop_02";

			// Token: 0x04002AAF RID: 10927
			public const string SFX_HORROR_VISION_LOOP_03 = "sfx_horror_vision_loop_03";

			// Token: 0x04002AB0 RID: 10928
			public const string SFX_HORROR_VISION_START_01 = "sfx_horror_vision_start_01";

			// Token: 0x04002AB1 RID: 10929
			public const string SFX_HORROR_VISION_START_02 = "sfx_horror_vision_start_02";

			// Token: 0x04002AB2 RID: 10930
			public const string SFX_HORROR_VISION_START_03 = "sfx_horror_vision_start_03";

			// Token: 0x04002AB3 RID: 10931
			public const string SFX_HORROR_VISION_STOP_01 = "sfx_horror_vision_stop_01";

			// Token: 0x04002AB4 RID: 10932
			public const string SFX_HORROR_VISION_STOP_02 = "sfx_horror_vision_stop_02";

			// Token: 0x04002AB5 RID: 10933
			public const string SFX_HORROR_VISION_STOP_03 = "sfx_horror_vision_stop_03";

			// Token: 0x04002AB6 RID: 10934
			public const string SFX_HORROR_VOICES_LOOP = "sfx_horror_voices_loop";

			// Token: 0x04002AB7 RID: 10935
			public const string SFX_INK_BURSTS_01 = "sfx_ink_bursts_01";

			// Token: 0x04002AB8 RID: 10936
			public const string SFX_INK_BURSTS_02 = "sfx_ink_bursts_02";

			// Token: 0x04002AB9 RID: 10937
			public const string SFX_INK_BURSTS_03 = "sfx_ink_bursts_03";

			// Token: 0x04002ABA RID: 10938
			public const string SFX_INK_BURSTS_04 = "sfx_ink_bursts_04";

			// Token: 0x04002ABB RID: 10939
			public const string SFX_INK_BURSTS_05 = "sfx_ink_bursts_05";

			// Token: 0x04002ABC RID: 10940
			public const string SFX_INK_BURSTS_06 = "sfx_ink_bursts_06";

			// Token: 0x04002ABD RID: 10941
			public const string SFX_INK_DRAINED_VALVE = "sfx_ink_drained_valve";

			// Token: 0x04002ABE RID: 10942
			public const string SFX_INK_HEAVY_FLOW_LOOP = "sfx_ink_heavy_flow_loop";

			// Token: 0x04002ABF RID: 10943
			public const string SFX_INK_MACHINE_MOVING_LOOP = "sfx_ink_machine_moving_loop";

			// Token: 0x04002AC0 RID: 10944
			public const string SFX_INK_MACHINE_STOP = "sfx_ink_machine_stop";

			// Token: 0x04002AC1 RID: 10945
			public const string SFX_INK_MACHINE_UNLOCK = "sfx_ink_machine_unlock";

			// Token: 0x04002AC2 RID: 10946
			public const string SFX_INK_MACHINE_WORKING_LOOP = "sfx_ink_machine_working_loop";

			// Token: 0x04002AC3 RID: 10947
			public const string SFX_INK_MAKER_ADD_INK_01 = "sfx_ink_maker_add_ink_01";

			// Token: 0x04002AC4 RID: 10948
			public const string SFX_INK_MAKER_ADD_INK_02 = "sfx_ink_maker_add_ink_02";

			// Token: 0x04002AC5 RID: 10949
			public const string SFX_INK_MAKER_ADD_INK_03 = "sfx_ink_maker_add_ink_03";

			// Token: 0x04002AC6 RID: 10950
			public const string SFX_INK_MAKER_ADD_INK_04 = "sfx_ink_maker_add_ink_04";

			// Token: 0x04002AC7 RID: 10951
			public const string SFX_INK_MAKER_ADD_INK_05 = "sfx_ink_maker_add_ink_05";

			// Token: 0x04002AC8 RID: 10952
			public const string SFX_INK_MAKER_ADD_INK_06 = "sfx_ink_maker_add_ink_06";

			// Token: 0x04002AC9 RID: 10953
			public const string SFX_INK_MAKER_MADE_CERAMIC_01 = "sfx_ink_maker_made_ceramic_01";

			// Token: 0x04002ACA RID: 10954
			public const string SFX_INK_MAKER_MADE_CERAMIC_02 = "sfx_ink_maker_made_ceramic_02";

			// Token: 0x04002ACB RID: 10955
			public const string SFX_INK_MAKER_MADE_CERAMIC_03 = "sfx_ink_maker_made_ceramic_03";

			// Token: 0x04002ACC RID: 10956
			public const string SFX_INK_MAKER_MADE_CERAMIC_04 = "sfx_ink_maker_made_ceramic_04";

			// Token: 0x04002ACD RID: 10957
			public const string SFX_INK_MAKER_MADE_METAL_01 = "sfx_ink_maker_made_metal_01";

			// Token: 0x04002ACE RID: 10958
			public const string SFX_INK_MAKER_MADE_METAL_02 = "sfx_ink_maker_made_metal_02";

			// Token: 0x04002ACF RID: 10959
			public const string SFX_INK_MAKER_MADE_METAL_03 = "sfx_ink_maker_made_metal_03";

			// Token: 0x04002AD0 RID: 10960
			public const string SFX_INK_MAKER_MADE_METAL_04 = "sfx_ink_maker_made_metal_04";

			// Token: 0x04002AD1 RID: 10961
			public const string SFX_INK_MAKER_MADE_WOOD_01 = "sfx_ink_maker_made_wood_01";

			// Token: 0x04002AD2 RID: 10962
			public const string SFX_INK_MAKER_MADE_WOOD_02 = "sfx_ink_maker_made_wood_02";

			// Token: 0x04002AD3 RID: 10963
			public const string SFX_INK_MAKER_MADE_WOOD_03 = "sfx_ink_maker_made_wood_03";

			// Token: 0x04002AD4 RID: 10964
			public const string SFX_INK_MAKER_MADE_WOOD_04 = "sfx_ink_maker_made_wood_04";

			// Token: 0x04002AD5 RID: 10965
			public const string SFX_INK_MAKER_MAKING = "sfx_ink_maker_making";

			// Token: 0x04002AD6 RID: 10966
			public const string SFX_INK_MAKER_SELECT = "sfx_ink_maker_select";

			// Token: 0x04002AD7 RID: 10967
			public const string SFX_INK_MOVES_01 = "sfx_ink_moves_01";

			// Token: 0x04002AD8 RID: 10968
			public const string SFX_INK_MOVES_02 = "sfx_ink_moves_02";

			// Token: 0x04002AD9 RID: 10969
			public const string SFX_INK_MOVES_03 = "sfx_ink_moves_03";

			// Token: 0x04002ADA RID: 10970
			public const string SFX_INK_MOVES_04 = "sfx_ink_moves_04";

			// Token: 0x04002ADB RID: 10971
			public const string SFX_INK_MOVES_05 = "sfx_ink_moves_05";

			// Token: 0x04002ADC RID: 10972
			public const string SFX_INK_MOVES_06 = "sfx_ink_moves_06";

			// Token: 0x04002ADD RID: 10973
			public const string SFX_INK_MOVES_07 = "sfx_ink_moves_07";

			// Token: 0x04002ADE RID: 10974
			public const string SFX_INK_PIPE_BURST = "sfx_ink_pipe_burst";

			// Token: 0x04002ADF RID: 10975
			public const string SFX_INK_PIPE_OPENS = "sfx_ink_pipe_opens";

			// Token: 0x04002AE0 RID: 10976
			public const string SFX_INK_SPRAY_LOOP = "sfx_ink_spray_loop";

			// Token: 0x04002AE1 RID: 10977
			public const string SFX_INK_SWOLEN_APPEAR_CH4 = "sfx_ink_swolen_appear_ch4";

			// Token: 0x04002AE2 RID: 10978
			public const string SFX_INK_TUBE_CLOSED = "sfx_ink_tube_closed";

			// Token: 0x04002AE3 RID: 10979
			public const string SFX_INK_TUBE_OPEN = "sfx_ink_tube_open";

			// Token: 0x04002AE4 RID: 10980
			public const string SFX_INK_TUBE_SMASHED_01 = "sfx_ink_tube_smashed_01";

			// Token: 0x04002AE5 RID: 10981
			public const string SFX_INK_TUBE_SMASHED_02 = "sfx_ink_tube_smashed_02";

			// Token: 0x04002AE6 RID: 10982
			public const string SFX_INK_TUBE_SMASHED_03 = "sfx_ink_tube_smashed_03";

			// Token: 0x04002AE7 RID: 10983
			public const string SFX_INK_TUBE_SMASHED_04 = "sfx_ink_tube_smashed_04";

			// Token: 0x04002AE8 RID: 10984
			public const string SFX_JOEY_WHISTLES_01 = "sfx_joey_whistles_01";

			// Token: 0x04002AE9 RID: 10985
			public const string SFX_JOEY_WHISTLES_02 = "sfx_joey_whistles_02";

			// Token: 0x04002AEA RID: 10986
			public const string SFX_JOEY_WHISTLES_03 = "sfx_joey_whistles_03";

			// Token: 0x04002AEB RID: 10987
			public const string SFX_LIGHTBULB_DETAIL_01 = "sfx_lightbulb_detail_01";

			// Token: 0x04002AEC RID: 10988
			public const string SFX_LIGHTBULB_DETAIL_02 = "sfx_lightbulb_detail_02";

			// Token: 0x04002AED RID: 10989
			public const string SFX_LIGHTBULB_DETAIL_03 = "sfx_lightbulb_detail_03";

			// Token: 0x04002AEE RID: 10990
			public const string SFX_LIGHTBULB_DETAIL_04 = "sfx_lightbulb_detail_04";

			// Token: 0x04002AEF RID: 10991
			public const string SFX_LIGHTS_FLICKER_BUZZ_LOOP = "sfx_lights_flicker_buzz_loop";

			// Token: 0x04002AF0 RID: 10992
			public const string SFX_PANEL_HUM_LOOP = "sfx_panel_hum_loop";

			// Token: 0x04002AF1 RID: 10993
			public const string SFX_PHONOGRAPH_CRACKLE_01 = "sfx_phonograph_crackle_01";

			// Token: 0x04002AF2 RID: 10994
			public const string SFX_PHONOGRAPH_CRACKLE_02 = "sfx_phonograph_crackle_02";

			// Token: 0x04002AF3 RID: 10995
			public const string SFX_PHONOGRAPH_LOOP = "sfx_phonograph_loop";

			// Token: 0x04002AF4 RID: 10996
			public const string SFX_PHONOGRAPH_SILENCE = "sfx_phonograph_silence";

			// Token: 0x04002AF5 RID: 10997
			public const string SFX_PLAYER_HITS_WALL = "sfx_player_hits_wall";

			// Token: 0x04002AF6 RID: 10998
			public const string SFX_PLAYER_HIT_BY_BORIS_01 = "sfx_player_hit_by_boris_01";

			// Token: 0x04002AF7 RID: 10999
			public const string SFX_PLAYER_HIT_BY_BORIS_02 = "sfx_player_hit_by_boris_02";

			// Token: 0x04002AF8 RID: 11000
			public const string SFX_PLAYER_HIT_BY_BORIS_03 = "sfx_player_hit_by_boris_03";

			// Token: 0x04002AF9 RID: 11001
			public const string SFX_PLAYER_HIT_BY_BORIS_04 = "sfx_player_hit_by_boris_04";

			// Token: 0x04002AFA RID: 11002
			public const string SFX_PLAYER_HIT_BY_BORIS_05 = "sfx_player_hit_by_boris_05";

			// Token: 0x04002AFB RID: 11003
			public const string SFX_PLAYER_HIT_BY_BORIS_06 = "sfx_player_hit_by_boris_06";

			// Token: 0x04002AFC RID: 11004
			public const string SFX_POOLBALL_HIT = "SFX_Poolball_Hit";

			// Token: 0x04002AFD RID: 11005
			public const string SFX_POPGUN_DROP = "sfx_popgun_drop";

			// Token: 0x04002AFE RID: 11006
			public const string SFX_POPGUN_FIRE = "sfx_popgun_fire";

			// Token: 0x04002AFF RID: 11007
			public const string SFX_POPGUN_PICKUP = "sfx_popgun_pickup";

			// Token: 0x04002B00 RID: 11008
			public const string SFX_POPGUN_TARGET_BAD = "sfx_popgun_target_bad";

			// Token: 0x04002B01 RID: 11009
			public const string SFX_POPGUN_TARGET_GOOD = "sfx_popgun_target_good";

			// Token: 0x04002B02 RID: 11010
			public const string SFX_POPGUN_TARGET_RESET = "sfx_popgun_target_reset";

			// Token: 0x04002B03 RID: 11011
			public const string SFX_PROJECTIONIST_APPEAR = "sfx_projectionist_appear";

			// Token: 0x04002B04 RID: 11012
			public const string SFX_PROPS_WOOD_SMASH_01 = "sfx_props_wood_smash_01";

			// Token: 0x04002B05 RID: 11013
			public const string SFX_PROPS_WOOD_SMASH_02 = "sfx_props_wood_smash_02";

			// Token: 0x04002B06 RID: 11014
			public const string SFX_PROPS_WOOD_SMASH_03 = "sfx_props_wood_smash_03";

			// Token: 0x04002B07 RID: 11015
			public const string SFX_PROPS_WOOD_SMASH_04 = "sfx_props_wood_smash_04";

			// Token: 0x04002B08 RID: 11016
			public const string SFX_PROPS_WOOD_SMASH_05 = "sfx_props_wood_smash_05";

			// Token: 0x04002B09 RID: 11017
			public const string SFX_SAFES_GOING_CRAZY = "sfx_safes_going_crazy";

			// Token: 0x04002B0A RID: 11018
			public const string SFX_SCENE_04A_TOM = "sfx_scene_04a_tom";

			// Token: 0x04002B0B RID: 11019
			public const string SFX_SCENE_04B_TOM = "sfx_scene_04b_tom";

			// Token: 0x04002B0C RID: 11020
			public const string SFX_SEEING_TOOL_LOOP = "sfx_seeing_tool_loop";

			// Token: 0x04002B0D RID: 11021
			public const string SFX_SEEING_TOOL_OFF = "sfx_seeing_tool_off";

			// Token: 0x04002B0E RID: 11022
			public const string SFX_SEEING_TOOL_ON = "sfx_seeing_tool_on";

			// Token: 0x04002B0F RID: 11023
			public const string SFX_SMALL_GEARS_WORKING_LOOP = "sfx_small_gears_working_loop";

			// Token: 0x04002B10 RID: 11024
			public const string SFX_SPOON_LEVER = "sfx_spoon_lever";

			// Token: 0x04002B11 RID: 11025
			public const string SFX_SPOTLIGHT_ON1 = "sfx_spotlight_on1";

			// Token: 0x04002B12 RID: 11026
			public const string SFX_SPOTLIGHT_ON2 = "sfx_spotlight_on2";

			// Token: 0x04002B13 RID: 11027
			public const string SFX_SPOTLIGHT_ON3 = "sfx_spotlight_on3";

			// Token: 0x04002B14 RID: 11028
			public const string SFX_THICK_INK_COLLECTED_01 = "sfx_thick_ink_collected_01";

			// Token: 0x04002B15 RID: 11029
			public const string SFX_THICK_INK_COLLECTED_02 = "sfx_thick_ink_collected_02";

			// Token: 0x04002B16 RID: 11030
			public const string SFX_THICK_INK_COLLECTED_03 = "sfx_thick_ink_collected_03";

			// Token: 0x04002B17 RID: 11031
			public const string SFX_THICK_INK_COLLECTED_04 = "sfx_thick_ink_collected_04";

			// Token: 0x04002B18 RID: 11032
			public const string SFX_THICK_INK_COLLECTED_05 = "sfx_thick_ink_collected_05";

			// Token: 0x04002B19 RID: 11033
			public const string SFX_TOILET_LID = "sfx_toilet_lid";

			// Token: 0x04002B1A RID: 11034
			public const string SFX_WAREHOUSE_TURNS_ON2 = "sfx_warehouse_turns_on2";

			// Token: 0x04002B1B RID: 11035
			public const string SFX_WOOD_CREAK_WALK_LONG = "sfx_wood_creak_walk_long";

			// Token: 0x04002B1C RID: 11036
			public const string SFX_WOOD_DOOR_OPEN_GENERIC = "sfx_wood_door_open_generic";

			// Token: 0x04002B1D RID: 11037
			public const string VO_ALICE_CH4_TRAILERVOICE = "vo_alice_ch4_trailervoice";

			// Token: 0x04002B1E RID: 11038
			public const string VO_ALICE_S0601_RINGTHEBELLWON = "vo_alice_s06-01_ringthebellwon";

			// Token: 0x04002B1F RID: 11039
			public const string VO_ALICE_S0701_ALICEFINALE = "vo_alice_s07-01_alicefinale";

			// Token: 0x04002B20 RID: 11040
			public const string VO_BEAST_BENDY_DAZED_01 = "vo_beast_bendy_dazed_01";

			// Token: 0x04002B21 RID: 11041
			public const string VO_BEAST_BENDY_DAZED_02 = "vo_beast_bendy_dazed_02";

			// Token: 0x04002B22 RID: 11042
			public const string VO_BEAST_BENDY_DAZED_03 = "vo_beast_bendy_dazed_03";

			// Token: 0x04002B23 RID: 11043
			public const string VO_BEAST_BENDY_DAZED_04 = "vo_beast_bendy_dazed_04";

			// Token: 0x04002B24 RID: 11044
			public const string VO_BEAST_BENDY_DAZED_05 = "vo_beast_bendy_dazed_05";

			// Token: 0x04002B25 RID: 11045
			public const string VO_BEAST_BENDY_ROAR_00 = "vo_beast_bendy_roar_00";

			// Token: 0x04002B26 RID: 11046
			public const string VO_BEAST_BENDY_ROAR_01 = "vo_beast_bendy_roar_01";

			// Token: 0x04002B27 RID: 11047
			public const string VO_BEAST_BENDY_ROAR_02 = "vo_beast_bendy_roar_02";

			// Token: 0x04002B28 RID: 11048
			public const string VO_BEAST_BENDY_ROAR_03 = "vo_beast_bendy_roar_03";

			// Token: 0x04002B29 RID: 11049
			public const string VO_BEAST_BENDY_ROAR_04 = "vo_beast_bendy_roar_04";

			// Token: 0x04002B2A RID: 11050
			public const string VO_BEAST_BENDY_ROAR_05 = "vo_beast_bendy_roar_05";

			// Token: 0x04002B2B RID: 11051
			public const string VO_BEAST_BENDY_ROAR_06 = "vo_beast_bendy_roar_06";

			// Token: 0x04002B2C RID: 11052
			public const string VO_HENRY_CH4_START = "vo_henry_ch4_start";

			// Token: 0x04002B2D RID: 11053
			public const string _TEST_20DBFS_1K_LOOP = "_test_20dBfs_1k_loop";

			// Token: 0x04002B2E RID: 11054
			public const string _TEST_BEEP = "_test_beep";

			// Token: 0x04002B2F RID: 11055
			public const string _TEST_COMBINED = "_test_combined";

			// Token: 0x04002B30 RID: 11056
			public const string _TEST_REVERB_LOOP = "_test_reverb_loop";

			// Token: 0x04002B31 RID: 11057
			public const string _TEST_SWEEP = "_test_sweep";

			// Token: 0x04002B32 RID: 11058
			public const string EVT_GAME_IS_AWAKE = "evt_game_is_awake";

			// Token: 0x04002B33 RID: 11059
			public const string EVT_GAME_AT_MAIN_MENU = "evt_game_at_main_menu";

			// Token: 0x04002B34 RID: 11060
			public const string EVT_GAME_AT_LOADING_CHAPTER1 = "evt_game_at_loading_chapter1";

			// Token: 0x04002B35 RID: 11061
			public const string EVT_GAME_AT_LOADING_CHAPTER2 = "evt_game_at_loading_chapter2";

			// Token: 0x04002B36 RID: 11062
			public const string EVT_GAME_AT_LOADING_CHAPTER3 = "evt_game_at_loading_chapter3";

			// Token: 0x04002B37 RID: 11063
			public const string EVT_GAME_AT_LOADING_CHAPTER4 = "evt_game_at_loading_chapter4";

			// Token: 0x04002B38 RID: 11064
			public const string EVT_GAME_AT_LOADING_CHAPTER5 = "evt_game_at_loading_chapter5";

			// Token: 0x04002B39 RID: 11065
			public const string EVT_GAME_AT_CHAPTER_TITLES = "evt_game_at_chapter_titles";

			// Token: 0x04002B3A RID: 11066
			public const string EVT_GAME_AT_GAMEPLAY = "evt_game_at_gameplay";

			// Token: 0x04002B3B RID: 11067
			public const string EVT_GAME_AT_NEW_OBJECTIVE = "evt_game_at_new_objective";

			// Token: 0x04002B3C RID: 11068
			public const string EVT_GAME_AT_PAUSED = "evt_game_at_paused";

			// Token: 0x04002B3D RID: 11069
			public const string EVT_GAME_AT_RESUME = "evt_game_at_resume";

			// Token: 0x04002B3E RID: 11070
			public const string EVT_GAME_AT_QUIT_PROMPT = "evt_game_at_quit_prompt";

			// Token: 0x04002B3F RID: 11071
			public const string EVT_SAVE_PUNCHIN = "evt_save_punchin";

			// Token: 0x04002B40 RID: 11072
			public const string EVT_DEATHTUNNEL_START = "evt_deathtunnel_start";

			// Token: 0x04002B41 RID: 11073
			public const string EVT_DEATHTUNNEL_STOP = "evt_deathtunnel_stop";

			// Token: 0x04002B42 RID: 11074
			public const string EVT_HORROR_VISION_START = "evt_horror_vision_start";

			// Token: 0x04002B43 RID: 11075
			public const string EVT_HORROR_VISION_STOP = "evt_horror_vision_stop";

			// Token: 0x04002B44 RID: 11076
			public const string EVT_MIRACLE_STATION_ENTER = "evt_miracle_station_enter";

			// Token: 0x04002B45 RID: 11077
			public const string EVT_MIRACLE_STATION_EXIT = "evt_miracle_station_exit";

			// Token: 0x04002B46 RID: 11078
			public const string EVT_VALVE_DRAINS_INK = "evt_valve_drains_ink";

			// Token: 0x04002B47 RID: 11079
			public const string EVT_PLAYER_DEAD = "evt_player_dead";

			// Token: 0x04002B48 RID: 11080
			public const string EVT_PLAYER_RESPAWNED = "evt_player_respawned";

			// Token: 0x04002B49 RID: 11081
			public const string EVT_SCREEN_SHAKE_START = "evt_screen_shake_start";

			// Token: 0x04002B4A RID: 11082
			public const string EVT_SCREEN_SHAKE_STOP = "evt_screen_shake_stop";

			// Token: 0x04002B4B RID: 11083
			public const string EVT_INK_MACHINE_PASSBY_START = "evt_ink_machine_passby_start";

			// Token: 0x04002B4C RID: 11084
			public const string EVT_SEEING_TOOL_ON = "evt_seeing_tool_on";

			// Token: 0x04002B4D RID: 11085
			public const string EVT_SEEING_TOOL_OFF = "evt_seeing_tool_off";

			// Token: 0x04002B4E RID: 11086
			public const string EVT_NEW_TEST = "evt_new_test";

			// Token: 0x04002B4F RID: 11087
			public const string EVT_BATTERY_PACK_ON = "evt_battery_pack_on";

			// Token: 0x04002B50 RID: 11088
			public const string EVT_INK_MACHINE_REVEAL_START = "evt_ink_machine_reveal_start";

			// Token: 0x04002B51 RID: 11089
			public const string EVT_INK_MACHINE_REVEAL_STOP = "evt_ink_machine_reveal_stop";

			// Token: 0x04002B52 RID: 11090
			public const string EVT_INK_PRESSURE_RESTORED = "evt_ink_pressure_restored";

			// Token: 0x04002B53 RID: 11091
			public const string EVT_MAIN_POWER_SWITCH_ACTIVATED = "evt_main_power_switch_activated";

			// Token: 0x04002B54 RID: 11092
			public const string EVT_MAIN_POWER_MIX_RESET = "evt_main_power_mix_reset";

			// Token: 0x04002B55 RID: 11093
			public const string EVT_BENDY_APPEARS = "evt_bendy_appears";

			// Token: 0x04002B56 RID: 11094
			public const string EVT_FLOOR_CAVES_IN = "evt_floor_caves_in";

			// Token: 0x04002B57 RID: 11095
			public const string EVT_STAIRWELL_VALVE1 = "evt_stairwell_valve1";

			// Token: 0x04002B58 RID: 11096
			public const string EVT_STAIRWELL_VALVE2 = "evt_stairwell_valve2";

			// Token: 0x04002B59 RID: 11097
			public const string EVT_STAIRWELL_VALVE3 = "evt_stairwell_valve3";

			// Token: 0x04002B5A RID: 11098
			public const string EVT_BENDY_FINALE_SCARE = "evt_bendy_finale_scare";

			// Token: 0x04002B5B RID: 11099
			public const string EVT_CH1_SAVE_POINT_01 = "evt_CH1_save_point_01";

			// Token: 0x04002B5C RID: 11100
			public const string EVT_CH1_SAVE_POINT_03 = "evt_CH1_save_point_03";

			// Token: 0x04002B5D RID: 11101
			public const string EVT_CH1_SAVE_POINT_04 = "evt_CH1_save_point_04";

			// Token: 0x04002B5E RID: 11102
			public const string EVT_CH1_SAVE_POINT_05 = "evt_CH1_save_point_05";

			// Token: 0x04002B5F RID: 11103
			public const string EVT_CH1_SAVE_POINT_06 = "evt_CH1_save_point_06";

			// Token: 0x04002B60 RID: 11104
			public const string EVT_MAIN_ROOM_ENTER = "evt_main_room_enter";

			// Token: 0x04002B61 RID: 11105
			public const string EVT_MAIN_ROOM_EXIT = "evt_main_room_exit";

			// Token: 0x04002B62 RID: 11106
			public const string EVT_DREAMS_HALLWAY_ENTER = "evt_dreams_hallway_enter";

			// Token: 0x04002B63 RID: 11107
			public const string EVT_DREAMS_HALLWAY_EXIT = "evt_dreams_hallway_exit";

			// Token: 0x04002B64 RID: 11108
			public const string EVT_LARGE_HALLWAY_ENTER = "evt_large_hallway_enter";

			// Token: 0x04002B65 RID: 11109
			public const string EVT_LARGE_HALLWAY_EXIT = "evt_large_hallway_exit";

			// Token: 0x04002B66 RID: 11110
			public const string EVT_BORIS_ROOM_ENTER = "evt_boris_room_enter";

			// Token: 0x04002B67 RID: 11111
			public const string EVT_BORIS_ROOM_EXIT = "evt_boris_room_exit";

			// Token: 0x04002B68 RID: 11112
			public const string EVT_BORIS_RUMBLETRAP_ENTER = "evt_boris_rumbletrap_enter";

			// Token: 0x04002B69 RID: 11113
			public const string EVT_BORIS_RUMBLETRAP_EXIT = "evt_boris_rumbletrap_exit";

			// Token: 0x04002B6A RID: 11114
			public const string EVT_POWER_ROOM_ENTER = "evt_power_room_enter";

			// Token: 0x04002B6B RID: 11115
			public const string EVT_POWER_ROOM_EXIT = "evt_power_room_exit";

			// Token: 0x04002B6C RID: 11116
			public const string EVT_THEATRE_ENTER = "evt_theatre_enter";

			// Token: 0x04002B6D RID: 11117
			public const string EVT_THEATRE_EXIT = "evt_theatre_exit";

			// Token: 0x04002B6E RID: 11118
			public const string EVT_THEATRE_MIXTRAP_INK_ENTER = "evt_theatre_mixtrap_ink_enter";

			// Token: 0x04002B6F RID: 11119
			public const string EVT_THEATRE_MIXTRAP_INK_EXIT = "evt_theatre_mixtrap_ink_exit";

			// Token: 0x04002B70 RID: 11120
			public const string EVT_INK_BARN_ENTER = "evt_ink_barn_enter";

			// Token: 0x04002B71 RID: 11121
			public const string EVT_INK_BARN_EXIT = "evt_ink_barn_exit";

			// Token: 0x04002B72 RID: 11122
			public const string EVT_ART_ROOM_ENTER = "evt_art_room_enter";

			// Token: 0x04002B73 RID: 11123
			public const string EVT_ART_ROOM_EXIT = "evt_art_room_exit";

			// Token: 0x04002B74 RID: 11124
			public const string EVT_ART_BATH_ENTER = "evt_art_bath_enter";

			// Token: 0x04002B75 RID: 11125
			public const string EVT_ART_BATH_EXIT = "evt_art_bath_exit";

			// Token: 0x04002B76 RID: 11126
			public const string EVT_BREAK_ROOM_ENTER = "evt_break_room_enter";

			// Token: 0x04002B77 RID: 11127
			public const string EVT_BREAK_ROOM_EXIT = "evt_break_room_exit";

			// Token: 0x04002B78 RID: 11128
			public const string EVT_STAIRWELL_ENTER = "evt_stairwell_enter";

			// Token: 0x04002B79 RID: 11129
			public const string EVT_BASEMENT_FINAL_ENTER = "evt_basement_final_enter";

			// Token: 0x04002B7A RID: 11130
			public const string EVT_BASEMENT_FINAL_EXIT = "evt_basement_final_exit";

			// Token: 0x04002B7B RID: 11131
			public const string EVT_ENTER_MUSIC_DEPARTMENT = "evt_enter_music_department";

			// Token: 0x04002B7C RID: 11132
			public const string EVT_CH2_DEPT_INK_BLOB_FALL = "evt_ch2_dept_ink_blob_fall";

			// Token: 0x04002B7D RID: 11133
			public const string EVT_CH2_DEPT_INK_BLOB_LAND = "evt_ch2_dept_ink_blob_land";

			// Token: 0x04002B7E RID: 11134
			public const string EVT_OFFICE_STAIRS_INK_DRAINED = "evt_office_stairs_ink_drained";

			// Token: 0x04002B7F RID: 11135
			public const string EVT_OFFICE_DOOR_INK_DRAINED = "evt_office_door_ink_drained";

			// Token: 0x04002B80 RID: 11136
			public const string EVT_OFFICE_LEVER_THROWN = "evt_office_lever_thrown";

			// Token: 0x04002B81 RID: 11137
			public const string EVT_SAMMY_KNOCKS_OUT_PLAYER = "evt_sammy_knocks_out_player";

			// Token: 0x04002B82 RID: 11138
			public const string EVT_SEWER_PUZZLE_WINCH_UP_START = "evt_sewer_puzzle_winch_up_start";

			// Token: 0x04002B83 RID: 11139
			public const string EVT_SEWER_PUZZLE_WINCH_DOWN = "evt_sewer_puzzle_winch_down";

			// Token: 0x04002B84 RID: 11140
			public const string EVT_CH2_SAVE_POINT_01 = "evt_CH2_save_point_01";

			// Token: 0x04002B85 RID: 11141
			public const string EVT_CH2_SAVE_POINT_02 = "evt_CH2_save_point_02";

			// Token: 0x04002B86 RID: 11142
			public const string EVT_CH2_SAVE_POINT_03 = "evt_CH2_save_point_03";

			// Token: 0x04002B87 RID: 11143
			public const string EVT_CH2_SAVE_POINT_04 = "evt_CH2_save_point_04";

			// Token: 0x04002B88 RID: 11144
			public const string EVT_CH2_SAVE_POINT_05 = "evt_CH2_save_point_05";

			// Token: 0x04002B89 RID: 11145
			public const string EVT_CH2_SAVE_POINT_06 = "evt_CH2_save_point_06";

			// Token: 0x04002B8A RID: 11146
			public const string EVT_CH2_SAVE_POINT_07 = "evt_CH2_save_point_07";

			// Token: 0x04002B8B RID: 11147
			public const string EVT_CH2_SAVE_POINT_08 = "evt_CH2_save_point_08";

			// Token: 0x04002B8C RID: 11148
			public const string EVT_CH2_SAVE_POINT_09 = "evt_CH2_save_point_09";

			// Token: 0x04002B8D RID: 11149
			public const string EVT_CH2_SAVE_POINT_10 = "evt_CH2_save_point_10";

			// Token: 0x04002B8E RID: 11150
			public const string EVT_CH2_SAVE_POINT_11 = "evt_CH2_save_point_11";

			// Token: 0x04002B8F RID: 11151
			public const string EVT_CH2_SAVE_POINT_12 = "evt_CH2_save_point_12";

			// Token: 0x04002B90 RID: 11152
			public const string EVT_CH2_SAVE_POINT_13 = "evt_CH2_save_point_13";

			// Token: 0x04002B91 RID: 11153
			public const string EVT_CH2_OPENING_ENTER = "evt_ch2_opening_enter";

			// Token: 0x04002B92 RID: 11154
			public const string EVT_CH2_OPENING_EXIT = "evt_ch2_opening_exit";

			// Token: 0x04002B93 RID: 11155
			public const string EVT_CH2_OPENING_LOOPS_ENTER = "evt_ch2_opening_loops_enter";

			// Token: 0x04002B94 RID: 11156
			public const string EVT_CH2_OPENING_LOOPS_EXIT = "evt_ch2_opening_loops_exit";

			// Token: 0x04002B95 RID: 11157
			public const string EVT_SAMMYHALLWAY_ENTER = "evt_sammyhallway_enter";

			// Token: 0x04002B96 RID: 11158
			public const string EVT_SAMMYHALLWAY_EXIT = "evt_sammyhallway_exit";

			// Token: 0x04002B97 RID: 11159
			public const string EVT_MUSICDEPARTMENT_ENTER = "evt_musicdepartment_enter";

			// Token: 0x04002B98 RID: 11160
			public const string EVT_MUSICDEPARTMENT_EXIT = "evt_musicdepartment_exit";

			// Token: 0x04002B99 RID: 11161
			public const string EVT_MUSIC_INK_ENTER = "evt_music_ink_enter";

			// Token: 0x04002B9A RID: 11162
			public const string EVT_MUSIC_INK_EXIT = "evt_music_ink_exit";

			// Token: 0x04002B9B RID: 11163
			public const string EVT_RECORDINGSTUDIO_ENTER = "evt_recordingstudio_enter";

			// Token: 0x04002B9C RID: 11164
			public const string EVT_RECORDINGSTUDIO_EXIT = "evt_recordingstudio_exit";

			// Token: 0x04002B9D RID: 11165
			public const string EVT_RECORDINGSTUDIO_BALCONY_ENTER = "evt_recordingstudio_balcony_enter";

			// Token: 0x04002B9E RID: 11166
			public const string EVT_RECORDINGSTUDIO_BALCONY_EXIT = "evt_recordingstudio_balcony_exit";

			// Token: 0x04002B9F RID: 11167
			public const string EVT_SECRETROOM_ENTER = "evt_secretroom_enter";

			// Token: 0x04002BA0 RID: 11168
			public const string EVT_SECRETROOM_EXIT = "evt_secretroom_exit";

			// Token: 0x04002BA1 RID: 11169
			public const string EVT_OFFICE_INK_ENTER = "evt_office_ink_enter";

			// Token: 0x04002BA2 RID: 11170
			public const string EVT_OFFICE_INK_EXIT = "evt_office_ink_exit";

			// Token: 0x04002BA3 RID: 11171
			public const string EVT_SAMMYOFFICE_ENTER_FROM_DEPT = "evt_sammyoffice_enter_from_dept";

			// Token: 0x04002BA4 RID: 11172
			public const string EVT_SAMMYOFFICE_EXIT_TO_DEPT = "evt_sammyoffice_exit_to_dept";

			// Token: 0x04002BA5 RID: 11173
			public const string EVT_SAMMYOFFICE_ENTER_FROM_INFIRMARY = "evt_sammyoffice_enter_from_infirmary";

			// Token: 0x04002BA6 RID: 11174
			public const string EVT_SAMMYOFFICE_EXIT_TO_INFIRMARY = "evt_sammyoffice_exit_to_infirmary";

			// Token: 0x04002BA7 RID: 11175
			public const string EVT_INFIRMARY_ENTER = "evt_infirmary_enter";

			// Token: 0x04002BA8 RID: 11176
			public const string EVT_INFIRMARY_EXIT = "evt_infirmary_exit";

			// Token: 0x04002BA9 RID: 11177
			public const string EVT_SEWERS_ENTER = "evt_sewers_enter";

			// Token: 0x04002BAA RID: 11178
			public const string EVT_SEWERS_EXIT = "evt_sewers_exit";

			// Token: 0x04002BAB RID: 11179
			public const string EVT_MACHINEROOM_ENTER = "evt_machineroom_enter";

			// Token: 0x04002BAC RID: 11180
			public const string EVT_MACHINEROOM_EXIT = "evt_machineroom_exit";

			// Token: 0x04002BAD RID: 11181
			public const string EVT_SACRIFICE_ENTER = "evt_sacrifice_enter";

			// Token: 0x04002BAE RID: 11182
			public const string EVT_SACRIFICE_EXIT = "evt_sacrifice_exit";

			// Token: 0x04002BAF RID: 11183
			public const string EVT_BENDYCHASE_ENTER = "evt_bendychase_enter";

			// Token: 0x04002BB0 RID: 11184
			public const string EVT_BENDYCHASE_EXIT = "evt_bendychase_exit";

			// Token: 0x04002BB1 RID: 11185
			public const string EVT_BORISREVEAL_ENTER = "evt_borisreveal_enter";

			// Token: 0x04002BB2 RID: 11186
			public const string EVT_BORISREVEAL_EXIT = "evt_borisreveal_exit";

			// Token: 0x04002BB3 RID: 11187
			public const string EVT_SAFEHOUSE_CLOSED = "evt_safehouse_closed";

			// Token: 0x04002BB4 RID: 11188
			public const string EVT_DARKHALLWAY_CLOSED = "evt_darkhallway_closed";

			// Token: 0x04002BB5 RID: 11189
			public const string EVT_ACTIVATE_WORKSHOP_MECH_RIGHT = "evt_activate_workshop_mech_right";

			// Token: 0x04002BB6 RID: 11190
			public const string EVT_ACTIVATE_WORKSHOP_MECH_LEFT = "evt_activate_workshop_mech_left";

			// Token: 0x04002BB7 RID: 11191
			public const string EVT_TOYS_FOUND1 = "evt_toys_found1";

			// Token: 0x04002BB8 RID: 11192
			public const string EVT_TOYS_FOUND2 = "evt_toys_found2";

			// Token: 0x04002BB9 RID: 11193
			public const string EVT_TOYS_FOUND3 = "evt_toys_found3";

			// Token: 0x04002BBA RID: 11194
			public const string EVT_TOYS_FOUND4 = "evt_toys_found4";

			// Token: 0x04002BBB RID: 11195
			public const string EVT_ALICE_REVEAL_START = "evt_alice_reveal_start";

			// Token: 0x04002BBC RID: 11196
			public const string EVT_ALICE_REVEAL_COMPLETE = "evt_alice_reveal_complete";

			// Token: 0x04002BBD RID: 11197
			public const string EVT_ELEVATOR_START = "evt_elevator_start";

			// Token: 0x04002BBE RID: 11198
			public const string EVT_ELEVATOR_STOP = "evt_elevator_stop";

			// Token: 0x04002BBF RID: 11199
			public const string EVT_CH3_SECRET_FLOOD_EMPTY = "evt_ch3_secret_flood_empty";

			// Token: 0x04002BC0 RID: 11200
			public const string EVT_SAFEHOUSE_ENTER = "evt_safehouse_enter";

			// Token: 0x04002BC1 RID: 11201
			public const string EVT_SAFEHOUSE_EXIT = "evt_safehouse_exit";

			// Token: 0x04002BC2 RID: 11202
			public const string EVT_DARKHALLWAY_ENTER = "evt_darkhallway_enter";

			// Token: 0x04002BC3 RID: 11203
			public const string EVT_DARKHALLWAY_EXIT = "evt_darkhallway_exit";

			// Token: 0x04002BC4 RID: 11204
			public const string EVT_HEAVENLYTOYS_ENTER = "evt_heavenlytoys_enter";

			// Token: 0x04002BC5 RID: 11205
			public const string EVT_HEAVENLYTOYS_EXIT = "evt_heavenlytoys_exit";

			// Token: 0x04002BC6 RID: 11206
			public const string EVT_WORKSHOP_ENTER = "evt_workshop_enter";

			// Token: 0x04002BC7 RID: 11207
			public const string EVT_WORKSHOP_EXIT = "evt_workshop_exit";

			// Token: 0x04002BC8 RID: 11208
			public const string EVT_ALICEREVEAL_ENTER = "evt_alicereveal_enter";

			// Token: 0x04002BC9 RID: 11209
			public const string EVT_ALICEREVEAL_EXIT = "evt_alicereveal_exit";

			// Token: 0x04002BCA RID: 11210
			public const string EVT_CHOICES_ENTER = "evt_choices_enter";

			// Token: 0x04002BCB RID: 11211
			public const string EVT_CHOICES_EXIT = "evt_choices_exit";

			// Token: 0x04002BCC RID: 11212
			public const string EVT_CHOICES_DEVIL_ENTER = "evt_choices_devil_enter";

			// Token: 0x04002BCD RID: 11213
			public const string EVT_CHOICES_DEVIL_EXIT = "evt_choices_devil_exit";

			// Token: 0x04002BCE RID: 11214
			public const string EVT_CHOICES_ANGEL_ENTER = "evt_choices_angel_enter";

			// Token: 0x04002BCF RID: 11215
			public const string EVT_CHOICES_ANGEL_EXIT = "evt_choices_angel_exit";

			// Token: 0x04002BD0 RID: 11216
			public const string EVT_FROM_CHOICES_TO_LIFT = "evt_from_choices_to_lift";

			// Token: 0x04002BD1 RID: 11217
			public const string EVT_FROM_LIFT_TO_CHOICES = "evt_from_lift_to_choices";

			// Token: 0x04002BD2 RID: 11218
			public const string EVT_LIFT_HALLWAYS_ENTER = "evt_lift_hallways_enter";

			// Token: 0x04002BD3 RID: 11219
			public const string EVT_LIFT_HALLWAYS_EXIT = "evt_lift_hallways_exit";

			// Token: 0x04002BD4 RID: 11220
			public const string EVT_TRAILERROOM_ENTER = "evt_trailerroom_enter";

			// Token: 0x04002BD5 RID: 11221
			public const string EVT_TRAILERROOM_EXIT = "evt_trailerroom_exit";

			// Token: 0x04002BD6 RID: 11222
			public const string EVT_LIFT_MAIN1_ENTER = "evt_lift_main1_enter";

			// Token: 0x04002BD7 RID: 11223
			public const string EVT_LIFT_MAIN1_EXIT = "evt_lift_main1_exit";

			// Token: 0x04002BD8 RID: 11224
			public const string EVT_FLOOR2_ENTER = "evt_floor2_enter";

			// Token: 0x04002BD9 RID: 11225
			public const string EVT_FLOOR2_EXIT = "evt_floor2_exit";

			// Token: 0x04002BDA RID: 11226
			public const string EVT_FLOOR3_ENTER = "evt_floor3_enter";

			// Token: 0x04002BDB RID: 11227
			public const string EVT_FLOOR3_EXIT = "evt_floor3_exit";

			// Token: 0x04002BDC RID: 11228
			public const string EVT_FLOOR3_LAB1_ENTER = "evt_floor3_lab1_enter";

			// Token: 0x04002BDD RID: 11229
			public const string EVT_FLOOR3_LAB1_EXIT = "evt_floor3_lab1_exit";

			// Token: 0x04002BDE RID: 11230
			public const string EVT_FLOOR3_LAB2_ENTER = "evt_floor3_lab2_enter";

			// Token: 0x04002BDF RID: 11231
			public const string EVT_FLOOR3_LAB2_EXIT = "evt_floor3_lab2_exit";

			// Token: 0x04002BE0 RID: 11232
			public const string EVT_FLOOR4_ENTER = "evt_floor4_enter";

			// Token: 0x04002BE1 RID: 11233
			public const string EVT_FLOOR4_EXIT = "evt_floor4_exit";

			// Token: 0x04002BE2 RID: 11234
			public const string EVT_FLOOR4_HALL_ENTER = "evt_floor4_hall_enter";

			// Token: 0x04002BE3 RID: 11235
			public const string EVT_FLOOR4_HALL_EXIT = "evt_floor4_hall_exit";

			// Token: 0x04002BE4 RID: 11236
			public const string EVT_ALICESLAIR_ENTER = "evt_aliceslair_enter";

			// Token: 0x04002BE5 RID: 11237
			public const string EVT_ALICESLAIR_EXIT = "evt_aliceslair_exit";

			// Token: 0x04002BE6 RID: 11238
			public const string EVT_TORTUREROOM_ENTER = "evt_tortureroom_enter";

			// Token: 0x04002BE7 RID: 11239
			public const string EVT_TORTUREROOM_EXIT = "evt_tortureroom_exit";

			// Token: 0x04002BE8 RID: 11240
			public const string EVT_FLOOR5_COMMON_ENTER = "evt_floor5_common_enter";

			// Token: 0x04002BE9 RID: 11241
			public const string EVT_FLOOR5_COMMON_EXIT = "evt_floor5_common_exit";

			// Token: 0x04002BEA RID: 11242
			public const string EVT_FLOOR5_ENTER = "evt_floor5_enter";

			// Token: 0x04002BEB RID: 11243
			public const string EVT_FLOOR5_EXIT = "evt_floor5_exit";

			// Token: 0x04002BEC RID: 11244
			public const string EVT_INKFLOOD_ENTER = "evt_inkflood_enter";

			// Token: 0x04002BED RID: 11245
			public const string EVT_INKFLOOD_EXIT = "evt_inkflood_exit";

			// Token: 0x04002BEE RID: 11246
			public const string EVT_LABYRINTH_ENTER = "evt_labyrinth_enter";

			// Token: 0x04002BEF RID: 11247
			public const string EVT_LABYRINTH_EXIT = "evt_labyrinth_exit";

			// Token: 0x04002BF0 RID: 11248
			public const string EVT_LIFTSHAFT_ENTER = "evt_liftshaft_enter";

			// Token: 0x04002BF1 RID: 11249
			public const string EVT_LIFTSHAFT_EXIT = "evt_liftshaft_exit";

			// Token: 0x04002BF2 RID: 11250
			public const string EVT_CH3STAIRWELLS_ENTER = "evt_ch3stairwells_enter";

			// Token: 0x04002BF3 RID: 11251
			public const string EVT_CH3STAIRWELLS_EXIT = "evt_ch3stairwells_exit";

			// Token: 0x04002BF4 RID: 11252
			public const string EVT_CH3STAIRWELLS_EXIT_TO_LEVEL9 = "evt_ch3stairwells_exit_to_level9";

			// Token: 0x04002BF5 RID: 11253
			public const string EVT_CH3STAIRWELLS_ENTER_FROM_LEVEL9 = "evt_ch3stairwells_enter_from_level9";

			// Token: 0x04002BF6 RID: 11254
			public const string EVT_FINALE_ENTER = "evt_finale_enter";

			// Token: 0x04002BF7 RID: 11255
			public const string EVT_FINALE_EXIT = "evt_finale_exit";

			// Token: 0x04002BF8 RID: 11256
			public const string EVT_CH3_ARRIVE_AT_FLOOR_1 = "evt_ch3_arrive_at_floor_1";

			// Token: 0x04002BF9 RID: 11257
			public const string EVT_CH3_ARRIVE_AT_FLOOR_2 = "evt_ch3_arrive_at_floor_2";

			// Token: 0x04002BFA RID: 11258
			public const string EVT_CH3_ARRIVE_AT_FLOOR_3 = "evt_ch3_arrive_at_floor_3";

			// Token: 0x04002BFB RID: 11259
			public const string EVT_CH3_ARRIVE_AT_FLOOR_4 = "evt_ch3_arrive_at_floor_4";

			// Token: 0x04002BFC RID: 11260
			public const string EVT_CH3_ARRIVE_AT_FLOOR_5 = "evt_ch3_arrive_at_floor_5";

			// Token: 0x04002BFD RID: 11261
			public const string EVT_CH3_SAVE_POINT_01 = "evt_CH3_save_point_01";

			// Token: 0x04002BFE RID: 11262
			public const string EVT_CH3_SAVE_POINT_02 = "evt_CH3_save_point_02";

			// Token: 0x04002BFF RID: 11263
			public const string EVT_CH3_SAVE_POINT_03 = "evt_CH3_save_point_03";

			// Token: 0x04002C00 RID: 11264
			public const string EVT_CH3_SAVE_POINT_04 = "evt_CH3_save_point_04";

			// Token: 0x04002C01 RID: 11265
			public const string EVT_CH3_SAVE_POINT_05 = "evt_CH3_save_point_05";

			// Token: 0x04002C02 RID: 11266
			public const string EVT_CH3_SAVE_POINT_06 = "evt_CH3_save_point_06";

			// Token: 0x04002C03 RID: 11267
			public const string EVT_CH3_SAVE_POINT_07 = "evt_CH3_save_point_07";

			// Token: 0x04002C04 RID: 11268
			public const string EVT_CH3_SAVE_POINT_08 = "evt_CH3_save_point_08";

			// Token: 0x04002C05 RID: 11269
			public const string EVT_CH3_SAVE_POINT_09 = "evt_CH3_save_point_09";

			// Token: 0x04002C06 RID: 11270
			public const string EVT_CH3_SAVE_POINT_10 = "evt_CH3_save_point_10";

			// Token: 0x04002C07 RID: 11271
			public const string EVT_CH3_SAVE_POINT_11 = "evt_CH3_save_point_11";

			// Token: 0x04002C08 RID: 11272
			public const string EVT_CH3_SAVE_POINT_12 = "evt_CH3_save_point_12";

			// Token: 0x04002C09 RID: 11273
			public const string EVT_CH3_SAVE_POINT_13 = "evt_CH3_save_point_13";

			// Token: 0x04002C0A RID: 11274
			public const string EVT_PLAYER_HIT_BY_BORIS = "evt_player_hit_by_boris";

			// Token: 0x04002C0B RID: 11275
			public const string EVT_BORIS_DEATH_MELT = "evt_boris_death_melt";

			// Token: 0x04002C0C RID: 11276
			public const string EVT_BERT_BOSS_STARTUP = "evt_bert_boss_startup";

			// Token: 0x04002C0D RID: 11277
			public const string EVT_BERT_BOSS_HEAD_REVEAL = "evt_bert_boss_head_reveal";

			// Token: 0x04002C0E RID: 11278
			public const string EVT_BERT_HUB_TURN_START = "evt_bert_hub_turn_start";

			// Token: 0x04002C0F RID: 11279
			public const string EVT_BERT_HUB_TURN_STOP = "evt_bert_hub_turn_stop";

			// Token: 0x04002C10 RID: 11280
			public const string EVT_BERT_ARMS_TIRED = "evt_bert_arms_tired";

			// Token: 0x04002C11 RID: 11281
			public const string EVT_BERT_ARMS_RESTORED = "evt_bert_arms_restored";

			// Token: 0x04002C12 RID: 11282
			public const string EVT_BERT_ARM1_DEAD = "evt_bert_arm1_dead";

			// Token: 0x04002C13 RID: 11283
			public const string EVT_BERT_ARM2_DEAD = "evt_bert_arm2_dead";

			// Token: 0x04002C14 RID: 11284
			public const string EVT_BERT_ARM3_DEAD = "evt_bert_arm3_dead";

			// Token: 0x04002C15 RID: 11285
			public const string EVT_BERT_ARM4_DEAD = "evt_bert_arm4_dead";

			// Token: 0x04002C16 RID: 11286
			public const string EVT_BERT_BOSS_FINAL_FREAKOUT = "evt_bert_boss_final_freakout";

			// Token: 0x04002C17 RID: 11287
			public const string EVT_BERT_BOSS_DEFEATED = "evt_bert_boss_defeated";

			// Token: 0x04002C18 RID: 11288
			public const string EVT_STARTINGLIFT_SIDEROOM_OPENED = "evt_startinglift_sideroom_opened";

			// Token: 0x04002C19 RID: 11289
			public const string EVT_ACCOUNTING_EXIT_DOOR_OPEN = "evt_accounting_exit_door_open";

			// Token: 0x04002C1A RID: 11290
			public const string EVT_STAGE_ENTRY_DOOR_OPEN = "evt_stage_entry_door_open";

			// Token: 0x04002C1B RID: 11291
			public const string EVT_SWOLEN_SEARCHER_APPEARS = "evt_swolen_searcher_appears";

			// Token: 0x04002C1C RID: 11292
			public const string EVT_INK_COLLECTED = "evt_ink_collected";

			// Token: 0x04002C1D RID: 11293
			public const string EVT_INK_DEPOSITED = "evt_ink_deposited";

			// Token: 0x04002C1E RID: 11294
			public const string EVT_INK_PIPE_OPENS = "evt_ink_pipe_opens";

			// Token: 0x04002C1F RID: 11295
			public const string EVT_HEADBANGER_MIXTRAP_ENTER = "evt_headbanger_mixtrap_enter";

			// Token: 0x04002C20 RID: 11296
			public const string EVT_HEADBANGER_MIXTRAP_EXIT = "evt_headbanger_mixtrap_exit";

			// Token: 0x04002C21 RID: 11297
			public const string EVT_WAREHOUSE_DOOR_OPEN = "evt_warehouse_door_open";

			// Token: 0x04002C22 RID: 11298
			public const string EVT_HAUNTED_HOUSE_START = "evt_haunted_house_start";

			// Token: 0x04002C23 RID: 11299
			public const string EVT_HAUNTED_HOUSE_CART_START = "evt_haunted_house_cart_start";

			// Token: 0x04002C24 RID: 11300
			public const string EVT_HAUNTED_HOUSE_CART_STOP = "evt_haunted_house_cart_stop";

			// Token: 0x04002C25 RID: 11301
			public const string EVT_HAUNTED_HOUSE_CART_SMASHED = "evt_haunted_house_cart_smashed";

			// Token: 0x04002C26 RID: 11302
			public const string EVT_DEFAULT_ENV_ENTER = "evt_default_env_enter";

			// Token: 0x04002C27 RID: 11303
			public const string EVT_DEFAULT_ENV_EXIT = "evt_default_env_exit";

			// Token: 0x04002C28 RID: 11304
			public const string EVT_STARTING_LIFT_ENTER = "evt_starting_lift_enter";

			// Token: 0x04002C29 RID: 11305
			public const string EVT_STARTING_LIFT_EXIT = "evt_starting_lift_exit";

			// Token: 0x04002C2A RID: 11306
			public const string EVT_ARCHIVES_ROOM_ENTER = "evt_archives_room_enter";

			// Token: 0x04002C2B RID: 11307
			public const string EVT_ARCHIVES_ROOM_EXIT = "evt_archives_room_exit";

			// Token: 0x04002C2C RID: 11308
			public const string EVT_BRIDGE_ENTER = "evt_bridge_enter";

			// Token: 0x04002C2D RID: 11309
			public const string EVT_BRIDGE_EXIT = "evt_bridge_exit";

			// Token: 0x04002C2E RID: 11310
			public const string EVT_SPIRAL_STAIRS_ENTER = "evt_spiral_stairs_enter";

			// Token: 0x04002C2F RID: 11311
			public const string EVT_SPIRAL_STAIRS_EXIT = "evt_spiral_stairs_exit";

			// Token: 0x04002C30 RID: 11312
			public const string EVT_HOLDING_ROOM_ENTER = "evt_holding_room_enter";

			// Token: 0x04002C31 RID: 11313
			public const string EVT_HOLDING_ROOM_EXIT = "evt_holding_room_exit";

			// Token: 0x04002C32 RID: 11314
			public const string EVT_HOLDING_ROOM2_ENTER = "evt_holding_room2_enter";

			// Token: 0x04002C33 RID: 11315
			public const string EVT_HOLDING_ROOM2_EXIT = "evt_holding_room2_exit";

			// Token: 0x04002C34 RID: 11316
			public const string EVT_VENT_ENTER = "evt_vent_enter";

			// Token: 0x04002C35 RID: 11317
			public const string EVT_VENT_EXIT = "evt_vent_exit";

			// Token: 0x04002C36 RID: 11318
			public const string EVT_MAP_ROOM_ENTER = "evt_map_room_enter";

			// Token: 0x04002C37 RID: 11319
			public const string EVT_MAP_ROOM_EXIT = "evt_map_room_exit";

			// Token: 0x04002C38 RID: 11320
			public const string EVT_WAREHOUSE_ENTER = "evt_warehouse_enter";

			// Token: 0x04002C39 RID: 11321
			public const string EVT_WAREHOUSE_EXIT = "evt_warehouse_exit";

			// Token: 0x04002C3A RID: 11322
			public const string EVT_RESEARCH_AND_DESIGN_UPPER_ENTER = "evt_research_and_design_upper_enter";

			// Token: 0x04002C3B RID: 11323
			public const string EVT_RESEARCH_AND_DESIGN_UPPER_EXIT = "evt_research_and_design_upper_exit";

			// Token: 0x04002C3C RID: 11324
			public const string EVT_RESEARCH_AND_DESIGN_MIX_ENTER = "evt_research_and_design_mix_enter";

			// Token: 0x04002C3D RID: 11325
			public const string EVT_RESEARCH_AND_DESIGN_MIX_EXIT = "evt_research_and_design_mix_exit";

			// Token: 0x04002C3E RID: 11326
			public const string EVT_RESEARCH_AND_DESIGN_LOWER_ENTER = "evt_research_and_design_lower_enter";

			// Token: 0x04002C3F RID: 11327
			public const string EVT_RESEARCH_AND_DESIGN_LOWER_EXIT = "evt_research_and_design_lower_exit";

			// Token: 0x04002C40 RID: 11328
			public const string EVT_RIDE_STORAGE_ENTER = "evt_ride_storage_enter";

			// Token: 0x04002C41 RID: 11329
			public const string EVT_RIDE_STORAGE_EXIT = "evt_ride_storage_exit";

			// Token: 0x04002C42 RID: 11330
			public const string EVT_MAINTENANCE_ENTER = "evt_maintenance_enter";

			// Token: 0x04002C43 RID: 11331
			public const string EVT_MAINTENANCE_EXIT = "evt_maintenance_exit";

			// Token: 0x04002C44 RID: 11332
			public const string EVT_MAINTENANCE_UPPER_ENTER = "evt_maintenance_upper_enter";

			// Token: 0x04002C45 RID: 11333
			public const string EVT_MAINTENANCE_UPPER_EXIT = "evt_maintenance_upper_exit";

			// Token: 0x04002C46 RID: 11334
			public const string EVT_HAUNTED_HOUSE_ENTER = "evt_haunted_house_enter";

			// Token: 0x04002C47 RID: 11335
			public const string EVT_HAUNTED_HOUSE_EXIT = "evt_haunted_house_exit";

			// Token: 0x04002C48 RID: 11336
			public const string EVT_BALLROOM_ENTER = "evt_ballroom_enter";

			// Token: 0x04002C49 RID: 11337
			public const string EVT_BALLROOM_EXIT = "evt_ballroom_exit";

			// Token: 0x04002C4A RID: 11338
			public const string EVT_CH4_SAVE_POINT_01 = "evt_CH4_save_point_01";

			// Token: 0x04002C4B RID: 11339
			public const string EVT_CH4_SAVE_POINT_02 = "evt_CH4_save_point_02";

			// Token: 0x04002C4C RID: 11340
			public const string EVT_CH4_SAVE_POINT_03 = "evt_CH4_save_point_03";

			// Token: 0x04002C4D RID: 11341
			public const string EVT_CH4_SAVE_POINT_04 = "evt_CH4_save_point_04";

			// Token: 0x04002C4E RID: 11342
			public const string EVT_CH4_SAVE_POINT_05 = "evt_CH4_save_point_05";

			// Token: 0x04002C4F RID: 11343
			public const string EVT_CH4_SAVE_POINT_06 = "evt_CH4_save_point_06";

			// Token: 0x04002C50 RID: 11344
			public const string EVT_CH4_SAVE_POINT_07 = "evt_CH4_save_point_07";

			// Token: 0x04002C51 RID: 11345
			public const string EVT_CH4_SAVE_POINT_08 = "evt_CH4_save_point_08";

			// Token: 0x04002C52 RID: 11346
			public const string EVT_CH4_SAVE_POINT_09 = "evt_CH4_save_point_09";

			// Token: 0x04002C53 RID: 11347
			public const string EVT_CH4_SAVE_POINT_10 = "evt_CH4_save_point_10";

			// Token: 0x04002C54 RID: 11348
			public const string EVT_CH4_SAVE_POINT_11 = "evt_CH4_save_point_11";

			// Token: 0x04002C55 RID: 11349
			public const string EVT_CH4_SAVE_POINT_12 = "evt_CH4_save_point_12";

			// Token: 0x04002C56 RID: 11350
			public const string EVT_CH4_SAVE_POINT_13 = "evt_CH4_save_point_13";

			// Token: 0x04002C57 RID: 11351
			public const string EVT_CH4_SAVE_POINT_14 = "evt_CH4_save_point_14";

			// Token: 0x04002C58 RID: 11352
			public const string EVT_CH4_SAVE_POINT_15 = "evt_CH4_save_point_15";

			// Token: 0x04002C59 RID: 11353
			public const string EVT_CH5_SCENE06_COMPLETE = "evt_ch5_scene06_complete";

			// Token: 0x04002C5A RID: 11354
			public const string EVT_CH5_SCENE07_COMPLETE = "evt_ch5_scene07_complete";

			// Token: 0x04002C5B RID: 11355
			public const string EVT_CH5_SEEING_TOOL_ACTIVE = "evt_ch5_seeing_tool_active";

			// Token: 0x04002C5C RID: 11356
			public const string EVT_CH5_BOAT_IN_DISTANCE = "evt_ch5_boat_in_distance";

			// Token: 0x04002C5D RID: 11357
			public const string EVT_CHUTE_BRAKE_ACTIVE = "evt_chute_brake_active";

			// Token: 0x04002C5E RID: 11358
			public const string EVT_BOAT_CHUTE_SLIDE1 = "evt_boat_chute_slide1";

			// Token: 0x04002C5F RID: 11359
			public const string EVT_BOAT_CHUTE_SLIDE2 = "evt_boat_chute_slide2";

			// Token: 0x04002C60 RID: 11360
			public const string EVT_CH5_ABYSS_FALL = "evt_ch5_abyss_fall";

			// Token: 0x04002C61 RID: 11361
			public const string EVT_CH5_JOEY_OFFICE_HIDING = "evt_ch5_joey_office_hiding";

			// Token: 0x04002C62 RID: 11362
			public const string EVT_CH5_PUZZLE_PIECE_ADDED = "evt_ch5_puzzle_piece_added";

			// Token: 0x04002C63 RID: 11363
			public const string EVT_FILM_VAULT_DOOR_CLEARED = "evt_film_vault_door_cleared";

			// Token: 0x04002C64 RID: 11364
			public const string EVT_CH5_JOEY_SPEAKS = "evt_ch5_joey_speaks";

			// Token: 0x04002C65 RID: 11365
			public const string EVT_CH5_JOEY_KITCHEN_EXIT = "evt_ch5_joey_kitchen_exit";

			// Token: 0x04002C66 RID: 11366
			public const string EVT_CH5_JOEY_KETCHEN_RESUME = "evt_ch5_joey_ketchen_resume";

			// Token: 0x04002C67 RID: 11367
			public const string EVT_CH5_SAFEHOUSE_ENTER = "evt_ch5_safehouse_enter";

			// Token: 0x04002C68 RID: 11368
			public const string EVT_CH5_SAFEHOUSE_EXIT = "evt_ch5_safehouse_exit";

			// Token: 0x04002C69 RID: 11369
			public const string EVT_CH5_CAVES_ENTER = "evt_ch5_caves_enter";

			// Token: 0x04002C6A RID: 11370
			public const string EVT_CH5_CAVES_EXIT = "evt_ch5_caves_exit";

			// Token: 0x04002C6B RID: 11371
			public const string EVT_CH5_DOCK_ENTER = "evt_ch5_dock_enter";

			// Token: 0x04002C6C RID: 11372
			public const string EVT_CH5_DOCK_EXIT = "evt_ch5_dock_exit";

			// Token: 0x04002C6D RID: 11373
			public const string EVT_CH5_TUNNELS_ENTER = "evt_ch5_tunnels_enter";

			// Token: 0x04002C6E RID: 11374
			public const string EVT_CH5_TUNNELS_EXIT = "evt_ch5_tunnels_exit";

			// Token: 0x04002C6F RID: 11375
			public const string EVT_CH5_LOST_HARBOUR_ENTER = "evt_ch5_lost_harbour_enter";

			// Token: 0x04002C70 RID: 11376
			public const string EVT_CH5_LOST_HARBOUR_EXIT = "evt_ch5_lost_harbour_exit";

			// Token: 0x04002C71 RID: 11377
			public const string EVT_CH5_ABYSS_ENTER = "evt_ch5_abyss_enter";

			// Token: 0x04002C72 RID: 11378
			public const string EVT_CH5_ABYSS_EXIT = "evt_ch5_abyss_exit";

			// Token: 0x04002C73 RID: 11379
			public const string EVT_CH5_ADMINISTRATION_ENTER = "evt_ch5_administration_enter";

			// Token: 0x04002C74 RID: 11380
			public const string EVT_CH5_ADMINISTRATION_EXIT = "evt_ch5_administration_exit";

			// Token: 0x04002C75 RID: 11381
			public const string EVT_CH5_JOEYS_OFFICE_ENTER = "evt_ch5_joeys_office_enter";

			// Token: 0x04002C76 RID: 11382
			public const string EVT_CH5_JOEYS_OFFICE_EXIT = "evt_ch5_joeys_office_exit";

			// Token: 0x04002C77 RID: 11383
			public const string EVT_CH5_VAULT_PUZZLE_ENTER = "evt_ch5_vault_puzzle_enter";

			// Token: 0x04002C78 RID: 11384
			public const string EVT_CH5_VAULT_PUZZLE_EXIT = "evt_ch5_vault_puzzle_exit";

			// Token: 0x04002C79 RID: 11385
			public const string EVT_CH5_VAULT_ENTER = "evt_ch5_vault_enter";

			// Token: 0x04002C7A RID: 11386
			public const string EVT_CH5_VAULT_EXIT = "evt_ch5_vault_exit";

			// Token: 0x04002C7B RID: 11387
			public const string EVT_CH5_BACK_HALL_ENTER = "evt_ch5_back_hall_enter";

			// Token: 0x04002C7C RID: 11388
			public const string EVT_CH5_BACK_HALL_EXIT = "evt_ch5_back_hall_exit";

			// Token: 0x04002C7D RID: 11389
			public const string EVT_CH5_GIANT_INK_MACHINE_ENTER = "evt_ch5_giant_ink_machine_enter";

			// Token: 0x04002C7E RID: 11390
			public const string EVT_CH5_GIANT_INK_MACHINE_EXIT = "evt_ch5_giant_ink_machine_exit";

			// Token: 0x04002C7F RID: 11391
			public const string EVT_CH5_MACHINE_INTERIOR_ENTER = "evt_ch5_machine_interior_enter";

			// Token: 0x04002C80 RID: 11392
			public const string EVT_CH5_MACHINE_INTERIOR_EXIT = "evt_ch5_machine_interior_exit";

			// Token: 0x04002C81 RID: 11393
			public const string EVT_CH5_THRONE_ROOM_ENTER = "evt_ch5_throne_room_enter";

			// Token: 0x04002C82 RID: 11394
			public const string EVT_CH5_THRONE_ROOM_EXIT = "evt_ch5_throne_room_exit";

			// Token: 0x04002C83 RID: 11395
			public const string EVT_CH5_BENDY_ARENA_ENTER = "evt_ch5_bendy_arena_enter";

			// Token: 0x04002C84 RID: 11396
			public const string EVT_CH5_BENDY_ARENA_EXIT = "evt_ch5_bendy_arena_exit";

			// Token: 0x04002C85 RID: 11397
			public const string RESETMIXERS = "ResetMixers";

			// Token: 0x04002C86 RID: 11398
			public const string SFX_INK_IN_HAND_LOOP = "sfx_ink_in_hand_loop";

			// Token: 0x04002C87 RID: 11399
			public const string SFX_AXE_HIT_METAL = "sfx_axe_hit_metal";

			// Token: 0x04002C88 RID: 11400
			public const string INKVALVE = "InkValve";

			// Token: 0x04002C89 RID: 11401
			public const string MIRACLESTATION = "MiracleStation";

			// Token: 0x04002C8A RID: 11402
			public const string SAVESTATION = "SaveStation";

			// Token: 0x04002C8B RID: 11403
			public const string SEEINGTOOL = "SeeingTool";

			// Token: 0x04002C8C RID: 11404
			public const string HORRORVISION = "Horror Vision";

			// Token: 0x04002C8D RID: 11405
			public const string PLAYERDEATHTUNNEL = "Player Death Tunnel";

			// Token: 0x04002C8E RID: 11406
			public const string AMB_ORIGINAL_BENDY_LOOP = "amb_original_bendy_loop";

			// Token: 0x04002C8F RID: 11407
			public const string AMB_INDUSTRIAL_LOOP = "amb_industrial_loop";

			// Token: 0x04002C90 RID: 11408
			public const string AMB_CLOSEUP_LOOP = "amb_closeup_loop";

			// Token: 0x04002C91 RID: 11409
			public const string AMB_HEAVY_LOOP = "amb_heavy_loop";

			// Token: 0x04002C92 RID: 11410
			public const string AMB_AIRY_OUTDOOR = "amb_airy_outdoor";

			// Token: 0x04002C93 RID: 11411
			public const string AMB_SPOT_BLEND_BARN = "amb_spot_blend_barn";

			// Token: 0x04002C94 RID: 11412
			public const string AMB_SPOT_BLEND_THEATRE = "amb_spot_blend_theatre";

			// Token: 0x04002C95 RID: 11413
			public const string AMB_VENT_AIR_LOOP_POWER = "amb_vent_air_loop_power";

			// Token: 0x04002C96 RID: 11414
			public const string AMB_JOEY_DREW_LOGO0 = "amb_joey_drew_logo (0)";

			// Token: 0x04002C97 RID: 11415
			public const string AMB_JOEY_DREW_LOGO1 = "amb_joey_drew_logo (1)";

			// Token: 0x04002C98 RID: 11416
			public const string AMB_VENT_AIR_LOOP_MAIN = "amb_vent_air_loop_main";

			// Token: 0x04002C99 RID: 11417
			public const string AMB_PROJECTOR_SPOT_LOOP_MAIN = "amb_projector_spot_loop_main";

			// Token: 0x04002C9A RID: 11418
			public const string AMB_ART_DESK_MAIN = "amb_art_desk_main";

			// Token: 0x04002C9B RID: 11419
			public const string AMB_VENT_AIR_LOOP_DREAMS = "amb_vent_air_loop_dreams";

			// Token: 0x04002C9C RID: 11420
			public const string AMB_SMALL_ROOM_LOOP_DREAMS = "amb_small_room_loop_dreams";

			// Token: 0x04002C9D RID: 11421
			public const string AMB_SWITCHES_DREAMS = "amb_switches_dreams";

			// Token: 0x04002C9E RID: 11422
			public const string AMB_ART_DESK_LARGE1 = "amb_art_desk_large1";

			// Token: 0x04002C9F RID: 11423
			public const string AMB_ART_DESK_LARGE2 = "amb_art_desk_large2";

			// Token: 0x04002CA0 RID: 11424
			public const string AMB_WORLD_AIR_LOOP_LARGE1 = "amb_world_air_loop_large1";

			// Token: 0x04002CA1 RID: 11425
			public const string AMB_WORLD_AIR_LOOP_LARGE2 = "amb_world_air_loop_large2";

			// Token: 0x04002CA2 RID: 11426
			public const string AMB_RUMBLE_LOOP_BORIS = "amb_rumble_loop_boris";

			// Token: 0x04002CA3 RID: 11427
			public const string AMB_WHISPERS_LOOP_BORIS = "amb_whispers_loop_boris";

			// Token: 0x04002CA4 RID: 11428
			public const string AMB_INK_SLIME_BORIS = "amb_ink_slime_boris";

			// Token: 0x04002CA5 RID: 11429
			public const string AMB_PANEL_HUM_LOOP_POWER = "amb_panel_hum_loop_power";

			// Token: 0x04002CA6 RID: 11430
			public const string AMB_HEAVY_LOOP_ART = "amb_heavy_loop_art";

			// Token: 0x04002CA7 RID: 11431
			public const string AMB_SWITCHES_ART = "amb_switches_art";

			// Token: 0x04002CA8 RID: 11432
			public const string AMB_ART_DESK_ART1 = "amb_art_desk_art1";

			// Token: 0x04002CA9 RID: 11433
			public const string AMB_ART_DESK_ART2 = "amb_art_desk_art2";

			// Token: 0x04002CAA RID: 11434
			public const string AMB_PROP_LIGHT_FLICKER_ART = "amb_prop_light_flicker_art";

			// Token: 0x04002CAB RID: 11435
			public const string AMB_BATHROOM_LOOP_ART = "amb_bathroom_loop_art";

			// Token: 0x04002CAC RID: 11436
			public const string AMB_BATHROOM_DRIP_ART = "amb_bathroom_drip_art";

			// Token: 0x04002CAD RID: 11437
			public const string AMB_HEAVY_LOOP_BREAK = "amb_heavy_loop_break";

			// Token: 0x04002CAE RID: 11438
			public const string AMB_SWITCHES_BREAK = "amb_switches_break";

			// Token: 0x04002CAF RID: 11439
			public const string AMB_ORIGINAL_HORROR_LOOP_BREAK = "amb_original_horror_loop_break";

			// Token: 0x04002CB0 RID: 11440
			public const string AMB_WOOD_DEEP_CREAK_BREAK = "amb_wood_deep_creak_break";

			// Token: 0x04002CB1 RID: 11441
			public const string AMB_PROP_LIGHT_FLICKER_BREAK = "amb_prop_light_flicker_break";

			// Token: 0x04002CB2 RID: 11442
			public const string AMB_PROP_LIGHT_FLICKER_STAIR = "amb_prop_light_flicker_stair";

			// Token: 0x04002CB3 RID: 11443
			public const string AMB_VENT_AIR_LOOP_STAIR = "amb_vent_air_loop_stair";

			// Token: 0x04002CB4 RID: 11444
			public const string AMB_INK_RAIN_TMG_STAIR1 = "amb_ink_rain_tmg_stair1";

			// Token: 0x04002CB5 RID: 11445
			public const string AMB_INK_RAIN_TMG_STAIR2 = "amb_ink_rain_tmg_stair2";

			// Token: 0x04002CB6 RID: 11446
			public const string AMB_INK_RAIN_TMG_STAIR3 = "amb_ink_rain_tmg_stair3";

			// Token: 0x04002CB7 RID: 11447
			public const string AMB_INK_SLIME_HOLE_STAIR = "amb_ink_slime_hole_stair";

			// Token: 0x04002CB8 RID: 11448
			public const string AMB_INK_SLIME_STAIR1 = "amb_ink_slime_stair1";

			// Token: 0x04002CB9 RID: 11449
			public const string AMB_INK_SLIME_STAIR2 = "amb_ink_slime_stair2";

			// Token: 0x04002CBA RID: 11450
			public const string AMB_INK_SLIME_STAIR3 = "amb_ink_slime_stair3";

			// Token: 0x04002CBB RID: 11451
			public const string AMB_INK_SLIME_STAIR4 = "amb_ink_slime_stair4";

			// Token: 0x04002CBC RID: 11452
			public const string AMB_INK_SLIME_STAIR5 = "amb_ink_slime_stair5";

			// Token: 0x04002CBD RID: 11453
			public const string AMB_INK_PIPE_BUBBLES = "amb_ink_pipe_bubbles";

			// Token: 0x04002CBE RID: 11454
			public const string AMB_3GEARS_METAL_BARN = "amb_3gears_metal_barn";

			// Token: 0x04002CBF RID: 11455
			public const string AMB_3GEARS_LOOP_BARN = "amb_3gears_loop_barn";

			// Token: 0x04002CC0 RID: 11456
			public const string AMB_CAGE_IDLE_MOVES_LEFT = "amb_cage_idle_moves_left";

			// Token: 0x04002CC1 RID: 11457
			public const string AMB_CAGE_IDLE_MOVES_ROOM = "amb_cage_idle_moves_room";

			// Token: 0x04002CC2 RID: 11458
			public const string SFX_INK_MACHINE_MOVING_CHAINS = "sfx_ink_machine_moving_chains";

			// Token: 0x04002CC3 RID: 11459
			public const string SFX_BERT_STEAM_BURSTS = "sfx_bert_steam_bursts";

			// Token: 0x04002CC4 RID: 11460
			public const string SFX_BATTERY_START = "sfx_battery_start";

			// Token: 0x04002CC5 RID: 11461
			public const string SFX_BATTERY_LOOP = "sfx_battery_loop";

			// Token: 0x04002CC6 RID: 11462
			public const string SFX_INK_MACHINE_WORKING_FINALE = "sfx_ink_machine_working_finale";

			// Token: 0x04002CC7 RID: 11463
			public const string SFX_INK_PIPE_FLOW = "sfx_ink_pipe_flow";

			// Token: 0x04002CC8 RID: 11464
			public const string SFX_INK_FLOOR = "sfx_ink_floor";

			// Token: 0x04002CC9 RID: 11465
			public const string AMB_TILE_WALL_MECH_THEATRE = "amb_tile_wall_mech_theatre";

			// Token: 0x04002CCA RID: 11466
			public const string SFX_INK_BURSTS = "sfx_ink_bursts";

			// Token: 0x04002CCB RID: 11467
			public const string SFX_INK_HEAVY_EVERYWHERE = "sfx_ink_heavy_everywhere";

			// Token: 0x04002CCC RID: 11468
			public const string SFX_FLOOR_CAVEIN_MIX = "sfx_floor_cavein_mix";

			// Token: 0x04002CCD RID: 11469
			public const string SFX_VALVE1_INK_FLOOD = "sfx_valve1_ink_flood";

			// Token: 0x04002CCE RID: 11470
			public const string SFX_VALVE2_INK_FLOOD = "sfx_valve2_ink_flood";

			// Token: 0x04002CCF RID: 11471
			public const string SFX_VALVE3_INK_FLOOD = "sfx_valve3_ink_flood";

			// Token: 0x04002CD0 RID: 11472
			public const string SFX_COLLAPSE_INK = "sfx_collapse_ink";

			// Token: 0x04002CD1 RID: 11473
			public const string AMB_TILE_WALL_MECH_POWER1 = "amb_tile_wall_mech_power1";

			// Token: 0x04002CD2 RID: 11474
			public const string AMB_TILE_WALL_MECH_POWER2 = "amb_tile_wall_mech_power2";

			// Token: 0x04002CD3 RID: 11475
			public const string SFX_MAIN_POWER_SWITCHED_ON = "sfx_main_power_switched_on";

			// Token: 0x04002CD4 RID: 11476
			public const string AMB_INK_FLOOR_LOOP_HALLWAY = "amb_ink_floor_loop_hallway";

			// Token: 0x04002CD5 RID: 11477
			public const string AMB_WATER_FLOODED_LOOP_STAIRS = "amb_water_flooded_loop_stairs";

			// Token: 0x04002CD6 RID: 11478
			public const string AMB_INDUSTRIAL_LOOP_BALCONY = "amb_industrial_loop_balcony";

			// Token: 0x04002CD7 RID: 11479
			public const string AMB_INDUSTRIAL_LOOP_STUDIO = "amb_industrial_loop_studio";

			// Token: 0x04002CD8 RID: 11480
			public const string AMB_HEAVY_LOOP_INFIRMARY = "amb_heavy_loop_infirmary";

			// Token: 0x04002CD9 RID: 11481
			public const string AMB_TUNNEL_LOOP_INFIRMARY = "amb_tunnel_loop_infirmary";

			// Token: 0x04002CDA RID: 11482
			public const string AMB_INK_PILLAR = "amb_ink_pillar";

			// Token: 0x04002CDB RID: 11483
			public const string AMB_STONE_CRUMBLE_OPENING = "amb_stone_crumble_opening";

			// Token: 0x04002CDC RID: 11484
			public const string AMB_STONE_CRUMBLE_OPENING1 = "amb_stone_crumble_opening (1)";

			// Token: 0x04002CDD RID: 11485
			public const string AMB_WOOD_DEEP_CREAK_OPENING = "amb_wood_deep_creak_opening";

			// Token: 0x04002CDE RID: 11486
			public const string AMB_WOOD_DEEP_CREAK_OPENING1 = "amb_wood_deep_creak_opening (1)";

			// Token: 0x04002CDF RID: 11487
			public const string AMB_WOOD_DEEP_CREAK_OPENING2 = "amb_wood_deep_creak_opening (2)";

			// Token: 0x04002CE0 RID: 11488
			public const string AMB_RUMBLE_TONES_OPENING = "amb_rumble_tones_opening";

			// Token: 0x04002CE1 RID: 11489
			public const string AMB_WATER_DRIP_HALLWAY = "amb_water_drip_hallway";

			// Token: 0x04002CE2 RID: 11490
			public const string AMB_WATER_DRIP_HALLWAY1 = "amb_water_drip_hallway (1)";

			// Token: 0x04002CE3 RID: 11491
			public const string AMB_PROP_LIGHT_FLICKER_HALLWAY = "amb_prop_light_flicker_hallway";

			// Token: 0x04002CE4 RID: 11492
			public const string AMB_WOOD_DEEP_CREAK_DEPT = "amb_wood_deep_creak_dept";

			// Token: 0x04002CE5 RID: 11493
			public const string AMB_METAL_IDLE_DEPT = "amb_metal_idle_dept";

			// Token: 0x04002CE6 RID: 11494
			public const string AMB_SWITCHES_DEPT = "amb_switches_dept";

			// Token: 0x04002CE7 RID: 11495
			public const string AMB_BOOK_PAPERS_STUDIO = "amb_book_papers_studio";

			// Token: 0x04002CE8 RID: 11496
			public const string AMB_WHISPERS_LOOP_SECRET = "amb_whispers_loop_secret";

			// Token: 0x04002CE9 RID: 11497
			public const string AMB_RUMBLE_LOOP_SECRET = "amb_rumble_loop_secret";

			// Token: 0x04002CEA RID: 11498
			public const string AMB_VENT_AIR_LOOP_SECRET = "amb_vent_air_loop_secret";

			// Token: 0x04002CEB RID: 11499
			public const string AMB_BOOK_PAPERS_OFFICE = "amb_book_papers_office";

			// Token: 0x04002CEC RID: 11500
			public const string AMB_BOOK_PAPERS_OFFICE1 = "amb_book_papers_office (1)";

			// Token: 0x04002CED RID: 11501
			public const string AMB_WOOD_SMALL_OFFICE = "amb_wood_small_office";

			// Token: 0x04002CEE RID: 11502
			public const string AMB_PANEL_HUM_PUNCH_CLOCK_OFFICE = "amb_panel_hum_punch_clock_office";

			// Token: 0x04002CEF RID: 11503
			public const string AMB_PANEL_HUM_PUMP_CONTROL = "amb_panel_hum_pump_control";

			// Token: 0x04002CF0 RID: 11504
			public const string AMB_PROP_LIGHT_FLICKER_OFFICE1 = "amb_prop_light_flicker_office (1)";

			// Token: 0x04002CF1 RID: 11505
			public const string AMB_WATER_FLOOD_OFFICE = "amb_water_flood_office";

			// Token: 0x04002CF2 RID: 11506
			public const string AMB_INK_FLOW = "amb_ink_flow";

			// Token: 0x04002CF3 RID: 11507
			public const string AMB_INK_SPRAY = "amb_ink_spray";

			// Token: 0x04002CF4 RID: 11508
			public const string AMB_WATER_DRIP_INFIRMARY = "amb_water_drip_infirmary";

			// Token: 0x04002CF5 RID: 11509
			public const string AMB_WATER_FLOODED_LOOP_INFIRMARY2 = "amb_water_flooded_loop_infirmary (2)";

			// Token: 0x04002CF6 RID: 11510
			public const string AMB_STONE_CRUMBLE_INFIRMARY = "amb_stone_crumble_infirmary";

			// Token: 0x04002CF7 RID: 11511
			public const string AMB_VENT_AIR_LOOP_SEWERS = "amb_vent_air_loop_sewers";

			// Token: 0x04002CF8 RID: 11512
			public const string AMB_VENT_AIR_LOOP_SEWERS1 = "amb_vent_air_loop_sewers (1)";

			// Token: 0x04002CF9 RID: 11513
			public const string AMB_METAL_IDLE_SEWERS = "amb_metal_idle_sewers";

			// Token: 0x04002CFA RID: 11514
			public const string AMB_AIRY_OUTDOOR_SEWERS = "amb_airy_outdoor_sewers";

			// Token: 0x04002CFB RID: 11515
			public const string AMB_WATER_FLOODED_LOOP_SEWERS = "amb_water_flooded_loop_sewers";

			// Token: 0x04002CFC RID: 11516
			public const string AMB_TUNNEL_LOOP_SEWERS = "amb_tunnel_loop_sewers";

			// Token: 0x04002CFD RID: 11517
			public const string AMB_AIRY_OUTDOOR_SACRIFICE = "amb_airy_outdoor_sacrifice";

			// Token: 0x04002CFE RID: 11518
			public const string AMB_WOOD_DEEP_CREAK_SACRIFICE = "amb_wood_deep_creak_sacrifice";

			// Token: 0x04002CFF RID: 11519
			public const string AMB_WATER_FLOODED_LOOP_SACRIFICE = "amb_water_flooded_loop_sacrifice";

			// Token: 0x04002D00 RID: 11520
			public const string AMB_RUMBLE_TONES_BORIS1 = "amb_rumble_tones_boris (1)";

			// Token: 0x04002D01 RID: 11521
			public const string AMB_WOOD_DEEP_CREAK_BORIS3 = "amb_wood_deep_creak_boris (3)";

			// Token: 0x04002D02 RID: 11522
			public const string AMB_WOOD_DEEP_CREAK_BORIS4 = "amb_wood_deep_creak_boris (4)";

			// Token: 0x04002D03 RID: 11523
			public const string AMB_STONE_CRUMBLE_BORIS2 = "amb_stone_crumble_boris (2)";

			// Token: 0x04002D04 RID: 11524
			public const string AMB_WATER_FLOODED_LOOP_CHASE = "amb_water_flooded_loop_chase";

			// Token: 0x04002D05 RID: 11525
			public const string AMB_WATER_FLOODED_LOOP_CHASE1 = "amb_water_flooded_loop_chase1";

			// Token: 0x04002D06 RID: 11526
			public const string SFX_GATE_PIPE = "sfx_gate_pipe";

			// Token: 0x04002D07 RID: 11527
			public const string SFX_GATE_RUMBLE = "sfx_gate_rumble";

			// Token: 0x04002D08 RID: 11528
			public const string SFX_GATE_METAL_ROLLING_OPEN = "sfx_gate_metal_rolling_open";

			// Token: 0x04002D09 RID: 11529
			public const string SFX_PUMP_CONTROL_BANGS = "sfx_pump_control_bangs";

			// Token: 0x04002D0A RID: 11530
			public const string SFX_PUMP_CONTROL_MORE = "sfx_pump_control_more";

			// Token: 0x04002D0B RID: 11531
			public const string SFX_PUMP_CONTROL_SWITCHED_ON = "sfx_pump_control_switched_on";

			// Token: 0x04002D0C RID: 11532
			public const string SFX_SEWER_PUZZLE_WINCH_UP_START = "sfx_sewer_puzzle_winch_up_start";

			// Token: 0x04002D0D RID: 11533
			public const string SFX_SEWER_PUZZLE_WINCH_UP_START2 = "sfx_sewer_puzzle_winch_up_start2";

			// Token: 0x04002D0E RID: 11534
			public const string SFX_SEWER_PUZZLE_WINCH_UP_STOP = "sfx_sewer_puzzle_winch_up_stop";

			// Token: 0x04002D0F RID: 11535
			public const string SFX_SEWER_PUZZLE_WINCH_DOWN = "sfx_sewer_puzzle_winch_down";

			// Token: 0x04002D10 RID: 11536
			public const string SFX_INK_BLOB_FALL = "sfx_ink_blob_fall";

			// Token: 0x04002D11 RID: 11537
			public const string SFX_INK_BLOB_LAND = "sfx_ink_blob_land";

			// Token: 0x04002D12 RID: 11538
			public const string SFX_INK_MACHINE_PASSBY_LOOP = "sfx_ink_machine_passby_loop";

			// Token: 0x04002D13 RID: 11539
			public const string AMB_INK_FLOOD_LOOP = "amb_ink_flood_loop";

			// Token: 0x04002D14 RID: 11540
			public const string AMB_BLENDER_LOOP_STAIRWELL_K = "amb_blender_loop_stairwell_K";

			// Token: 0x04002D15 RID: 11541
			public const string AMB_BLENDER_LOOP_STAIRWELL_11 = "amb_blender_loop_stairwell_11";

			// Token: 0x04002D16 RID: 11542
			public const string AMB_BLENDER_LOOP_STAIRWELL_P = "amb_blender_loop_stairwell_P";

			// Token: 0x04002D17 RID: 11543
			public const string AMB_BLENDER_LOOP_STAIRWELL_P_REAR = "amb_blender_loop_stairwell_P_rear";

			// Token: 0x04002D18 RID: 11544
			public const string AMB_BLENDER_LOOP_STAIRWELL_9 = "amb_blender_loop_stairwell_9";

			// Token: 0x04002D19 RID: 11545
			public const string AMB_BLENDER_LOOP_STAIRWELL_91 = "amb_blender_loop_stairwell_9 (1)";

			// Token: 0x04002D1A RID: 11546
			public const string AMB_BLENDER_LOOP_STAIRWELL_92 = "amb_blender_loop_stairwell_9 (2)";

			// Token: 0x04002D1B RID: 11547
			public const string AMB_BLENDER_LOOP_STAIRWELL_93 = "amb_blender_loop_stairwell_9 (3)";

			// Token: 0x04002D1C RID: 11548
			public const string AMB_BLENDER_LOOP_STAIRWELL_P_ROOM = "amb_blender_loop_stairwell_P_room";

			// Token: 0x04002D1D RID: 11549
			public const string AMB_BLENDER_LOOP_9_AIRY40 = "amb_blender_loop_9_airy (40)";

			// Token: 0x04002D1E RID: 11550
			public const string AMB_BLENDER_WORKSHOP_ALICEREVEAL = "amb_blender_workshop_alicereveal";

			// Token: 0x04002D1F RID: 11551
			public const string AMB_BLENDER_CHOICES_LIFTHALLS = "amb_blender_choices_lifthalls";

			// Token: 0x04002D20 RID: 11552
			public const string AMB_BLENDER_MECH3_LIFTHALLS_MAIN1 = "amb_blender_mech3_lifthalls_main1";

			// Token: 0x04002D21 RID: 11553
			public const string AMB_BLENDER_MECH3_LIFTHALLS_MAIN11 = "amb_blender_mech3_lifthalls_main1 (1)";

			// Token: 0x04002D22 RID: 11554
			public const string AMB_INK_HEAVY_FLOW_LOOP_TRAILER_BLEND = "amb_ink_heavy_flow_loop_trailer_blend";

			// Token: 0x04002D23 RID: 11555
			public const string AMB_BIG_BENDYCLOCK_STAIRWELL = "amb_big_bendyclock_stairwell";

			// Token: 0x04002D24 RID: 11556
			public const string AMB_FAN_SAFEHOUSE = "amb_fan_safehouse";

			// Token: 0x04002D25 RID: 11557
			public const string AMB_VENT_AIR_LOOP_SAFEHOUSE = "amb_vent_air_loop_safehouse";

			// Token: 0x04002D26 RID: 11558
			public const string AMB_INK_HEAVY_FLOW_LOOP_SAFEHOUSE = "amb_ink_heavy_flow_loop_safehouse";

			// Token: 0x04002D27 RID: 11559
			public const string AMB_INK_HEAVY_FLOW_LOOP_SAFEHOUSE1 = "amb_ink_heavy_flow_loop_safehouse (1)";

			// Token: 0x04002D28 RID: 11560
			public const string AMB_INK_HEAVY_FLOW_LOOP_SAFEHOUSE2 = "amb_ink_heavy_flow_loop_safehouse (2)";

			// Token: 0x04002D29 RID: 11561
			public const string AMB_FIRE_LOOP_SAFEHOUSE = "amb_fire_loop_safehouse";

			// Token: 0x04002D2A RID: 11562
			public const string AMB_VENT_AIR_LOOP_SAFEHOUSE1 = "amb_vent_air_loop_safehouse (1)";

			// Token: 0x04002D2B RID: 11563
			public const string AMB_PROP_LIGHT_FLICKER_SAFEHOUSE = "amb_prop_light_flicker_safehouse";

			// Token: 0x04002D2C RID: 11564
			public const string AMB_TOILET_WATER0 = "amb_toilet_water (0)";

			// Token: 0x04002D2D RID: 11565
			public const string AMB_TOILET_WATER1 = "amb_toilet_water (1)";

			// Token: 0x04002D2E RID: 11566
			public const string AMB_GEAR_MACHINE_SMALL = "amb_gear_machine_small";

			// Token: 0x04002D2F RID: 11567
			public const string AMB_INK_HEAVY_FLOW_DARK = "amb_ink_heavy_flow_dark";

			// Token: 0x04002D30 RID: 11568
			public const string AMB_INK_PILLAR_DARK = "amb_ink_pillar_dark";

			// Token: 0x04002D31 RID: 11569
			public const string AMB_INK_PILLAR_DARK1 = "amb_ink_pillar_dark (1)";

			// Token: 0x04002D32 RID: 11570
			public const string AMB_WOOD_DEEP_CREAK_TOYS = "amb_wood_deep_creak_toys";

			// Token: 0x04002D33 RID: 11571
			public const string AMB_ROPE_IDLE0 = "amb_rope_idle (0)";

			// Token: 0x04002D34 RID: 11572
			public const string AMB_ROPE_IDLE1 = "amb_rope_idle (1)";

			// Token: 0x04002D35 RID: 11573
			public const string AMB_INK_FEATURE_HEAVY_LOOP = "amb_ink_feature_heavy_loop";

			// Token: 0x04002D36 RID: 11574
			public const string AMB_INK_FEATURE_FLOOD_LOOP = "amb_ink_feature_flood_loop";

			// Token: 0x04002D37 RID: 11575
			public const string AMB_INK_FEATURE_WATERFALL_LOOP = "amb_ink_feature_waterfall_loop";

			// Token: 0x04002D38 RID: 11576
			public const string AMB_VENT_AIR_LOOP_TOYS5 = "amb_vent_air_loop_toys (5)";

			// Token: 0x04002D39 RID: 11577
			public const string AMB_VENT_AIR_LOOP_TOYS6 = "amb_vent_air_loop_toys (6)";

			// Token: 0x04002D3A RID: 11578
			public const string AMB_CLOSEUP_LOOP_WORKSHOP = "amb_closeup_loop_workshop";

			// Token: 0x04002D3B RID: 11579
			public const string AMB_ROPE_IDLE2 = "amb_rope_idle (2)";

			// Token: 0x04002D3C RID: 11580
			public const string AMB_ROPE_IDLE3 = "amb_rope_idle (3)";

			// Token: 0x04002D3D RID: 11581
			public const string AMB_TILE_MECH1_WORKSHOP_RIGHT = "amb_tile_mech1_workshop_right";

			// Token: 0x04002D3E RID: 11582
			public const string AMB_TILE_MECH3_WORKSHOP_RIGHT = "amb_tile_mech3_workshop_right";

			// Token: 0x04002D3F RID: 11583
			public const string AMB_TILE_MECH2_WORKSHOP_RIGHT = "amb_tile_mech2_workshop_right";

			// Token: 0x04002D40 RID: 11584
			public const string AMB_TILE_3GEARS_WORKSHOP_RIGHT = "amb_tile_3gears_workshop_right";

			// Token: 0x04002D41 RID: 11585
			public const string AMB_TILE_MECH3_WORKSHOP_LEFT = "amb_tile_mech3_workshop_left";

			// Token: 0x04002D42 RID: 11586
			public const string AMB_TILE_MECH2_WORKSHOP_LEFT = "amb_tile_mech2_workshop_left";

			// Token: 0x04002D43 RID: 11587
			public const string AMB_TILE_MECH1_WORKSHOP_LEFT = "amb_tile_mech1_workshop_left";

			// Token: 0x04002D44 RID: 11588
			public const string AMB_TILE_3GEARS_WORKSHOP_LEFT = "amb_tile_3gears_workshop_left";

			// Token: 0x04002D45 RID: 11589
			public const string AMB_HEAVY_LOOP_ALICE = "amb_heavy_loop_alice";

			// Token: 0x04002D46 RID: 11590
			public const string AMB_PROP_LIGHT_FLICKER_ALICE1 = "amb_prop_light_flicker_alice1";

			// Token: 0x04002D47 RID: 11591
			public const string AMB_PROP_LIGHT_FLICKER_ALICE2 = "amb_prop_light_flicker_alice2";

			// Token: 0x04002D48 RID: 11592
			public const string AMB_RUMBLE_TONES_ALICE = "amb_rumble_tones_alice";

			// Token: 0x04002D49 RID: 11593
			public const string AMB_WOOD_DEEP_CREAK_ALICE = "amb_wood_deep_creak_alice";

			// Token: 0x04002D4A RID: 11594
			public const string AMB_INK_PILLAR_CHOICES = "amb_ink_pillar_choices";

			// Token: 0x04002D4B RID: 11595
			public const string AMB_INK_PILLAR_CHOICES1 = "amb_ink_pillar_choices (1)";

			// Token: 0x04002D4C RID: 11596
			public const string AMB_INK_PILLAR_CHOICES2 = "amb_ink_pillar_choices (2)";

			// Token: 0x04002D4D RID: 11597
			public const string AMB_INK_PILLAR_CHOICES3 = "amb_ink_pillar_choices (3)";

			// Token: 0x04002D4E RID: 11598
			public const string AMB_INK_PILLAR_CHOICES4 = "amb_ink_pillar_choices (4)";

			// Token: 0x04002D4F RID: 11599
			public const string AMB_INK_PILLAR_CHOICES5 = "amb_ink_pillar_choices (5)";

			// Token: 0x04002D50 RID: 11600
			public const string AMB_WATER_FLOODED_LOOP_DEVIL = "amb_water_flooded_loop_devil";

			// Token: 0x04002D51 RID: 11601
			public const string AMB_CLOSEUP_LOOP_LIFTHALL = "amb_closeup_loop_lifthall";

			// Token: 0x04002D52 RID: 11602
			public const string AMB_INDUSTRIAL_LOOP_LIFTHALL = "amb_industrial_loop_lifthall";

			// Token: 0x04002D53 RID: 11603
			public const string AMB_BENDYCLOCKS_LIFTHALL = "amb_bendyclocks_lifthall";

			// Token: 0x04002D54 RID: 11604
			public const string AMB_INK_PILLAR_LIFTHALL6 = "amb_ink_pillar_lifthall (6)";

			// Token: 0x04002D55 RID: 11605
			public const string AMB_INK_PILLAR_LIFTHALL7 = "amb_ink_pillar_lifthall (7)";

			// Token: 0x04002D56 RID: 11606
			public const string AMB_INK_PILLAR_LIFTHALL8 = "amb_ink_pillar_lifthall (8)";

			// Token: 0x04002D57 RID: 11607
			public const string AMB_INK_PILLAR_LIFTHALL9 = "amb_ink_pillar_lifthall (9)";

			// Token: 0x04002D58 RID: 11608
			public const string AMB_INK_HEAVY_FLOW_LOOP_LIFTHALL3 = "amb_ink_heavy_flow_loop_lifthall(3)";

			// Token: 0x04002D59 RID: 11609
			public const string AMB_INK_PILLAR_LIFTHALL10 = "amb_ink_pillar_lifthall (10)";

			// Token: 0x04002D5A RID: 11610
			public const string AMB_INK_PILLAR_LIFTHALL11 = "amb_ink_pillar_lifthall (11)";

			// Token: 0x04002D5B RID: 11611
			public const string AMB_INK_PILLAR_LIFTHALL12 = "amb_ink_pillar_lifthall (12)";

			// Token: 0x04002D5C RID: 11612
			public const string AMB_INK_PILLAR_LIFTHALL13 = "amb_ink_pillar_lifthall (13)";

			// Token: 0x04002D5D RID: 11613
			public const string AMB_INK_HEAVY_FLOW_LOOP_LIFTHALL4 = "amb_ink_heavy_flow_loop_lifthall (4)";

			// Token: 0x04002D5E RID: 11614
			public const string AMB_TUNNEL_LOOP_MAIN1 = "amb_tunnel_loop_main1";

			// Token: 0x04002D5F RID: 11615
			public const string AMB_METAL_IDLE_MAIN1 = "amb_metal_idle_main1";

			// Token: 0x04002D60 RID: 11616
			public const string AMB_RESPAWN_VOICES = "amb_respawn_voices";

			// Token: 0x04002D61 RID: 11617
			public const string AMB_TUNNEL_LOOP_TRAILER = "amb_tunnel_loop_trailer";

			// Token: 0x04002D62 RID: 11618
			public const string AMB_METAL_IDLE_TRAILER1 = "amb_metal_idle_trailer(1)";

			// Token: 0x04002D63 RID: 11619
			public const string AMB_3GEARS_LOOP_BRIDGE0 = "amb_3gears_loop_bridge (0)";

			// Token: 0x04002D64 RID: 11620
			public const string AMB_3GEARS_LOOP_BRIDGE1 = "amb_3gears_loop_bridge (1)";

			// Token: 0x04002D65 RID: 11621
			public const string SFX_MOVING_CHAINS_LOOP = "sfx_moving_chains_loop";

			// Token: 0x04002D66 RID: 11622
			public const string AMB_WIND_TONES_STAIRS = "amb_wind_tones_stairs";

			// Token: 0x04002D67 RID: 11623
			public const string AMB_INK_PILLAR_LIFTHALL20 = "amb_ink_pillar_lifthall (20)";

			// Token: 0x04002D68 RID: 11624
			public const string AMB_TILE_MECH3_LEVEL11 = "amb_tile_mech3_level11";

			// Token: 0x04002D69 RID: 11625
			public const string AMB_TILE_MECH2_LEVEL11 = "amb_tile_mech2_level11";

			// Token: 0x04002D6A RID: 11626
			public const string AMB_TILE_MECH1_LEVEL11 = "amb_tile_mech1_level11";

			// Token: 0x04002D6B RID: 11627
			public const string AMB_WIND_TONES20 = "amb_wind_tones (20)";

			// Token: 0x04002D6C RID: 11628
			public const string AMB_INK_FLOOD_2D_LEVEL11 = "amb_ink_flood_2D_level11";

			// Token: 0x04002D6D RID: 11629
			public const string AMB_INK_FLOOD_3D_LEVEL11_FRONT = "amb_ink_flood_3D_level11_front";

			// Token: 0x04002D6E RID: 11630
			public const string AMB_INK_FLOOD_3D_LEVEL11_REAR = "amb_ink_flood_3D_level11_rear";

			// Token: 0x04002D6F RID: 11631
			public const string AMB_SINK30 = "amb_sink (30)";

			// Token: 0x04002D70 RID: 11632
			public const string AMB_WIND_TONES30 = "amb_wind_tones (30)";

			// Token: 0x04002D71 RID: 11633
			public const string AMB_PROP_LIGHT_FLICKER_30 = "amb_prop_light_flicker_(30)";

			// Token: 0x04002D72 RID: 11634
			public const string AMB_PROP_LIGHT_FLICKER_31 = "amb_prop_light_flicker_ (31)";

			// Token: 0x04002D73 RID: 11635
			public const string AMB_BATHROOM_DRIP30 = "amb_bathroom_drip (30)";

			// Token: 0x04002D74 RID: 11636
			public const string AMB_ROOM_HUM_LAB1 = "amb_room_hum_lab1";

			// Token: 0x04002D75 RID: 11637
			public const string LEVEL_P_FLOOD = "Level_P_flood";

			// Token: 0x04002D76 RID: 11638
			public const string AMB_WIND_TONES40 = "amb_wind_tones (40)";

			// Token: 0x04002D77 RID: 11639
			public const string AMB_INK_HEAVY_FLOW_LOOP40 = "amb_ink_heavy_flow_loop (40)";

			// Token: 0x04002D78 RID: 11640
			public const string AMB_INK_FLOOD_3D40 = "amb_ink_flood_3D (40)";

			// Token: 0x04002D79 RID: 11641
			public const string AMB_INK_FLOOD_3D41 = "amb_ink_flood_3D (41)";

			// Token: 0x04002D7A RID: 11642
			public const string AMB_LOSTONE_BLUBS11 = "amb_lostone_blubs1 (1)";

			// Token: 0x04002D7B RID: 11643
			public const string AMB_LOSTONE_BLUBS21 = "amb_lostone_blubs2 (1)";

			// Token: 0x04002D7C RID: 11644
			public const string AMB_LOSTONE_BLUBS31 = "amb_lostone_blubs3 (1)";

			// Token: 0x04002D7D RID: 11645
			public const string AMB_LOSTONE_BLUBS12 = "amb_lostone_blubs1 (2)";

			// Token: 0x04002D7E RID: 11646
			public const string AMB_LOSTONE_BLUBS22 = "amb_lostone_blubs2 (2)";

			// Token: 0x04002D7F RID: 11647
			public const string AMB_LOSTONE_BLUBS32 = "amb_lostone_blubs3 (2)";

			// Token: 0x04002D80 RID: 11648
			public const string AMB_WATER_DRIP_RANDOM_HOLDING1 = "amb_water_drip_random_holding (1)";

			// Token: 0x04002D81 RID: 11649
			public const string AMB_BLENDER_LOOP_AIRY50 = "amb_blender_loop_airy (50)";

			// Token: 0x04002D82 RID: 11650
			public const string AMB_WIND_TONES50 = "amb_wind_tones (50)";

			// Token: 0x04002D83 RID: 11651
			public const string AMB_INK_HEAVY_PILAR_LOOP50 = "amb_ink_heavy_pilar_loop (50)";

			// Token: 0x04002D84 RID: 11652
			public const string AMB_INK_HEAVY_PILAR_LOOP51 = "amb_ink_heavy_pilar_loop (51)";

			// Token: 0x04002D85 RID: 11653
			public const string AMB_INK_HEAVY_PILAR_LOOP52 = "amb_ink_heavy_pilar_loop (52)";

			// Token: 0x04002D86 RID: 11654
			public const string AMB_INK_HEAVY_PILAR_LOOP53 = "amb_ink_heavy_pilar_loop (53)";

			// Token: 0x04002D87 RID: 11655
			public const string AMB_INK_HEAVY_PILAR_LOOP54 = "amb_ink_heavy_pilar_loop (54)";

			// Token: 0x04002D88 RID: 11656
			public const string AMB_INK_HEAVY_PILAR_LOOP55 = "amb_ink_heavy_pilar_loop (55)";

			// Token: 0x04002D89 RID: 11657
			public const string AMB_INK_FLOOD_3D50 = "amb_ink_flood_3D (50)";

			// Token: 0x04002D8A RID: 11658
			public const string AMB_INK_FLOOD_3D51 = "amb_ink_flood_3D (51)";

			// Token: 0x04002D8B RID: 11659
			public const string AMB_INK_FLOOD_3D52 = "amb_ink_flood_3D (52)";

			// Token: 0x04002D8C RID: 11660
			public const string AMB_INK_FLOOD_3D53 = "amb_ink_flood_3D (53)";

			// Token: 0x04002D8D RID: 11661
			public const string AMB_WATER_DRIP_RANDOM50 = "amb_water_drip_random (50)";

			// Token: 0x04002D8E RID: 11662
			public const string AMB_WATER_DRIP_RANDOM51 = "amb_water_drip_random (51)";

			// Token: 0x04002D8F RID: 11663
			public const string AMB_WATER_DRIP_RANDOM52 = "amb_water_drip_random (52)";

			// Token: 0x04002D90 RID: 11664
			public const string AMB_WATER_DRIP_RANDOM53 = "amb_water_drip_random (53)";

			// Token: 0x04002D91 RID: 11665
			public const string AMB_HEAVY_MACHINE_LOOP50 = "amb_heavy_machine_loop (50)";

			// Token: 0x04002D92 RID: 11666
			public const string SFX_BRIDGE_BLOCKER_DOOR_OPEN = "sfx_bridge_blocker_door_open";

			// Token: 0x04002D93 RID: 11667
			public const string SFX_BRIDGE_BLOCKER_DOOR_CLOSE = "sfx_bridge_blocker_door_close";

			// Token: 0x04002D94 RID: 11668
			public const string SFX_BRIDGE_BLEND_LOOP = "sfx_bridge_blend_loop";

			// Token: 0x04002D95 RID: 11669
			public const string AMB_STAGE_BLEND_LOOP = "amb_stage_blend_loop";

			// Token: 0x04002D96 RID: 11670
			public const string AMB_HORROR_AMBIENCE_LOOP_LIFT = "amb_horror_ambience_loop_lift";

			// Token: 0x04002D97 RID: 11671
			public const string AMB_WIND_TONES_ELEVATOR = "amb_wind_tones_elevator";

			// Token: 0x04002D98 RID: 11672
			public const string AMB_WOOD_DEEP_CREAK_ELEVATOR = "amb_wood_deep_creak_elevator";

			// Token: 0x04002D99 RID: 11673
			public const string AMB_3GEARS_METAL = "amb_3gears_metal";

			// Token: 0x04002D9A RID: 11674
			public const string AMB_3GEARS_LOOP = "amb_3gears_loop";

			// Token: 0x04002D9B RID: 11675
			public const string AMB_PROP_LIGHT_FLICKER_ELEVATOR = "amb_prop_light_flicker_elevator";

			// Token: 0x04002D9C RID: 11676
			public const string AMB_VENT_AIR_LOOP_LIFT = "amb_vent_air_loop_lift";

			// Token: 0x04002D9D RID: 11677
			public const string AMB_VENT_AIR_LOOP_LIFT2 = "amb_vent_air_loop_lift2";

			// Token: 0x04002D9E RID: 11678
			public const string AMB_SWITCHES = "amb_switches";

			// Token: 0x04002D9F RID: 11679
			public const string AMB_BOOK_PAPERS = "amb_book_papers";

			// Token: 0x04002DA0 RID: 11680
			public const string AMB_WOOD_SMALL_ARCHIVES = "amb_wood_small_archives";

			// Token: 0x04002DA1 RID: 11681
			public const string AMB_CLOSEUP_ROOMTONE_LOOP_BRIDGE = "amb_closeup_roomtone_loop_bridge";

			// Token: 0x04002DA2 RID: 11682
			public const string AMB_INK_BATH_CLOSED_LOOP = "amb_ink_bath_closed_loop";

			// Token: 0x04002DA3 RID: 11683
			public const string AMB_INK_BATH_CLOSED_BLUBS = "amb_ink_bath_closed_blubs";

			// Token: 0x04002DA4 RID: 11684
			public const string AMB_INK_BATH_OPEN_WATER = "amb_ink_bath_open_water";

			// Token: 0x04002DA5 RID: 11685
			public const string AMB_INK_BATH_OPEN_DRIPS = "amb_ink_bath_open_drips";

			// Token: 0x04002DA6 RID: 11686
			public const string AMB_PROP_LIGHT_FLICKER_BRIDGE = "amb_prop_light_flicker_bridge";

			// Token: 0x04002DA7 RID: 11687
			public const string AMB_STONE_CRUMBLE_MOVE = "amb_stone_crumble_move";

			// Token: 0x04002DA8 RID: 11688
			public const string AMB_METAL_IDLE = "amb_metal_idle";

			// Token: 0x04002DA9 RID: 11689
			public const string AMB_INK_SLIME_BRIDGE0 = "amb_ink_slime_bridge (0)";

			// Token: 0x04002DAA RID: 11690
			public const string AMB_INK_SLIME_BRIDGE1 = "amb_ink_slime_bridge (1)";

			// Token: 0x04002DAB RID: 11691
			public const string AMB_CAGE_IDLE_MOVES_BRIDGE1 = "amb_cage_idle_moves_bridge1";

			// Token: 0x04002DAC RID: 11692
			public const string AMB_CAGE_IDLE_MOVES_BRIDGE2 = "amb_cage_idle_moves_bridge2";

			// Token: 0x04002DAD RID: 11693
			public const string AMB_CAGE_IDLE_MOVES_BRIDGE3 = "amb_cage_idle_moves_bridge3";

			// Token: 0x04002DAE RID: 11694
			public const string AMB_CAGE_IDLE_MOVES_BRIDGE4 = "amb_cage_idle_moves_bridge4";

			// Token: 0x04002DAF RID: 11695
			public const string AMB_CAGE_IDLE_MOVES_BRIDGE5 = "amb_cage_idle_moves_bridge5";

			// Token: 0x04002DB0 RID: 11696
			public const string AMB_CAGE_IDLE_MOVES_BRIDGE6 = "amb_cage_idle_moves_bridge6";

			// Token: 0x04002DB1 RID: 11697
			public const string AMB_RUMBLE_TONES_STAIRS = "amb_rumble_tones_stairs";

			// Token: 0x04002DB2 RID: 11698
			public const string AMB_WOOD_DEEP_CREAK_STAIRS = "amb_wood_deep_creak_stairs";

			// Token: 0x04002DB3 RID: 11699
			public const string AMB_WOOD_SMALL_STAIRS = "amb_wood_small_stairs";

			// Token: 0x04002DB4 RID: 11700
			public const string AMB_PROP_LIGHT_FLICKER_STAIRS = "amb_prop_light_flicker_stairs";

			// Token: 0x04002DB5 RID: 11701
			public const string AMB_CAGE_IDLE_MOVES_STAIRS1 = "amb_cage_idle_moves_stairs1";

			// Token: 0x04002DB6 RID: 11702
			public const string AMB_CAGE_IDLE_MOVES_STAIRS2 = "amb_cage_idle_moves_stairs2";

			// Token: 0x04002DB7 RID: 11703
			public const string AMB_VENT_PINGS = "amb_vent_pings";

			// Token: 0x04002DB8 RID: 11704
			public const string AMB_VENT_RATTLES = "amb_vent_rattles";

			// Token: 0x04002DB9 RID: 11705
			public const string AMB_INK_VENT = "amb_ink_vent";

			// Token: 0x04002DBA RID: 11706
			public const string AMB_WIND_TONES_HOLDING = "amb_wind_tones_holding";

			// Token: 0x04002DBB RID: 11707
			public const string AMB_SWITCHES_HOLDING = "amb_switches_holding";

			// Token: 0x04002DBC RID: 11708
			public const string AMB_WOOD_SMALL_HOLDING = "amb_wood_small_holding";

			// Token: 0x04002DBD RID: 11709
			public const string AMB_LOSTONE_BLUBS1 = "amb_lostone_blubs1";

			// Token: 0x04002DBE RID: 11710
			public const string AMB_LOSTONE_BLUBS2 = "amb_lostone_blubs2";

			// Token: 0x04002DBF RID: 11711
			public const string AMB_LOSTONE_BLUBS3 = "amb_lostone_blubs3";

			// Token: 0x04002DC0 RID: 11712
			public const string AMB_INK_SLIME_IDLE1 = "amb_ink_slime_idle1";

			// Token: 0x04002DC1 RID: 11713
			public const string AMB_INK_SLIME_IDLE2 = "amb_ink_slime_idle2";

			// Token: 0x04002DC2 RID: 11714
			public const string AMB_INK_SLIME_IDLE3 = "amb_ink_slime_idle3";

			// Token: 0x04002DC3 RID: 11715
			public const string AMB_VENT_AIR_RATTLE_LOOP_HOLDING = "amb_vent_air_rattle_loop_holding";

			// Token: 0x04002DC4 RID: 11716
			public const string AMB_WATER_DRIP_HOLDING = "amb_water_drip_holding";

			// Token: 0x04002DC5 RID: 11717
			public const string AMB_WATER_DRIP_RANDOM_HOLDING = "amb_water_drip_random_holding";

			// Token: 0x04002DC6 RID: 11718
			public const string LOSTONE_CRYING_HOLDING = "lostone_crying_holding";

			// Token: 0x04002DC7 RID: 11719
			public const string AMB_ORIGINAL_AMBIENCE_LOOP_MAP = "amb_original_ambience_loop_map";

			// Token: 0x04002DC8 RID: 11720
			public const string AMB_DEEP_HOLLOW_TONAL_LOOP_MAP = "amb_deep_hollow_tonal_loop_map";

			// Token: 0x04002DC9 RID: 11721
			public const string AMB_CLOSEUP_ROOMTONE_LOOP_MAP = "amb_closeup_roomtone_loop_map";

			// Token: 0x04002DCA RID: 11722
			public const string AMB_BOOK_PAPERS_MAPROOM = "amb_book_papers_maproom";

			// Token: 0x04002DCB RID: 11723
			public const string AMB_VENT_AIR_LOOP_MAPLOFT = "amb_vent_air_loop_maploft";

			// Token: 0x04002DCC RID: 11724
			public const string AMB_VENT_AIR_RATTLE_LOOP_MAP = "amb_vent_air_rattle_loop_map";

			// Token: 0x04002DCD RID: 11725
			public const string AMB_CAGE_IDLE_MOVES_MAP1 = "amb_cage_idle_moves_map1";

			// Token: 0x04002DCE RID: 11726
			public const string AMB_CLOSEUP_ROOMTONE_LOOP_WAREHOUSE = "amb_closeup_roomtone_loop_warehouse";

			// Token: 0x04002DCF RID: 11727
			public const string AMB_PANEL_HUM_LOOP_WAREHOUSE = "amb_panel_hum_loop_warehouse";

			// Token: 0x04002DD0 RID: 11728
			public const string AMB_METAL_IDLE_WAREHOUSE = "amb_metal_idle_warehouse";

			// Token: 0x04002DD1 RID: 11729
			public const string AMB_WOOD_SMALL_WAREHOUSE0 = "amb_wood_small_warehouse (0)";

			// Token: 0x04002DD2 RID: 11730
			public const string AMB_WOOD_SMALL_WAREHOUSE1 = "amb_wood_small_warehouse (1)";

			// Token: 0x04002DD3 RID: 11731
			public const string AMB_WOOD_SMALL_WAREHOUSE2 = "amb_wood_small_warehouse (2)";

			// Token: 0x04002DD4 RID: 11732
			public const string AMB_WOOD_SMALL_WAREHOUSE3 = "amb_wood_small_warehouse (3)";

			// Token: 0x04002DD5 RID: 11733
			public const string AMB_INK_PILLAR_RND = "amb_ink_pillar_rnd";

			// Token: 0x04002DD6 RID: 11734
			public const string AMB_CLOSEUP_ROOMTONE_LOOP_RND_UPPER = "amb_closeup_roomtone_loop_rnd_upper";

			// Token: 0x04002DD7 RID: 11735
			public const string AMB_WOOD_SMALL_RND = "amb_wood_small_rnd";

			// Token: 0x04002DD8 RID: 11736
			public const string AMB_VENT_RATTLES_RND = "amb_vent_rattles_rnd";

			// Token: 0x04002DD9 RID: 11737
			public const string AMB_MECH_WALL_RND1 = "amb_mech_wall_rnd1";

			// Token: 0x04002DDA RID: 11738
			public const string AMB_MECH_WALL_RND2 = "amb_mech_wall_rnd2";

			// Token: 0x04002DDB RID: 11739
			public const string AMB_CLOSEUP_ROOMTONE_LOOP_RND_LOWER = "amb_closeup_roomtone_loop_rnd_lower";

			// Token: 0x04002DDC RID: 11740
			public const string AMB_VENT_AIR_LOOP_RND = "amb_vent_air_loop_rnd";

			// Token: 0x04002DDD RID: 11741
			public const string LOSTONE_CRYING_RND = "lostone_crying_rnd";

			// Token: 0x04002DDE RID: 11742
			public const string AMB_3GEARS_METAL_RND = "amb_3gears_metal_rnd";

			// Token: 0x04002DDF RID: 11743
			public const string AMB_3GEARS_LOOP_RND = "amb_3gears_loop_rnd";

			// Token: 0x04002DE0 RID: 11744
			public const string AMB_WATER_DRIP = "amb_water_drip";

			// Token: 0x04002DE1 RID: 11745
			public const string AMB_RUMBLE_TONES = "amb_rumble_tones";

			// Token: 0x04002DE2 RID: 11746
			public const string AMB_DEEP_HOLLOW_MAINTENANCE = "amb_deep_hollow_maintenance";

			// Token: 0x04002DE3 RID: 11747
			public const string AMB_MECH_WALL_MAINTENANCE1 = "amb_mech_wall_maintenance1";

			// Token: 0x04002DE4 RID: 11748
			public const string AMB_MECH_WALL_MAINTENANCE2 = "amb_mech_wall_maintenance2";

			// Token: 0x04002DE5 RID: 11749
			public const string AMB_PROP_LIGHT_FLICKER_MAINTENANCE = "amb_prop_light_flicker_maintenance";

			// Token: 0x04002DE6 RID: 11750
			public const string AMB_PROP_LIGHT_FLICKER_MAINTENANCE2 = "amb_prop_light_flicker_maintenance2";

			// Token: 0x04002DE7 RID: 11751
			public const string AMB_3GEARS_METAL_MAINTENANCE = "amb_3gears_metal_maintenance";

			// Token: 0x04002DE8 RID: 11752
			public const string AMB_3GEARS_LOOP_MAINTENANCE = "amb_3gears_loop_maintenance";

			// Token: 0x04002DE9 RID: 11753
			public const string AMB_DEEP_HOLLOW_TONAL_LOOP_RIDESTORAGE = "amb_deep_hollow_tonal_loop_ridestorage";

			// Token: 0x04002DEA RID: 11754
			public const string AMB_CLOSEUP_ROOMTONE_LOOP_RIDESTORAGE = "amb_closeup_roomtone_loop_ridestorage";

			// Token: 0x04002DEB RID: 11755
			public const string AMB_INK_PIPE_STORAGEL = "amb_ink_pipe_storageL";

			// Token: 0x04002DEC RID: 11756
			public const string AMB_INK_PIPE_STORAGER = "amb_ink_pipe_storageR";

			// Token: 0x04002DED RID: 11757
			public const string AMB_INK_BUBBLES_STORAGER = "amb_ink_bubbles_storageR";

			// Token: 0x04002DEE RID: 11758
			public const string AMB_INK_BUBBLES_STORAGEL = "amb_ink_bubbles_storageL";

			// Token: 0x04002DEF RID: 11759
			public const string AMB_PROP_LIGHT_FLICKER_STORAGE1 = "amb_prop_light_flicker_storage1";

			// Token: 0x04002DF0 RID: 11760
			public const string AMB_PROP_LIGHT_FLICKER_STORAGE2 = "amb_prop_light_flicker_storage2";

			// Token: 0x04002DF1 RID: 11761
			public const string AMB_PROP_LIGHT_FLICKER_STORAGE3 = "amb_prop_light_flicker_storage3";

			// Token: 0x04002DF2 RID: 11762
			public const string AMB_TUNNEL_LOOP_HH = "amb_tunnel_loop_hh";

			// Token: 0x04002DF3 RID: 11763
			public const string AMB_INK_PIPE_HH = "amb_ink_pipe_hh";

			// Token: 0x04002DF4 RID: 11764
			public const string AMB_PROP_LIGHT_FLICKER_HH = "amb_prop_light_flicker_hh";

			// Token: 0x04002DF5 RID: 11765
			public const string AMB_PROP_LIGHT_FLICKER_HH1 = "amb_prop_light_flicker_hh (1)";

			// Token: 0x04002DF6 RID: 11766
			public const string AMB_INDUSTRIAL_ECHOES_LOOP_BALLROOM = "amb_industrial_echoes_loop_ballroom";

			// Token: 0x04002DF7 RID: 11767
			public const string AMB_WOOD_SMALL_BALLROOM = "amb_wood_small_ballroom";

			// Token: 0x04002DF8 RID: 11768
			public const string SFX_STAGELIGHTS = "sfx_stagelights";

			// Token: 0x04002DF9 RID: 11769
			public const string SFX_INK_BATH_PIPE_OPENS = "sfx_ink_bath_pipe_opens";

			// Token: 0x04002DFA RID: 11770
			public const string AMB_SIDE_ROOM_RUMBLE = "amb_side_room_rumble";

			// Token: 0x04002DFB RID: 11771
			public const string AMB_SIDE_ROOM_WHISPERS = "amb_side_room_whispers";

			// Token: 0x04002DFC RID: 11772
			public const string SFX_SEARCHER_INK_BUBBLES = "sfx_searcher_ink_bubbles";

			// Token: 0x04002DFD RID: 11773
			public const string SFX_SEARCHER_INK_BURBLE = "sfx_searcher_ink_burble";

			// Token: 0x04002DFE RID: 11774
			public const string SFX_SEARCHER_INK_SPLASH = "sfx_searcher_ink_splash";

			// Token: 0x04002DFF RID: 11775
			public const string SFX_INK_MACHINE_MOVING_LOOP1 = "sfx_ink_machine_moving_loop (1)";

			// Token: 0x04002E00 RID: 11776
			public const string SFX_HEADBANG_ECHO_LFE = "sfx_headbang_echo_lfe";

			// Token: 0x04002E01 RID: 11777
			public const string SFX_PLAYER_HIT_BY_BORIS = "sfx_player_hit_by_boris";

			// Token: 0x04002E02 RID: 11778
			public const string VO_HENRY_INJURED = "vo_henry_injured";

			// Token: 0x04002E03 RID: 11779
			public const string SFX_BORIS_DEATH_MELT = "sfx_boris_death_melt";

			// Token: 0x04002E04 RID: 11780
			public const string SFX_HAUNTED_HOUSE_POWERUP = "sfx_haunted_house_powerup";

			// Token: 0x04002E05 RID: 11781
			public const string SFX_CREEPY_LAUGH = "sfx_creepy_laugh";

			// Token: 0x04002E06 RID: 11782
			public const string SFX_HAUNTED_HOUSE_RUNNING_INK = "sfx_haunted_house_running_ink";

			// Token: 0x04002E07 RID: 11783
			public const string SFX_HAUNTED_HOUSE_RUNNING_TRACKS = "sfx_haunted_house_running_tracks";

			// Token: 0x04002E08 RID: 11784
			public const string SFX_FAIR_GAME_WIN = "sfx_fair_game_win";

			// Token: 0x04002E09 RID: 11785
			public const string SFX_FAIR_GAME_LOSE = "sfx_fair_game_lose";

			// Token: 0x04002E0A RID: 11786
			public const string JOEL_TEST_NEW = "JOEL_TEST_NEW";

			// Token: 0x04002E0B RID: 11787
			public const string SFX_WORKBENCH_DESTROYED = "sfx_workbench_destroyed";

			// Token: 0x04002E0C RID: 11788
			public const string SFX_BERT_HUB_SPIN_START = "sfx_bert_hub_spin_start";

			// Token: 0x04002E0D RID: 11789
			public const string SFX_BERT_HUB_SPINNING = "sfx_bert_hub_spinning";

			// Token: 0x04002E0E RID: 11790
			public const string SFX_BERT_HUB_IDLE = "sfx_bert_hub_idle";

			// Token: 0x04002E0F RID: 11791
			public const string SFX_BERT_HUB_CHUNK = "sfx_bert_hub_chunk";

			// Token: 0x04002E10 RID: 11792
			public const string SFX_BERT_BOSS_HEAD_REVEAL = "sfx_bert_boss_head_reveal";

			// Token: 0x04002E11 RID: 11793
			public const string SFX_BERT_ARM_DEBRIS = "sfx_bert_arm_debris";

			// Token: 0x04002E12 RID: 11794
			public const string AMB_HORROR_LOOP = "amb_horror_loop";

			// Token: 0x04002E13 RID: 11795
			public const string AMB_BENDY_LOOP = "amb_bendy_loop";

			// Token: 0x04002E14 RID: 11796
			public const string AMB_DEEP_LOOP = "amb_deep_loop";

			// Token: 0x04002E15 RID: 11797
			public const string AMB_AIRY_LOOP = "amb_airy_loop";

			// Token: 0x04002E16 RID: 11798
			public const string AMB_FLOOD_LOOP = "amb_flood_loop";

			// Token: 0x04002E17 RID: 11799
			public const string AMB_NOISY_LOOP = "amb_noisy_loop";

			// Token: 0x04002E18 RID: 11800
			public const string AMB_WIND_LOOP = "amb_wind_loop";

			// Token: 0x04002E19 RID: 11801
			public const string AMB_FLOOD_LOOP_DOCK = "amb_flood_loop_dock";

			// Token: 0x04002E1A RID: 11802
			public const string AMB_TUNNEL_LOOP_DOCK = "amb_tunnel_loop_dock";

			// Token: 0x04002E1B RID: 11803
			public const string AMB_CREEPY_SOUNDS_TUNNEL0 = "amb_creepy_sounds_tunnel (0)";

			// Token: 0x04002E1C RID: 11804
			public const string AMB_CREEPY_SOUNDS_TUNNEL1 = "amb_creepy_sounds_tunnel (1)";

			// Token: 0x04002E1D RID: 11805
			public const string AMB_CREEPY_SOUNDS_TUNNEL2 = "amb_creepy_sounds_tunnel (2)";

			// Token: 0x04002E1E RID: 11806
			public const string AMB_AIRY_LOOP_HARBOUR = "amb_airy_loop_harbour";

			// Token: 0x04002E1F RID: 11807
			public const string AMB_FLOOD_LOOP_HARBOUR = "amb_flood_loop_harbour";

			// Token: 0x04002E20 RID: 11808
			public const string AMB_NOISY_LOOP_HARBOUR = "amb_noisy_loop_harbour";

			// Token: 0x04002E21 RID: 11809
			public const string AMB_DEEP_LOOP_ABYSS = "amb_deep_loop_abyss";

			// Token: 0x04002E22 RID: 11810
			public const string AMB_FLOOD_LOOP_ABYSS = "amb_flood_loop_abyss";

			// Token: 0x04002E23 RID: 11811
			public const string AMB_INK_PIPE_BLEND_ABYSS = "amb_ink_pipe_blend_abyss";

			// Token: 0x04002E24 RID: 11812
			public const string AMB_SIDE_HALL_DUCK_ADMIN = "amb_side_hall_duck_admin";

			// Token: 0x04002E25 RID: 11813
			public const string AMB_DEEP_HOLLOW_BLEND_VAULT = "amb_deep_hollow_blend_vault";

			// Token: 0x04002E26 RID: 11814
			public const string AMB_MACHINE_WORKING_GIANT = "amb_machine_working_giant";

			// Token: 0x04002E27 RID: 11815
			public const string AMB_FLOOD_LOOP_GIANT = "amb_flood_loop_giant";

			// Token: 0x04002E28 RID: 11816
			public const string AMB_GIANT_INK_BAKE_LOOP = "amb_giant_ink_bake_loop";

			// Token: 0x04002E29 RID: 11817
			public const string AMB_DEEP_MACHINERY_LOOP_INTERIOR1 = "amb_deep_machinery_loop_interior (1)";

			// Token: 0x04002E2A RID: 11818
			public const string AMB_DEEP_LOOP_TOILET_BLEND = "amb_deep_loop_toilet_blend";

			// Token: 0x04002E2B RID: 11819
			public const string AMB_DRIPS_SAFE_TOILET = "amb_drips_safe_toilet";

			// Token: 0x04002E2C RID: 11820
			public const string AMB_TOILET_WATER_SAFEHOUSE = "amb_toilet_water_safehouse";

			// Token: 0x04002E2D RID: 11821
			public const string AMB_INK_PIPE_BUBBLES_SAFEHOUSE = "amb_ink_pipe_bubbles_safehouse";

			// Token: 0x04002E2E RID: 11822
			public const string AMB_INK_PIPE_LOOP_SAFEHOUSE = "amb_ink_pipe_loop_safehouse";

			// Token: 0x04002E2F RID: 11823
			public const string AMB_STONES_LIGHT_CAVES = "amb_stones_light_caves";

			// Token: 0x04002E30 RID: 11824
			public const string AMB_STONE_CRUMBLE_CAVES = "amb_stone_crumble_caves";

			// Token: 0x04002E31 RID: 11825
			public const string AMB_STONE_CRUMBLE_CAVES_ENTER = "amb_stone_crumble_caves_enter";

			// Token: 0x04002E32 RID: 11826
			public const string AMB_DRIPS_CAVES = "amb_drips_caves";

			// Token: 0x04002E33 RID: 11827
			public const string AMB_VENT_AIR_LOOP_CAVES = "amb_vent_air_loop_caves";

			// Token: 0x04002E34 RID: 11828
			public const string AMB_FLOOD_LOOP_CAVES = "amb_flood_loop_caves";

			// Token: 0x04002E35 RID: 11829
			public const string AMB_INK_PIPE_BUBBLES_CAVES = "amb_ink_pipe_bubbles_caves";

			// Token: 0x04002E36 RID: 11830
			public const string AMB_INK_PIPE_LOOP_CAVES = "amb_ink_pipe_loop_caves";

			// Token: 0x04002E37 RID: 11831
			public const string AMB_DEEP_LOOP_CAVES = "amb_deep_loop_caves";

			// Token: 0x04002E38 RID: 11832
			public const string AMB_CAGE_IDLE_MOVES_DOCK = "amb_cage_idle_moves_dock";

			// Token: 0x04002E39 RID: 11833
			public const string AMB_WOOD_DEEP_CREAK_DOCK = "amb_wood_deep_creak_dock";

			// Token: 0x04002E3A RID: 11834
			public const string AMB_LIGHT_FLICKER_DOCK = "amb_light_flicker_dock";

			// Token: 0x04002E3B RID: 11835
			public const string AMB_DRIPS_TUNNELS = "amb_drips_tunnels";

			// Token: 0x04002E3C RID: 11836
			public const string AMB_DRIPS_TUNNELS1 = "amb_drips_tunnels (1)";

			// Token: 0x04002E3D RID: 11837
			public const string AMB_METAL_IDLE_TUNNELS = "amb_metal_idle_tunnels";

			// Token: 0x04002E3E RID: 11838
			public const string AMB_CAGE_IDLE_MOVES_HARBOUR = "amb_cage_idle_moves_harbour";

			// Token: 0x04002E3F RID: 11839
			public const string AMB_RUMBLE_TONES_HARBOUR = "amb_rumble_tones_harbour";

			// Token: 0x04002E40 RID: 11840
			public const string AMB_WOOD_SMALL_HARBOUR = "amb_wood_small_harbour";

			// Token: 0x04002E41 RID: 11841
			public const string AMB_STONES_LIGHT_ABYSS = "amb_stones_light_abyss";

			// Token: 0x04002E42 RID: 11842
			public const string AMB_WOOD_DEEP_CREAK_ABYSS = "amb_wood_deep_creak_abyss";

			// Token: 0x04002E43 RID: 11843
			public const string AMB_LIGHT_FLICKER_ABYSS = "amb_light_flicker_abyss";

			// Token: 0x04002E44 RID: 11844
			public const string AMB_SWITCHES_ADMIN0 = "amb_switches_admin (0)";

			// Token: 0x04002E45 RID: 11845
			public const string AMB_BOOK_PAPERS_ADMIN0 = "amb_book_papers_admin (0)";

			// Token: 0x04002E46 RID: 11846
			public const string AMB_LIGHT_FLICKER_ADMIN = "amb_light_flicker_admin";

			// Token: 0x04002E47 RID: 11847
			public const string AMB_LIGHT_FLICKER_ADMIN1 = "amb_light_flicker_admin (1)";

			// Token: 0x04002E48 RID: 11848
			public const string AMB_SWITCHES_ADMIN1 = "amb_switches_admin (1)";

			// Token: 0x04002E49 RID: 11849
			public const string AMB_JOEY_DREW_LOGO_OFFICE = "amb_joey_drew_logo_office";

			// Token: 0x04002E4A RID: 11850
			public const string AMB_RUMBLE_OFFICE = "amb_rumble_office";

			// Token: 0x04002E4B RID: 11851
			public const string AMB_INK_PILLAR_OFFICE = "amb_ink_pillar_office";

			// Token: 0x04002E4C RID: 11852
			public const string AMB_METAL_IDLE_PUZZLE = "amb_metal_idle_puzzle";

			// Token: 0x04002E4D RID: 11853
			public const string AMB_FLOOD_LOOP_PUZZLE = "amb_flood_loop_puzzle";

			// Token: 0x04002E4E RID: 11854
			public const string AMB_SWITCHES_VAULT2 = "amb_switches_vault (2)";

			// Token: 0x04002E4F RID: 11855
			public const string AMB_BOOK_PAPERS_VAULT = "amb_book_papers_vault";

			// Token: 0x04002E50 RID: 11856
			public const string AMB_DEEP_HOLLOW_VAULT = "amb_deep_hollow_vault";

			// Token: 0x04002E51 RID: 11857
			public const string AMB_INK_PIPE_BUBBLES_VAULT = "amb_ink_pipe_bubbles_vault";

			// Token: 0x04002E52 RID: 11858
			public const string AMB_INK_PIPE_LOOP_VAULT = "amb_ink_pipe_loop_vault";

			// Token: 0x04002E53 RID: 11859
			public const string AMB_INK_PIPE_BUBBLES_VAULT1 = "amb_ink_pipe_bubbles_vault (1)";

			// Token: 0x04002E54 RID: 11860
			public const string AMB_INK_PIPE_LOOP_VAULT1 = "amb_ink_pipe_loop_vault (1)";

			// Token: 0x04002E55 RID: 11861
			public const string AMB_WOOD_SMALL_BACKHALL = "amb_wood_small_backhall";

			// Token: 0x04002E56 RID: 11862
			public const string AMB_ART_DESK_BACKHALL = "amb_art_desk_backhall";

			// Token: 0x04002E57 RID: 11863
			public const string AMB_ART_DESK_BACKHALL1 = "amb_art_desk_backhall (1)";

			// Token: 0x04002E58 RID: 11864
			public const string AMB_PROJECTOR_SPOT_LOOP_BACKHALL = "amb_projector_spot_loop_backhall";

			// Token: 0x04002E59 RID: 11865
			public const string AMB_INK_FEATURE_WATERFALL_GIANT = "amb_ink_feature_waterfall_giant";

			// Token: 0x04002E5A RID: 11866
			public const string AMB_DEEP_MACHINERY_LOOP_INTERIOR = "amb_deep_machinery_loop_interior";

			// Token: 0x04002E5B RID: 11867
			public const string AMB_INK_FLOWING_INTERIOR = "amb_ink_flowing_interior";

			// Token: 0x04002E5C RID: 11868
			public const string AMB_INK_FLOWING_INTERIOR1 = "amb_ink_flowing_interior (1)";

			// Token: 0x04002E5D RID: 11869
			public const string AMB_INK_FLOWING_INTERIOR2 = "amb_ink_flowing_interior (2)";

			// Token: 0x04002E5E RID: 11870
			public const string AMB_INK_FLOWING_INTERIOR3 = "amb_ink_flowing_interior (3)";

			// Token: 0x04002E5F RID: 11871
			public const string AMB_MACHINE_BUZZ_INTERIOR = "amb_machine_buzz_interior";

			// Token: 0x04002E60 RID: 11872
			public const string AMB_MACHINE_BUZZ_INTERIOR1 = "amb_machine_buzz_interior (1)";

			// Token: 0x04002E61 RID: 11873
			public const string AMB_MACHINE_BUZZ_INTERIOR2 = "amb_machine_buzz_interior (2)";

			// Token: 0x04002E62 RID: 11874
			public const string AMB_MACHINE_BUZZ_INTERIOR3 = "amb_machine_buzz_interior (3)";

			// Token: 0x04002E63 RID: 11875
			public const string AMB_MACHINE_BUZZ_INTERIOR4 = "amb_machine_buzz_interior (4)";

			// Token: 0x04002E64 RID: 11876
			public const string AMB_METAL_IDLE_THRONE = "amb_metal_idle_throne";

			// Token: 0x04002E65 RID: 11877
			public const string AMB_INK_FLOWING_THRONE = "amb_ink_flowing_throne";

			// Token: 0x04002E66 RID: 11878
			public const string AMB_INK_MOVES_THRONE = "amb_ink_moves_throne";

			// Token: 0x04002E67 RID: 11879
			public const string AMB_METAL_IDLE_ARENA = "amb_metal_idle_arena";

			// Token: 0x04002E68 RID: 11880
			public const string AMB_MACHINE_WORKING_ARENA = "amb_machine_working_arena";

			// Token: 0x04002E69 RID: 11881
			public const string AMB_MACHINE_BUZZ_ARENA = "amb_machine_buzz_arena";

			// Token: 0x04002E6A RID: 11882
			public const string SFX_SCENE07_ROCKS_CRUMBLE = "sfx_scene07_rocks_crumble";

			// Token: 0x04002E6B RID: 11883
			public const string SFX_SCENE07_STONES = "sfx_scene07_stones";

			// Token: 0x04002E6C RID: 11884
			public const string SFX_SCENE07_BENDY_HEARTBEAT = "sfx_scene07_bendy_heartbeat";

			// Token: 0x04002E6D RID: 11885
			public const string SFX_SCENE07_SHAKING_LOOP = "sfx_scene07_shaking_loop";

			// Token: 0x04002E6E RID: 11886
			public const string SFX_BOAT_IN_DISTANCE = "sfx_boat_in_distance";

			// Token: 0x04002E6F RID: 11887
			public const string SFX_BOAT_LAUNCH = "sfx_boat_launch";

			// Token: 0x04002E70 RID: 11888
			public const string SFX_CHUTEBRAKE_RELEASE_1 = "sfx_chutebrake_release_1";

			// Token: 0x04002E71 RID: 11889
			public const string SFX_CHUTEBRAKE_RELEASE_2 = "sfx_chutebrake_release_2";

			// Token: 0x04002E72 RID: 11890
			public const string SFX_CHUTEBRAKE_ENGAGE_1 = "sfx_chutebrake_engage_1";

			// Token: 0x04002E73 RID: 11891
			public const string SFX_CHUTEBRAKE_ENGAGE_2 = "sfx_chutebrake_engage_2";

			// Token: 0x04002E74 RID: 11892
			public const string SFX_CHUTE_SLIDE1 = "sfx_chute_slide1";

			// Token: 0x04002E75 RID: 11893
			public const string SFX_CHUTE_SLIDE2 = "sfx_chute_slide2";

			// Token: 0x04002E76 RID: 11894
			public const string SFX_ABYSS_FALL = "sfx_abyss_fall";

			// Token: 0x04002E77 RID: 11895
			public const string SFX_SAMMY_SMASH_APPEAR = "sfx_sammy_smash_appear";

			// Token: 0x04002E78 RID: 11896
			public const string SFX_INK_DRAINED_PUZZLE = "sfx_ink_drained_puzzle";

			// Token: 0x04002E79 RID: 11897
			public const string SFX_PIPE_PIECE_ADDED = "sfx_pipe_piece_added";

			// Token: 0x04002E7A RID: 11898
			public const string SFX_BEAST_REVEAL_ANIM = "sfx_beast_reveal_anim";

			// Token: 0x04002E7B RID: 11899
			public const string SFX_BEAST_DEATH_ANIM = "sfx_beast_death_anim";
		}
	}
}
