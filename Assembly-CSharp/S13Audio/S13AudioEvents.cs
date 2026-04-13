using System;
using UnityEngine;

namespace S13Audio
{
	// Token: 0x0200004B RID: 75
	public class S13AudioEvents : MonoBehaviour
	{
		// Token: 0x06000193 RID: 403 RVA: 0x0002679C File Offset: 0x0002499C
		private void Start()
		{
			if (this.am == null)
			{
				this.am = global::UnityEngine.Object.FindObjectOfType<S13AudioManager>();
				if (this.am == null)
				{
					Debug.LogError(base.name + ": S13AudioManager not found in scene.", base.gameObject);
				}
			}
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000267F4 File Offset: 0x000249F4
		private void evt_game_is_awake()
		{
			GameManager.Instance.AudioManager.AudioMixer.SetFloat("Master", 0f);
			GameManager.Instance.AudioManager.AudioMixer.SetFloat("Dialogue", 0f);
			GameManager.Instance.AudioManager.AudioMixer.SetFloat("Music", 0f);
			GameManager.Instance.AudioManager.AudioMixer.SetFloat("Effects", 0f);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0000316F File Offset: 0x0000136F
		private void evt_game_at_main_menu()
		{
			this.am.ToSnapshot("S13BaseMixer", "mxs_reset", 0f);
			this.am.ToSnapshot("TMGAudioMixer", "mxs_base", 0f);
		}

		// Token: 0x06000196 RID: 406 RVA: 0x00026880 File Offset: 0x00024A80
		private void evt_game_at_loading_chapter1()
		{
			this.am.LerpMixerProperty("S13BaseMixer", "S13MasterVolume", -80f, 0f, true);
			this.am.LerpMixerProperty("S13BaseMixer", "S13MasterVolume", 3f, 6f, true);
			this.am.UnloadAllSoundBanks();
			this.am.LoadSoundBank("CH1 Soundbank");
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000268E8 File Offset: 0x00024AE8
		private void evt_game_at_loading_chapter2()
		{
			this.am.LerpMixerProperty("S13BaseMixer", "S13MasterVolume", -80f, 0f, true);
			this.am.LerpMixerProperty("S13BaseMixer", "S13MasterVolume", 3f, 6f, true);
			this.am.UnloadAllSoundBanks();
			this.am.LoadSoundBank("CH2 Soundbank");
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00026950 File Offset: 0x00024B50
		private void evt_game_at_loading_chapter3()
		{
			this.am.LerpMixerProperty("S13BaseMixer", "S13MasterVolume", -80f, 0f, true);
			this.am.LerpMixerProperty("S13BaseMixer", "S13MasterVolume", 3f, 6f, true);
			this.am.UnloadAllSoundBanks();
			this.am.LoadSoundBank("CH3 Soundbank");
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000269B8 File Offset: 0x00024BB8
		private void evt_game_at_loading_chapter4()
		{
			this.am.LerpMixerProperty("S13BaseMixer", "S13MasterVolume", -80f, 0f, true);
			this.am.LerpMixerProperty("S13BaseMixer", "S13MasterVolume", 3f, 6f, true);
			this.am.UnloadAllSoundBanks();
			this.am.LoadSoundBank("CH4 Soundbank");
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00026A20 File Offset: 0x00024C20
		private void evt_game_at_loading_chapter5()
		{
			this.am.LerpMixerProperty("S13BaseMixer", "S13MasterVolume", -80f, 0f, true);
			this.am.LerpMixerProperty("S13BaseMixer", "S13MasterVolume", 3f, 6f, true);
			this.am.UnloadAllSoundBanks();
			this.am.LoadSoundBank("CH5 Soundbank");
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_game_at_chapter_titles()
		{
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_game_at_gameplay()
		{
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_game_at_new_objective()
		{
		}

		// Token: 0x0600019E RID: 414 RVA: 0x000031A5 File Offset: 0x000013A5
		private void evt_game_at_paused()
		{
			this.am.SetMixerProperty("S13BaseMixer", "S13MasterVolume", -80f);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000031C1 File Offset: 0x000013C1
		private void evt_game_at_resume()
		{
			this.am.SetMixerProperty("S13BaseMixer", "S13MasterVolume", 3f);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_game_at_quit_prompt()
		{
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000031DD File Offset: 0x000013DD
		private void evt_save_punchin()
		{
			this.am.PlayAudio("vo_henry_save");
			this.am.PlayAudio("sfx_save_bell");
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00026A88 File Offset: 0x00024C88
		private void evt_deathtunnel_start()
		{
			this.am.ToSnapshot("TMGAudioMixer", "mxs_death_tunnel", 0.5f);
			this.am.PlayAudio("sfx_death_tunnel_start_ink");
			this.am.PlayAudio("sfx_death_tunnel_start_lfe");
			this.am.PlayAudio("sfx_death_tunnel_loop");
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x000031FF File Offset: 0x000013FF
		private void evt_deathtunnel_stop()
		{
			this.am.ToSnapshot("TMGAudioMixer", "mxs_base", 2f);
			this.am.StopAudio("sfx_death_tunnel_loop", false);
			this.am.PlayAudio("sfx_death_tunnel_stop");
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000323C File Offset: 0x0000143C
		private void evt_horror_vision_start()
		{
			this.am.PlayAudio("sfx_horror_vision_start");
			this.am.PlayAudio("sfx_horror_vision_loop");
			this.am.PlayAudio("sfx_horror_voices_loop");
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00026AE0 File Offset: 0x00024CE0
		private void evt_horror_vision_stop()
		{
			this.am.StopAudio("sfx_horror_vision_start", false);
			this.am.StopAudio("sfx_horror_vision_loop", false);
			this.am.StopAudio("sfx_horror_voices_loop", false);
			this.am.PlayAudio("sfx_horror_vision_stop");
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000326E File Offset: 0x0000146E
		private void evt_miracle_station_enter()
		{
			this.am.ToSnapshot("S13BaseMixer", "mxs_CH0_inside_LMS", 2f);
			this.am.PlayAudio("sfx_lms_enter");
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000329A File Offset: 0x0000149A
		private void evt_miracle_station_exit()
		{
			this.am.ToSnapshot("S13BaseMixer", "mxs_reset", 1f);
			this.am.PlayAudio("sfx_lms_exit");
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000032C6 File Offset: 0x000014C6
		private void evt_valve_drains_ink()
		{
			this.am.PlayAudio("sfx_ink_valve_drain");
			this.am.PlayAudio("sfx_ink_vavle_blubs");
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_player_dead()
		{
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_player_respawned()
		{
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_screen_shake_start()
		{
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_screen_shake_stop()
		{
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000032E8 File Offset: 0x000014E8
		private void evt_ink_machine_passby_start()
		{
			this.am.PlayAudio("sfx_ink_machine_passby_loop", 3f);
		}

		// Token: 0x060001AE RID: 430 RVA: 0x000032FF File Offset: 0x000014FF
		private void evt_seeing_tool_on()
		{
			this.am.PlayAudio("sfx_seeing_tool_on");
			this.am.PlayAudio("sfx_seeing_tool_loop");
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00003321 File Offset: 0x00001521
		private void evt_seeing_tool_off()
		{
			this.am.StopAudio("sfx_seeing_tool_on", false);
			this.am.StopAudio("sfx_seeing_tool_loop", false);
			this.am.PlayAudio("sfx_seeing_tool_off");
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_new_test()
		{
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00003355 File Offset: 0x00001555
		private void evt_battery_pack_on()
		{
			this.am.PlayAudio("sfx_battery_start");
			this.am.PlayAudio("sfx_battery_loop");
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00026B30 File Offset: 0x00024D30
		private void evt_ink_machine_reveal_start()
		{
			this.am.PlayAudio("sfx_ink_machine_unlock");
			this.am.PlayAudio("sfx_ink_machine_moving_chains", 13f);
			this.am.PlayAudioDelayed("sfx_ink_machine_moving_loop", 6f);
			this.am.StopAudioDelayed("sfx_ink_machine_moving_loop", 19f, false);
			this.am.PlayAudioDelayed("sfx_ink_machine_stop", 19f);
			this.am.PlayAudio("amb_3gears_metal_barn");
			this.am.PlayAudio("amb_3gears_loop_barn");
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00003377 File Offset: 0x00001577
		private void evt_ink_machine_reveal_stop()
		{
			this.am.PlayAudio("amb_cage_idle_moves_left");
			this.am.PlayAudio("amb_cage_idle_moves_room");
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00026BC4 File Offset: 0x00024DC4
		private void evt_ink_pressure_restored()
		{
			this.oc.Play("InkPipes");
			this.am.PlayAudio("sfx_ink_heavy_flow_loop");
			this.am.PlayAudio("amb_tile_wall_mech_theatre");
			this.am.PlayAudio("sfx_ink_pipe_burst");
			this.am.PlayAudio("sfx_ink_pipe_flow");
			this.am.PlayAudio("sfx_ink_floor");
			this.am.PlayAudio("amb_tile_wall_mech_power1");
			this.am.PlayAudio("amb_tile_wall_mech_power2");
			this.oc.Stop("Theatre");
			this.am.StopAudio("amb_closeup_loop", false);
			this.am.ToSnapshot("PropsStatic", "ink_pumping", 2f);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00026C8C File Offset: 0x00024E8C
		private void evt_main_power_switch_activated()
		{
			this.am.PlayAudio("sfx_main_power_switched_on");
			this.am.PlayAudioDelayed("sfx_ink_machine_working_loop", 5f);
			this.am.ToSnapshot("S13BaseMixer", "mxs_CH1_main_power", 0f);
			this.am.InvokeEvent("evt_main_power_mix_reset", 6f);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00003399 File Offset: 0x00001599
		private void evt_main_power_mix_reset()
		{
			this.am.ToSnapshot("S13BaseMixer", "mxs_reset", 6f);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00026CF0 File Offset: 0x00024EF0
		private void evt_bendy_appears()
		{
			this.am.PlayAudio("sfx_ink_heavy_everywhere");
			this.am.ToSnapshot("S13BaseMixer", "mxs_reset", 0f);
			this.am.ToSnapshot("PropsStatic", "default", 1f);
			this.am.ToSnapshot("TMGAudioMixer", "mxs_bendy_overload", 4f);
			this.am.ToSnapshot("CH1Defaults", "mxs_running_away", 0f);
			this.oc.Enable("Stairwell");
			this.oc.Enable("Basement");
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x00026D98 File Offset: 0x00024F98
		private void evt_floor_caves_in()
		{
			this.am.PlayAudio("sfx_floor_cavein_mix");
			this.am.PlayAudio("sfx_ink_machine_working_finale");
			this.am.StopAudio("sfx_ink_machine_working_loop", false);
			this.am.StopAudio("sfx_ink_heavy_everywhere", false);
			this.am.ToSnapshot("TMGAudioMixer", "mxs_base", 0f);
			this.am.ToSnapshot("CH1Defaults", "mxs_base", 0.5f);
			this.oc.Destroy("MainRoom", true);
			this.oc.Destroy("DreamsHallway", true);
			this.oc.Destroy("LargeHallway", true);
			this.oc.Destroy("BorisRoom", true);
			this.oc.Destroy("PowerRoom", true);
			this.oc.Destroy("Theatre", true);
			this.oc.Destroy("InkBarn", true);
			this.oc.Destroy("ArtRoom", true);
			this.oc.Destroy("ArtBath", true);
			this.oc.Destroy("BreakRoom", true);
			this.oc.Destroy("InkPipes", true);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000033B5 File Offset: 0x000015B5
		private void evt_stairwell_valve1()
		{
			this.am.StopAudio("sfx_valve1_ink_flood", false);
			this.am.InvokeEvent("evt_valve_drains_ink", 1f);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x000033DD File Offset: 0x000015DD
		private void evt_stairwell_valve2()
		{
			this.am.StopAudio("sfx_valve2_ink_flood", false);
			this.am.InvokeEvent("evt_valve_drains_ink", 1f);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x00003405 File Offset: 0x00001605
		private void evt_stairwell_valve3()
		{
			this.am.StopAudio("sfx_valve3_ink_flood", false);
			this.am.InvokeEvent("evt_valve_drains_ink", 1f);
			this.am.StopAudio("sfx_ink_machine_working_finale", false);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0000343E File Offset: 0x0000163E
		private void evt_bendy_finale_scare()
		{
			this.am.StopAllAudio(false);
			this.am.ToSnapshot("TMGAudioMixer", "mxs_bendy_overload", 0f);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00026ED8 File Offset: 0x000250D8
		private void evt_CH1_save_point_01()
		{
			this.am.PlayAudio("amb_3gears_metal_barn");
			this.am.PlayAudio("amb_3gears_loop_barn");
			this.am.PlayAudio("amb_cage_idle_moves_left");
			this.am.PlayAudio("amb_cage_idle_moves_room");
			this.am.PlayAudio("sfx_battery_loop");
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00026F38 File Offset: 0x00025138
		private void evt_CH1_save_point_03()
		{
			this.evt_CH1_save_point_01();
			this.oc.Stop("Theatre");
			this.am.StopAudio("amb_closeup_loop", false);
			this.am.PlayAudio("sfx_ink_heavy_flow_loop");
			this.am.PlayAudio("amb_tile_wall_mech_theatre");
			this.am.PlayAudio("sfx_ink_floor");
			this.am.PlayAudio("amb_tile_wall_mech_power1");
			this.am.PlayAudio("amb_tile_wall_mech_power2");
			this.am.ToSnapshot("PropsStatic", "ink_pumping", 2f);
			this.oc.Play("InkPipes");
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00003466 File Offset: 0x00001666
		private void evt_CH1_save_point_04()
		{
			this.evt_CH1_save_point_03();
			this.am.PlayAudio("sfx_ink_machine_working_loop");
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00026FE8 File Offset: 0x000251E8
		private void evt_CH1_save_point_05()
		{
			this.am.ToSnapshot("S13BaseMixer", "mxs_reset", 0f);
			this.am.ToSnapshot("PropsStatic", "default", 0f);
			this.oc.Destroy("MainRoom", true);
			this.oc.Destroy("DreamsHallway", true);
			this.oc.Destroy("LargeHallway", true);
			this.oc.Destroy("BorisRoom", true);
			this.oc.Destroy("PowerRoom", true);
			this.oc.Destroy("Theatre", true);
			this.oc.Destroy("InkBarn", true);
			this.oc.Destroy("ArtRoom", true);
			this.oc.Destroy("ArtBath", true);
			this.oc.Destroy("BreakRoom", true);
			this.am.PlayAudio("sfx_ink_machine_working_finale");
			this.am.PlayAudio("amb_original_bendy_loop");
			this.am.StopAudio("sfx_ink_machine_working_loop", false);
			this.am.StopAudio("amb_tile_wall_mech_power1", false);
			this.am.StopAudio("amb_tile_wall_mech_power2", false);
			this.oc.Enable("Stairwell");
			this.oc.Enable("Basement");
			this.oc.Play("Stairwell");
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00027158 File Offset: 0x00025358
		private void evt_CH1_save_point_06()
		{
			this.evt_CH1_save_point_05();
			this.oc.Play("Stairwell");
			this.am.StopAudio("sfx_valve1_ink_flood", false);
			this.am.StopAudio("sfx_valve2_ink_flood", false);
			this.am.StopAudio("sfx_valve3_ink_flood", false);
			this.am.StopAudio("sfx_ink_machine_working_finale", false);
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000347E File Offset: 0x0000167E
		private void evt_main_room_enter()
		{
			this.oc.Play("MainRoom");
			this.am.PlayAudio("amb_original_horror_loop");
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000034A0 File Offset: 0x000016A0
		private void evt_main_room_exit()
		{
			this.oc.Stop("MainRoom");
			this.am.StopAudio("amb_original_horror_loop", false);
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x000034C3 File Offset: 0x000016C3
		private void evt_dreams_hallway_enter()
		{
			this.oc.Play("DreamsHallway");
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x000034D5 File Offset: 0x000016D5
		private void evt_dreams_hallway_exit()
		{
			this.oc.Stop("DreamsHallway");
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x000034E7 File Offset: 0x000016E7
		private void evt_large_hallway_enter()
		{
			this.oc.Play("LargeHallway");
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x000034F9 File Offset: 0x000016F9
		private void evt_large_hallway_exit()
		{
			this.oc.Stop("LargeHallway");
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000350B File Offset: 0x0000170B
		private void evt_boris_room_enter()
		{
			this.oc.Play("BorisRoom");
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000351D File Offset: 0x0000171D
		private void evt_boris_room_exit()
		{
			this.oc.Stop("BorisRoom");
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000352F File Offset: 0x0000172F
		private void evt_boris_rumbletrap_enter()
		{
			this.am.ToSnapshot("CH1 Ambience by Section", "mxs_boris_rumble", 1f);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000354B File Offset: 0x0000174B
		private void evt_boris_rumbletrap_exit()
		{
			this.am.ToSnapshot("CH1 Ambience by Section", "mxs_base", 1f);
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00003567 File Offset: 0x00001767
		private void evt_power_room_enter()
		{
			this.oc.Play("PowerRoom");
			this.am.PlayAudio("amb_industrial_loop");
			this.am.StopAudio("amb_original_horror_loop", false);
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0000359A File Offset: 0x0000179A
		private void evt_power_room_exit()
		{
			this.am.PlayAudio("amb_original_horror_loop");
			this.oc.Stop("PowerRoom");
			this.am.StopAudio("amb_industrial_loop", false);
		}

		// Token: 0x060001CE RID: 462 RVA: 0x000035CD File Offset: 0x000017CD
		private void evt_theatre_enter()
		{
			this.oc.Play("Theatre");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.StopAudio("amb_original_horror_loop", false);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00003600 File Offset: 0x00001800
		private void evt_theatre_exit()
		{
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.StopAudio("amb_closeup_loop", false);
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00003623 File Offset: 0x00001823
		private void evt_theatre_mixtrap_ink_enter()
		{
			this.am.ToSnapshot("CH1ScriptedEvents", "Theatre", 0.5f);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x0000363F File Offset: 0x0000183F
		private void evt_theatre_mixtrap_ink_exit()
		{
			this.am.ToSnapshot("CH1ScriptedEvents", "Base", 4f);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000365B File Offset: 0x0000185B
		private void evt_ink_barn_enter()
		{
			this.am.PlayAudio("amb_airy_outdoor");
			this.am.StopAudio("amb_original_horror_loop", false);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000367E File Offset: 0x0000187E
		private void evt_ink_barn_exit()
		{
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.StopAudio("amb_airy_outdoor", false);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x000036A1 File Offset: 0x000018A1
		private void evt_art_room_enter()
		{
			this.oc.Play("ArtRoom");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.StopAudio("amb_original_horror_loop", false);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x000036D4 File Offset: 0x000018D4
		private void evt_art_room_exit()
		{
			this.am.PlayAudio("amb_original_horror_loop");
			this.oc.Stop("ArtRoom");
			this.am.StopAudio("amb_closeup_loop", false);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00003707 File Offset: 0x00001907
		private void evt_art_bath_enter()
		{
			this.oc.Play("ArtBath");
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00003719 File Offset: 0x00001919
		private void evt_art_bath_exit()
		{
			this.oc.Stop("ArtBath");
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x0000372B File Offset: 0x0000192B
		private void evt_break_room_enter()
		{
			this.oc.Play("BreakRoom");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.StopAudio("amb_original_horror_loop", false);
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000375E File Offset: 0x0000195E
		private void evt_break_room_exit()
		{
			this.am.PlayAudio("amb_original_horror_loop");
			this.oc.Stop("BreakRoom");
			this.am.StopAudio("amb_closeup_loop", false);
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00003791 File Offset: 0x00001991
		private void evt_stairwell_enter()
		{
			this.oc.Play("Stairwell");
			this.am.PlayAudio("amb_original_bendy_loop");
		}

		// Token: 0x060001DB RID: 475 RVA: 0x000037B3 File Offset: 0x000019B3
		private void evt_basement_final_enter()
		{
			this.oc.Play("Basement");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.StopAudio("amb_original_bendy_loop", false);
		}

		// Token: 0x060001DC RID: 476 RVA: 0x000037E6 File Offset: 0x000019E6
		private void evt_basement_final_exit()
		{
			this.am.PlayAudio("amb_original_bendy_loop");
			this.am.StopAudio("amb_closeup_loop", false);
		}

		// Token: 0x060001DD RID: 477 RVA: 0x00003809 File Offset: 0x00001A09
		private void evt_enter_music_department()
		{
			this.am.PlayAudio("sfx_gate_pipe", 4f);
			this.am.PlayAudio("sfx_gate_metal_rolling_open");
			this.am.PlayAudio("sfx_gate_rumble");
		}

		// Token: 0x060001DE RID: 478 RVA: 0x00003840 File Offset: 0x00001A40
		private void evt_ch2_dept_ink_blob_fall()
		{
			this.am.PlayAudio("sfx_ink_blob_fall");
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00003852 File Offset: 0x00001A52
		private void evt_ch2_dept_ink_blob_land()
		{
			this.am.PlayAudio("sfx_ink_blob_land");
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00003864 File Offset: 0x00001A64
		private void evt_office_stairs_ink_drained()
		{
			this.oc.Destroy("OfficeFlood", true);
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00003877 File Offset: 0x00001A77
		private void evt_office_door_ink_drained()
		{
			this.oc.Destroy("OfficeInk", true);
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x000271C0 File Offset: 0x000253C0
		private void evt_office_lever_thrown()
		{
			this.am.InvokeEvent("evt_valve_drains_ink", 1f);
			this.am.PlayAudio("sfx_pump_control_bangs", 6f);
			this.am.PlayAudio("sfx_pump_control_more", 6f);
			this.am.PlayAudio("sfx_pump_control_switched_on");
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000388A File Offset: 0x00001A8A
		private void evt_sammy_knocks_out_player()
		{
			this.am.PlayAudio("m_sammy_revealed");
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0002721C File Offset: 0x0002541C
		private void evt_sewer_puzzle_winch_up_start()
		{
			this.am.PlayAudio("sfx_sewer_puzzle_winch_up_start");
			this.am.PlayAudio("sfx_sewer_puzzle_winch_up_start2");
			this.am.PlayAudioDelayed("sfx_sewer_puzzle_winch_up_stop", 7.5f);
			this.am.StopAudioDelayed("sfx_sewer_puzzle_winch_up_start", 8f, false);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0000389C File Offset: 0x00001A9C
		private void evt_sewer_puzzle_winch_down()
		{
			this.am.PlayAudio("sfx_sewer_puzzle_winch_down");
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_CH2_save_point_01()
		{
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_CH2_save_point_02()
		{
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_CH2_save_point_03()
		{
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_CH2_save_point_04()
		{
		}

		// Token: 0x060001EA RID: 490 RVA: 0x000038AE File Offset: 0x00001AAE
		private void evt_CH2_save_point_05()
		{
			this.evt_musicdepartment_exit();
			this.evt_sammyoffice_enter_from_dept();
		}

		// Token: 0x060001EB RID: 491 RVA: 0x000038BC File Offset: 0x00001ABC
		private void evt_CH2_save_point_06()
		{
			this.evt_sammyoffice_exit_to_dept();
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_CH2_save_point_07()
		{
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000038C4 File Offset: 0x00001AC4
		private void evt_CH2_save_point_08()
		{
			this.evt_sammyoffice_enter_from_dept();
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_CH2_save_point_09()
		{
		}

		// Token: 0x060001EF RID: 495 RVA: 0x000038CC File Offset: 0x00001ACC
		private void evt_CH2_save_point_10()
		{
			this.evt_office_door_ink_drained();
			this.evt_sewers_exit();
			this.evt_sammyoffice_enter_from_dept();
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_CH2_save_point_11()
		{
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_CH2_save_point_12()
		{
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_CH2_save_point_13()
		{
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x000038E0 File Offset: 0x00001AE0
		private void evt_ch2_opening_enter()
		{
			this.oc.Play("Opening");
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x000038F2 File Offset: 0x00001AF2
		private void evt_ch2_opening_exit()
		{
			this.oc.Stop("Opening");
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00003904 File Offset: 0x00001B04
		private void evt_ch2_opening_loops_enter()
		{
			this.am.ToSnapshot("CH2Defaults", "Opening", 0.5f);
			this.am.PlayAudio("amb_original_bendy_loop");
			this.am.PlayAudio("amb_closeup_loop");
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00003940 File Offset: 0x00001B40
		private void evt_ch2_opening_loops_exit()
		{
			this.am.StopAudio("amb_original_bendy_loop", false);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00003953 File Offset: 0x00001B53
		private void evt_sammyhallway_enter()
		{
			this.oc.Play("SammyHallway");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.ToSnapshot("CH2Defaults", "Opening", 0.5f);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000398F File Offset: 0x00001B8F
		private void evt_sammyhallway_exit()
		{
			this.oc.Stop("SammyHallway");
			this.am.StopAudio("amb_original_bendy_loop", false);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00027274 File Offset: 0x00025474
		private void evt_musicdepartment_enter()
		{
			this.oc.Play("MusicDepartment");
			this.am.PlayAudio("amb_industrial_loop_studio");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.ToSnapshot("CH2Defaults", "MusicDepartment", 2f);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x000039B2 File Offset: 0x00001BB2
		private void evt_musicdepartment_exit()
		{
			this.oc.Stop("MusicDepartment");
			this.am.StopAudio("amb_industrial_loop_studio", false);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000039D5 File Offset: 0x00001BD5
		private void evt_music_ink_enter()
		{
			this.am.PlayAudio("amb_water_flooded_loop_stairs");
			this.am.ToSnapshot("CH2 Ambience by Section", "mxs_sammy_ink", 1f);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00003A01 File Offset: 0x00001C01
		private void evt_music_ink_exit()
		{
			this.am.StopAudio("amb_water_flooded_loop_stairs", false);
			this.am.ToSnapshot("CH2 Ambience by Section", "mxs_default", 1f);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000272CC File Offset: 0x000254CC
		private void evt_recordingstudio_enter()
		{
			this.oc.Play("RecordingStudio");
			this.am.ToSnapshot("CH2Defaults", "RecordingStudio", 2f);
			this.am.ToSnapshot("PropsStatic", "default", 1f);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00003A2E File Offset: 0x00001C2E
		private void evt_recordingstudio_exit()
		{
			this.oc.Stop("RecordingStudio");
			this.am.ToSnapshot("CH2Defaults", "MusicDepartment", 2f);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00003A5A File Offset: 0x00001C5A
		private void evt_recordingstudio_balcony_enter()
		{
			this.am.PlayAudio("amb_industrial_loop_balcony");
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00003A6C File Offset: 0x00001C6C
		private void evt_recordingstudio_balcony_exit()
		{
			this.am.StopAudio("amb_industrial_loop_balcony", false);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00027320 File Offset: 0x00025520
		private void evt_secretroom_enter()
		{
			this.oc.Play("SecretRoom");
			this.am.PlayAudio("amb_original_bendy_loop");
			this.am.ToSnapshot("PropsStatic", "ink_pumping", 1f);
			this.am.ToSnapshot("CH2Defaults", "SecretSideRoom", 0.1f);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00027384 File Offset: 0x00025584
		private void evt_secretroom_exit()
		{
			this.oc.Stop("SecretRoom");
			this.am.StopAudio("amb_original_bendy_loop", false);
			this.am.ToSnapshot("PropsStatic", "default", 1f);
			this.am.ToSnapshot("CH2Defaults", "RecordingStudio", 0.1f);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00003A7F File Offset: 0x00001C7F
		private void evt_office_ink_enter()
		{
			this.oc.Play("OfficeFlood");
			this.am.ToSnapshot("CH2 Ambience by Section", "mxs_sammy_ink", 1f);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00003AAB File Offset: 0x00001CAB
		private void evt_office_ink_exit()
		{
			this.oc.Stop("OfficeFlood");
			this.am.ToSnapshot("CH2 Ambience by Section", "mxs_default", 3f);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x000273E8 File Offset: 0x000255E8
		private void evt_sammyoffice_enter_from_dept()
		{
			this.oc.Play("SammyOffice");
			this.oc.Play("OfficeInk");
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.PlayAudio("amb_heavy_loop");
			this.am.ToSnapshot("CH2Defaults", "Office", 2f);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00027450 File Offset: 0x00025650
		private void evt_sammyoffice_exit_to_dept()
		{
			this.oc.Stop("SammyOffice");
			this.oc.Stop("OfficeInk");
			this.am.StopAudio("amb_original_horror_loop", false);
			this.am.StopAudio("amb_heavy_loop", false);
			this.am.ToSnapshot("CH2Defaults", "MusicDepartment", 2f);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x000274BC File Offset: 0x000256BC
		private void evt_sammyoffice_enter_from_infirmary()
		{
			this.oc.Play("SammyOffice");
			this.oc.Play("OfficeInk");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.ToSnapshot("CH2Defaults", "Office", 2f);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00003AD7 File Offset: 0x00001CD7
		private void evt_sammyoffice_exit_to_infirmary()
		{
			this.oc.Stop("SammyOffice");
			this.oc.Stop("OfficeInk");
			this.am.StopAudio("amb_closeup_loop", false);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00027514 File Offset: 0x00025714
		private void evt_infirmary_enter()
		{
			this.oc.Play("Infirmary");
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.PlayAudio("amb_heavy_loop");
			this.am.PlayAudio("amb_industrial_loop");
			this.am.StopAudio("amb_closeup_loop", false);
			this.am.ToSnapshot("CH2Defaults", "Infirmary", 3f);
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00003B0A File Offset: 0x00001D0A
		private void evt_infirmary_exit()
		{
			this.oc.Stop("Infirmary");
			this.am.StopAudio("amb_industrial_loop", false);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00003B2D File Offset: 0x00001D2D
		private void evt_sewers_enter()
		{
			this.oc.Play("Sewers");
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.ToSnapshot("CH2Defaults", "Horror", 3f);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00003B69 File Offset: 0x00001D69
		private void evt_sewers_exit()
		{
			this.oc.Stop("Sewers");
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0002758C File Offset: 0x0002578C
		private void evt_machineroom_enter()
		{
			this.oc.Play("MachineRoom");
			this.am.PlayAudio("amb_industrial_loop");
			this.am.PlayAudio("amb_heavy_loop");
			this.am.ToSnapshot("CH2Defaults", "MachineRoom", 1f);
			this.am.ToSnapshot("Sewers", "MachineRoom", 1f);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00027600 File Offset: 0x00025800
		private void evt_machineroom_exit()
		{
			this.oc.Stop("MachineRoom");
			this.am.StopAudio("amb_industrial_loop", false);
			this.am.ToSnapshot("CH2Defaults", "Horror", 3f);
			this.am.ToSnapshot("Sewers", "Base", 1f);
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00027664 File Offset: 0x00025864
		private void evt_sacrifice_enter()
		{
			this.oc.Play("Sacrifice");
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_heavy_loop");
			this.am.ToSnapshot("CH2Defaults", "Office", 1f);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00003B7B File Offset: 0x00001D7B
		private void evt_sacrifice_exit()
		{
			this.oc.Stop("Sacrifice");
			this.am.StopAudio("amb_original_horror_loop", false);
			this.am.StopAudio("amb_closeup_loop", false);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00003BAF File Offset: 0x00001DAF
		private void evt_bendychase_enter()
		{
			this.oc.Play("BendyChase");
			this.am.PlayAudio("amb_heavy_loop");
			this.am.ToSnapshot("CH2Defaults", "Heavy", 2f);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00003BEB File Offset: 0x00001DEB
		private void evt_bendychase_exit()
		{
			this.oc.Stop("BendyChase");
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00003BFD File Offset: 0x00001DFD
		private void evt_borisreveal_enter()
		{
			this.oc.Play("BorisReveal");
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.ToSnapshot("CH2Defaults", "Horror", 2f);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00003C39 File Offset: 0x00001E39
		private void evt_borisreveal_exit()
		{
			this.oc.Stop("BorisReveal");
			this.am.StopAudio("amb_original_horror_loop", false);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x00003C5C File Offset: 0x00001E5C
		private void evt_safehouse_closed()
		{
			this.oc.Destroy("SafeHouse", true);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_darkhallway_closed()
		{
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00003C6F File Offset: 0x00001E6F
		private void evt_activate_workshop_mech_right()
		{
			this.oc.Enable("Workshop_Mech_Right");
			this.oc.Play("Workshop_Mech_Right");
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00003C91 File Offset: 0x00001E91
		private void evt_activate_workshop_mech_left()
		{
			this.oc.Enable("Workshop_Mech_Left");
			this.oc.Play("Workshop_Mech_Left");
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00003CB3 File Offset: 0x00001EB3
		private void evt_toys_found1()
		{
			this.am.ToSnapshot("CH3Workshop", "1Active", 2f);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00003CCF File Offset: 0x00001ECF
		private void evt_toys_found2()
		{
			this.am.ToSnapshot("CH3Workshop", "2Active", 2f);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00003CEB File Offset: 0x00001EEB
		private void evt_toys_found3()
		{
			this.am.ToSnapshot("CH3Workshop", "3Active", 2f);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00003D07 File Offset: 0x00001F07
		private void evt_toys_found4()
		{
			this.am.ToSnapshot("CH3Workshop", "AllActive", 2f);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00003D23 File Offset: 0x00001F23
		private void evt_alice_reveal_start()
		{
			this.oc.Stop("AliceReveal");
			this.am.StopAudio("amb_original_bendy_loop", false);
			this.am.ToSnapshot("TMGAudioMixer", "mxs_alice_monologues", 1f);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00003D60 File Offset: 0x00001F60
		private void evt_alice_reveal_complete()
		{
			this.oc.Play("AliceReveal");
			this.am.PlayAudio("amb_original_bendy_loop");
			this.am.ToSnapshot("TMGAudioMixer", "mxs_base", 1f);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_elevator_start()
		{
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_elevator_stop()
		{
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00003D9C File Offset: 0x00001F9C
		private void evt_ch3_secret_flood_empty()
		{
			this.oc.Destroy("Level_P_flood", true);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000276CC File Offset: 0x000258CC
		private void evt_safehouse_enter()
		{
			this.oc.Play("SafeHouse");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_heavy_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_safehouse", 1f);
			this.am.ToSnapshot("S13BaseMixer", "mxs_reverb_tiny", 0.5f);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00003DAF File Offset: 0x00001FAF
		private void evt_safehouse_exit()
		{
			this.oc.Stop("SafeHouse");
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00027740 File Offset: 0x00025940
		private void evt_darkhallway_enter()
		{
			this.oc.Play("DarkHallway");
			this.am.ToSnapshot("CH3Defaults", "mxs_darkhallway", 1f);
			this.oc.Enable("HeavenlyToys");
			this.oc.Enable("Workshop");
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00003DC1 File Offset: 0x00001FC1
		private void evt_darkhallway_exit()
		{
			this.oc.Stop("DarkHallway");
			this.am.StopAudio("amb_closeup_loop", false);
			this.am.StopAudio("amb_heavy_loop", false);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00027798 File Offset: 0x00025998
		private void evt_heavenlytoys_enter()
		{
			this.oc.Play("HeavenlyToys");
			this.am.PlayAudio("amb_airy_outdoor");
			this.am.ToSnapshot("CH3Defaults", "mxs_heavenlytoys", 3f);
			this.oc.Destroy("SafeHouse", true);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00003DF5 File Offset: 0x00001FF5
		private void evt_heavenlytoys_exit()
		{
			this.oc.Stop("HeavenlyToys");
			this.am.StopAudio("amb_airy_outdoor", false);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00003E18 File Offset: 0x00002018
		private void evt_workshop_enter()
		{
			this.oc.Play("Workshop");
			this.am.ToSnapshot("CH3Defaults", "mxs_workshop", 2f);
			this.oc.Enable("AliceReveal");
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00003E54 File Offset: 0x00002054
		private void evt_workshop_exit()
		{
			this.oc.Stop("Workshop");
			this.am.ToSnapshot("CH3Defaults", "mxs_heavenlytoys", 1f);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000277F0 File Offset: 0x000259F0
		private void evt_alicereveal_enter()
		{
			this.am.PlayAudio("amb_original_bendy_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_alicereveal", 2f);
			this.am.ToSnapshot("S13BaseMixer", "mxs_reset", 0.5f);
			this.oc.Enable("ChoicesHallways");
			this.oc.Enable("ChoicesDevil");
			this.oc.Enable("ChoicesAngel");
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00003E80 File Offset: 0x00002080
		private void evt_alicereveal_exit()
		{
			this.am.StopAudio("amb_original_bendy_loop", false);
			this.am.ToSnapshot("S13BaseMixer", "mxs_reverb_corridor", 0.5f);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00027874 File Offset: 0x00025A74
		private void evt_choices_enter()
		{
			this.oc.Play("ChoicesHallways");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_choices", 2.5f);
			this.oc.Enable("LiftHallways");
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00003EAD File Offset: 0x000020AD
		private void evt_choices_exit()
		{
			this.oc.Stop("ChoicesHallways");
			this.am.StopAudio("amb_closeup_loop", false);
			this.am.StopAudio("amb_original_horror_loop", false);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00003EE1 File Offset: 0x000020E1
		private void evt_choices_devil_enter()
		{
			this.oc.Play("ChoicesDevil");
			this.oc.Destroy("ChoicesAngel", true);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00003F04 File Offset: 0x00002104
		private void evt_choices_devil_exit()
		{
			this.oc.Stop("ChoicesDevil");
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00003F16 File Offset: 0x00002116
		private void evt_choices_angel_enter()
		{
			this.oc.Play("ChoicesAngel");
			this.oc.Destroy("ChoicesDevil", true);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00003F39 File Offset: 0x00002139
		private void evt_choices_angel_exit()
		{
			this.oc.Stop("ChoicesAngel");
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000278DC File Offset: 0x00025ADC
		private void evt_from_choices_to_lift()
		{
			this.oc.Stop("ChoicesHallways");
			this.am.StopAudio("amb_closeup_loop", false);
			this.evt_lift_hallways_enter();
			this.oc.Enable("TrailerRoom");
			this.oc.Enable("LiftMain1");
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00003F4B File Offset: 0x0000214B
		private void evt_from_lift_to_choices()
		{
			this.oc.Stop("LiftHallways");
			this.evt_choices_enter();
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00003F63 File Offset: 0x00002163
		private void evt_lift_hallways_enter()
		{
			this.oc.Play("LiftHallways");
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_lift_halls", 2.5f);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00003F9F File Offset: 0x0000219F
		private void evt_lift_hallways_exit()
		{
			this.oc.Stop("LiftHallways");
			this.am.StopAudio("amb_original_horror_loop", false);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00003FC2 File Offset: 0x000021C2
		private void evt_trailerroom_enter()
		{
			this.oc.Play("TrailerRoom");
			this.am.PlayAudio("amb_original_bendy_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_trailer", 0.5f);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00003FFE File Offset: 0x000021FE
		private void evt_trailerroom_exit()
		{
			this.oc.Stop("TrailerRoom");
			this.am.StopAudio("amb_original_bendy_loop", false);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00027930 File Offset: 0x00025B30
		private void evt_lift_main1_enter()
		{
			this.oc.Play("LiftMain1");
			this.am.PlayAudio("amb_original_bendy_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_lift_main1", 1.5f);
			this.am.ToSnapshot("S13BaseMixer", "mxs_reverb_large", 0.5f);
			this.oc.Enable("LiftShaft");
			this.oc.Enable("Stairwell");
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00004021 File Offset: 0x00002221
		private void evt_lift_main1_exit()
		{
			this.oc.Stop("LiftMain1");
			this.am.StopAudio("amb_original_bendy_loop", false);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000279B4 File Offset: 0x00025BB4
		private void evt_floor2_enter()
		{
			this.oc.Play("Level_11");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_original_bendy_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_level_11", 0.5f);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00004044 File Offset: 0x00002244
		private void evt_floor2_exit()
		{
			this.oc.Stop("Level_11");
			this.am.StopAudio("amb_closeup_loop", false);
			this.am.StopAudio("amb_original_bendy_loop", false);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00027A0C File Offset: 0x00025C0C
		private void evt_floor3_enter()
		{
			this.oc.Play("Level_P");
			this.am.PlayAudio("amb_industrial_loop");
			this.am.PlayAudio("amb_original_bendy_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_level_p", 0.5f);
			this.am.ToSnapshot("S13BaseMixer", "mxs_reset", 0.5f);
			this.oc.Enable("Level_P_Lab");
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00027A90 File Offset: 0x00025C90
		private void evt_floor3_exit()
		{
			this.oc.Stop("Level_P");
			this.am.StopAudio("amb_industrial_loop", false);
			this.am.StopAudio("amb_original_bendy_loop", false);
			this.oc.Disable("Level_P_Lab");
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00027AE0 File Offset: 0x00025CE0
		private void evt_floor3_lab1_enter()
		{
			this.oc.Play("Level_P_Lab");
			this.am.ToSnapshot("CH3Defaults", "mxs_level_p_lab", 2f);
			this.am.ToSnapshot("S13BaseMixer", "mxs_reverb_corridor", 0.5f);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00027B34 File Offset: 0x00025D34
		private void evt_floor3_lab1_exit()
		{
			this.oc.Stop("Level_P_Lab");
			this.am.ToSnapshot("CH3Defaults", "mxs_level_p", 0.5f);
			this.am.ToSnapshot("S13BaseMixer", "mxs_reset", 0.5f);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00004078 File Offset: 0x00002278
		private void evt_floor3_lab2_enter()
		{
			this.am.ToSnapshot("CH3Defaults", "mxs_level_p_lab", 2f);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00004094 File Offset: 0x00002294
		private void evt_floor3_lab2_exit()
		{
			this.am.ToSnapshot("CH3Defaults", "mxs_level_p", 0.5f);
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00027B88 File Offset: 0x00025D88
		private void evt_floor4_enter()
		{
			this.oc.Play("Main");
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.PlayAudio("amb_heavy_loop");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_level_9", 0.5f);
			this.oc.Enable("Hallway");
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00027C00 File Offset: 0x00025E00
		private void evt_floor4_exit()
		{
			this.oc.Stop("Main");
			this.am.StopAudio("amb_original_horror_loop", false);
			this.am.StopAudio("amb_heavy_loop", false);
			this.am.StopAudio("amb_closeup_loop", false);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00027C50 File Offset: 0x00025E50
		private void evt_floor4_hall_enter()
		{
			this.oc.Play("Hallway");
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.PlayAudio("amb_heavy_loop");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_level_9_hall", 0.5f);
			this.oc.Enable("AlicesLair");
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000040B0 File Offset: 0x000022B0
		private void evt_floor4_hall_exit()
		{
			this.oc.Stop("Hallway");
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00027CC8 File Offset: 0x00025EC8
		private void evt_aliceslair_enter()
		{
			this.oc.Play("AlicesLair");
			this.am.PlayAudio("amb_ink_flood_loop");
			this.am.PlayAudio("amb_industrial_loop");
			this.am.StopAudio("amb_heavy_loop", false);
			this.am.StopAudio("amb_closeup_loop", false);
			this.am.ToSnapshot("CH3Defaults", "mxs_level_9_alice", 0.5f);
			this.oc.Enable("TortureRoom");
		}

		// Token: 0x06000247 RID: 583 RVA: 0x000040C2 File Offset: 0x000022C2
		private void evt_aliceslair_exit()
		{
			this.oc.Stop("AlicesLair");
			this.am.StopAudio("amb_ink_flood_loop", false);
			this.am.StopAudio("amb_industrial_loop", false);
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00027D54 File Offset: 0x00025F54
		private void evt_tortureroom_enter()
		{
			this.oc.Play("TortureRoom");
			this.am.PlayAudio("amb_heavy_loop");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_level_9_torture", 0.5f);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x000040F6 File Offset: 0x000022F6
		private void evt_tortureroom_exit()
		{
			this.oc.Stop("TortureRoom");
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00027DAC File Offset: 0x00025FAC
		private void evt_floor5_common_enter()
		{
			this.oc.Play("Level_14_Common");
			this.oc.Enable("Level_14_Main");
			this.oc.Enable("InkFlood");
			this.oc.Enable("Labyrinth");
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00004108 File Offset: 0x00002308
		private void evt_floor5_common_exit()
		{
			this.oc.Stop("Level_14_Common");
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000411A File Offset: 0x0000231A
		private void evt_floor5_enter()
		{
			this.oc.Play("Level_14_Main");
			this.am.ToSnapshot("CH3Defaults", "mxs_level_14_main", 0.5f);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00004146 File Offset: 0x00002346
		private void evt_floor5_exit()
		{
			this.oc.Stop("Level_14_Main");
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00004158 File Offset: 0x00002358
		private void evt_inkflood_enter()
		{
			this.oc.Play("InkFlood");
			this.am.PlayAudio("amb_ink_flood_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_level_14_inkflood", 0.5f);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00004194 File Offset: 0x00002394
		private void evt_inkflood_exit()
		{
			this.oc.Stop("InkFlood");
			this.am.StopAudio("amb_ink_flood_loop", false);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x000041B7 File Offset: 0x000023B7
		private void evt_labyrinth_enter()
		{
			this.oc.Play("Labyrinth");
			this.am.ToSnapshot("CH3Defaults", "mxs_level_14_labyrinth", 0.5f);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x000041E3 File Offset: 0x000023E3
		private void evt_labyrinth_exit()
		{
			this.oc.Stop("Labyrinth");
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000041F5 File Offset: 0x000023F5
		private void evt_liftshaft_enter()
		{
			this.oc.Play("LiftShaft");
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00004207 File Offset: 0x00002407
		private void evt_liftshaft_exit()
		{
			this.oc.Stop("LiftShaft");
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00027DFC File Offset: 0x00025FFC
		private void evt_ch3stairwells_enter()
		{
			this.oc.Play("Stairwell");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.ToSnapshot("CH3Defaults", "mxs_stairwell", 1f);
			this.am.ToSnapshot("S13BaseMixer", "mxs_reverb_corridor", 0.5f);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00004219 File Offset: 0x00002419
		private void evt_ch3stairwells_exit()
		{
			this.oc.Stop("Stairwell");
			this.am.StopAudio("amb_closeup_loop", false);
			this.am.StopAudio("amb_original_horror_loop", false);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000424D File Offset: 0x0000244D
		private void evt_ch3stairwells_exit_to_level9()
		{
			this.oc.Stop("Stairwell");
			this.evt_floor4_enter();
			this.am.ToSnapshot("S13BaseMixer", "mxs_reset", 0.5f);
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00027E70 File Offset: 0x00026070
		private void evt_ch3stairwells_enter_from_level9()
		{
			this.oc.Play("Stairwell");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_original_horror_loop");
			this.am.StopAudio("amb_heavy_loop", false);
			this.am.ToSnapshot("CH3Defaults", "mxs_stairwell", 1f);
			this.am.ToSnapshot("S13BaseMixer", "mxs_reverb_corridor", 0.5f);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00027EF4 File Offset: 0x000260F4
		private void evt_finale_enter()
		{
			this.oc.Play("Finale");
			this.am.ToSnapshot("CH3Defaults", "mxs_finale", 0.5f);
			this.am.ToSnapshot("S13BaseMixer", "mxs_reverb_cavern", 0.5f);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000427F File Offset: 0x0000247F
		private void evt_finale_exit()
		{
			this.oc.Stop("Finale");
			this.am.ToSnapshot("S13BaseMixer", "mxs_reset", 0.5f);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x000042AB File Offset: 0x000024AB
		private void evt_ch3_arrive_at_floor_1()
		{
			this.oc.Enable("Level_K");
			this.oc.Disable("Level_11");
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000042CD File Offset: 0x000024CD
		private void evt_ch3_arrive_at_floor_2()
		{
			this.oc.Enable("Level_11");
			this.oc.Disable("Level_K");
			this.oc.Disable("Level_P");
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000042FF File Offset: 0x000024FF
		private void evt_ch3_arrive_at_floor_3()
		{
			this.oc.Enable("Level_P");
			this.oc.Disable("Level_11");
			this.oc.Disable("Level_9");
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00004331 File Offset: 0x00002531
		private void evt_ch3_arrive_at_floor_4()
		{
			this.oc.Enable("Level_9");
			this.oc.Disable("Level_P");
			this.oc.Disable("Level_14");
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00004363 File Offset: 0x00002563
		private void evt_ch3_arrive_at_floor_5()
		{
			this.oc.Enable("Level_14");
			this.oc.Disable("Level_9");
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00004385 File Offset: 0x00002585
		private void evt_CH3_save_point_01()
		{
			this.evt_ch3_arrive_at_floor_1();
			this.oc.Disable("Safehouse");
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000439D File Offset: 0x0000259D
		private void evt_CH3_save_point_02()
		{
			this.evt_darkhallway_exit();
			this.evt_heavenlytoys_enter();
		}

		// Token: 0x06000261 RID: 609 RVA: 0x000043AB File Offset: 0x000025AB
		private void evt_CH3_save_point_03()
		{
			this.am.InvokeEvent("evt_workshop_enter", 3f);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x000043C2 File Offset: 0x000025C2
		private void evt_CH3_save_point_04()
		{
			this.evt_alice_reveal_complete();
		}

		// Token: 0x06000263 RID: 611 RVA: 0x000043CA File Offset: 0x000025CA
		private void evt_CH3_save_point_05()
		{
			this.oc.Destroy("ChoicesAngel", true);
			this.evt_choices_enter();
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000043E3 File Offset: 0x000025E3
		private void evt_CH3_save_point_06()
		{
			this.evt_choices_enter();
		}

		// Token: 0x06000265 RID: 613 RVA: 0x000043EB File Offset: 0x000025EB
		private void evt_CH3_save_point_07()
		{
			this.oc.Enable("TrailerRoom");
			this.oc.Enable("LiftMain1");
			this.evt_lift_hallways_enter();
		}

		// Token: 0x06000266 RID: 614 RVA: 0x00004413 File Offset: 0x00002613
		private void evt_CH3_save_point_08()
		{
			this.evt_lift_main1_enter();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000441B File Offset: 0x0000261B
		private void evt_CH3_save_point_09()
		{
			this.oc.Disable("Level_K");
			this.evt_floor4_enter();
			this.evt_lift_main1_exit();
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00004439 File Offset: 0x00002639
		private void evt_CH3_save_point_10()
		{
			this.evt_floor4_exit();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00004441 File Offset: 0x00002641
		private void evt_CH3_save_point_11()
		{
			this.evt_floor4_enter();
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_CH3_save_point_12()
		{
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00002482 File Offset: 0x00000682
		private void evt_CH3_save_point_13()
		{
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00004449 File Offset: 0x00002649
		private void evt_player_hit_by_boris()
		{
			this.am.PlayAudio("sfx_player_hit_by_boris");
			this.am.PlayAudio("vo_henry_injured");
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00027F48 File Offset: 0x00026148
		private void evt_boris_death_melt()
		{
			this.am.PlayAudio("sfx_boris_death_melt");
			this.am.ToSnapshot("CharacterAnimations", "mxs_boris_death", 14f);
			this.am.StopAudioDelayed("sfx_boris_death_melt", 14f, false);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00027F98 File Offset: 0x00026198
		private void evt_bert_boss_startup()
		{
			this.am.ToSnapshot("CharacterAnimations", "mxs_bert_startup", 0f);
			this.am.PlayAudio("sfx_bert_boss_startup");
			this.am.PlayAudioDelayed("sfx_bert_hub_spin_start", 2f);
			this.am.StopAudioDelayed("sfx_bert_hub_spin_start", 14f, false);
			this.am.ToSnapshot("CharacterAnimations", "mxs_base", 17f);
			this.am.ToSnapshot("RideStorage", "mxs_boss_fight", 6f);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000446B File Offset: 0x0000266B
		private void evt_bert_boss_head_reveal()
		{
			this.am.ToSnapshot("TMGAudioMixer", "mxs_bert_boss", 30f);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x00004487 File Offset: 0x00002687
		private void evt_bert_hub_turn_start()
		{
			this.am.StopAudio("sfx_bert_hub_idle", false);
			this.am.PlayAudio("sfx_bert_hub_spinning");
			this.am.PlayAudio("sfx_bert_hub_chunk");
		}

		// Token: 0x06000271 RID: 625 RVA: 0x000044BA File Offset: 0x000026BA
		private void evt_bert_hub_turn_stop()
		{
			this.am.PlayAudio("sfx_bert_hub_idle");
			this.am.StopAudio("sfx_bert_hub_spinning", false);
			this.am.PlayAudio("sfx_bert_hub_chunk");
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000044ED File Offset: 0x000026ED
		private void evt_bert_arms_tired()
		{
			this.am.ToSnapshot("CharacterAnimations", "mxs_bert_tired", 3f);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00004509 File Offset: 0x00002709
		private void evt_bert_arms_restored()
		{
			this.am.ToSnapshot("CharacterAnimations", "mxs_base", 3f);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00004525 File Offset: 0x00002725
		private void evt_bert_arm1_dead()
		{
			this.am.PlayAudio("sfx_bert_arm_debris");
		}

		// Token: 0x06000275 RID: 629 RVA: 0x00004525 File Offset: 0x00002725
		private void evt_bert_arm2_dead()
		{
			this.am.PlayAudio("sfx_bert_arm_debris");
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00004525 File Offset: 0x00002725
		private void evt_bert_arm3_dead()
		{
			this.am.PlayAudio("sfx_bert_arm_debris");
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00004525 File Offset: 0x00002725
		private void evt_bert_arm4_dead()
		{
			this.am.PlayAudio("sfx_bert_arm_debris");
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00004537 File Offset: 0x00002737
		private void evt_bert_boss_final_freakout()
		{
			this.am.PlayAudioDelayed("sfx_bert_boss_finale", 1.5f);
			this.am.ToSnapshot("TMGAudioMixer", "mxs_base", 10f);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00004568 File Offset: 0x00002768
		private void evt_bert_boss_defeated()
		{
			this.am.StopAudio("sfx_bert_hub_idle", false);
			this.am.ToSnapshot("RideStorage", "mxs_base", 2f);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x00028030 File Offset: 0x00026230
		private void evt_startinglift_sideroom_opened()
		{
			this.am.PlayAudio("amb_side_room_whispers", 8f);
			this.am.ToSnapshot("StartingLift", "DoorOpened", 0.5f);
			this.am.ToSnapshot("StartingLift", "DoorOpenedDestination", 6f);
			this.am.StopAudioDelayed("amb_side_room_rumble", 8f, false);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00004595 File Offset: 0x00002795
		private void evt_accounting_exit_door_open()
		{
			this.am.PlayAudio("sfx_bridge_blend_loop");
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000045A7 File Offset: 0x000027A7
		private void evt_stage_entry_door_open()
		{
			this.am.PlayAudio("amb_stage_blend_loop");
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000045B9 File Offset: 0x000027B9
		private void evt_swolen_searcher_appears()
		{
			this.am.PlayAudio("sfx_searcher_ink_burble");
			this.am.PlayAudio("sfx_searcher_ink_bubbles");
			this.am.PlayAudio("sfx_searcher_ink_splash");
		}

		// Token: 0x0600027E RID: 638 RVA: 0x000045EB File Offset: 0x000027EB
		private void evt_ink_collected()
		{
			this.am.PlayAudio("sfx_ink_in_hand_loop");
		}

		// Token: 0x0600027F RID: 639 RVA: 0x000045FD File Offset: 0x000027FD
		private void evt_ink_deposited()
		{
			this.am.StopAudio("sfx_ink_in_hand_loop", false);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00004610 File Offset: 0x00002810
		private void evt_ink_pipe_opens()
		{
			this.am.PlayAudio("sfx_ink_bath_pipe_opens");
			this.am.ToSnapshot("Bridge", "BaseMix", 6f);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000463C File Offset: 0x0000283C
		private void evt_headbanger_mixtrap_enter()
		{
			this.am.ToSnapshot("CharacterAnimations", "mxs_headbanger_mix", 2f);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00004658 File Offset: 0x00002858
		private void evt_headbanger_mixtrap_exit()
		{
			this.am.ToSnapshot("CharacterAnimations", "mxs_base", 2f);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00004674 File Offset: 0x00002874
		private void evt_warehouse_door_open()
		{
			this.am.PlayAudio("sfx_warehouse_turns_on");
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0002809C File Offset: 0x0002629C
		private void evt_haunted_house_start()
		{
			this.am.PlayAudio("sfx_haunted_house_powerup", 2f);
			this.am.PlayAudio("sfx_creepy_laugh");
			this.am.PlayAudio("sfx_haunted_house_running_ink");
			this.am.PlayAudio("sfx_haunted_house_running_tracks");
			this.am.ToSnapshot("TMGAudioMixer", "mxs_alice_monologues", 2f);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00004686 File Offset: 0x00002886
		private void evt_haunted_house_cart_start()
		{
			this.am.StopAudio("sfx_creepy_laugh", false);
			this.am.PlayAudio("sfx_haunted_house_cart_loop");
			this.am.PlayAudio("sfx_haunted_house_cart_start");
		}

		// Token: 0x06000286 RID: 646 RVA: 0x000046B9 File Offset: 0x000028B9
		private void evt_haunted_house_cart_stop()
		{
			this.am.StopAudio("sfx_haunted_house_cart_loop", false);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00028108 File Offset: 0x00026308
		private void evt_haunted_house_cart_smashed()
		{
			this.am.PlayAudio("sfx_haunted_house_cart_smash");
			this.am.StopAudio("sfx_haunted_house_running_ink", false);
			this.am.StopAudio("sfx_haunted_house_running_tracks", false);
			this.am.ToSnapshot("TMGAudioMixer", "mxs_alice_monologues_finalCH4", 1f);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000046CC File Offset: 0x000028CC
		private void evt_default_env_enter()
		{
			this.am.PlayAudio("amb_original_ambience_loop");
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000046DE File Offset: 0x000028DE
		private void evt_default_env_exit()
		{
			this.am.StopAudio("amb_original_ambience_loop", false);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000046F1 File Offset: 0x000028F1
		private void evt_starting_lift_enter()
		{
			this.am.PlayAudio("amb_side_room_rumble");
			this.oc.Play("StartingLift");
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00004713 File Offset: 0x00002913
		private void evt_starting_lift_exit()
		{
			this.oc.Stop("StartingLift");
		}

		// Token: 0x0600028C RID: 652 RVA: 0x00004725 File Offset: 0x00002925
		private void evt_archives_room_enter()
		{
			this.oc.Play("Archives");
			this.am.StopAudio("amb_stage_blend_loop", false);
			this.oc.Enable("Bridge");
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00004758 File Offset: 0x00002958
		private void evt_archives_room_exit()
		{
			this.oc.Stop("Archives");
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00028164 File Offset: 0x00026364
		private void evt_bridge_enter()
		{
			this.oc.Play("Bridge");
			this.oc.Enable("SpiralStairs");
			this.oc.Enable("Holding");
			this.oc.Destroy("StartingLift", true);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000476A File Offset: 0x0000296A
		private void evt_bridge_exit()
		{
			this.oc.Stop("Bridge");
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000477C File Offset: 0x0000297C
		private void evt_spiral_stairs_enter()
		{
			this.oc.Play("SpiralStairs");
			this.am.ToSnapshot("TMGAudioMixer", "mxs_alice_monologues", 1f);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x000047A8 File Offset: 0x000029A8
		private void evt_spiral_stairs_exit()
		{
			this.oc.Stop("SpiralStairs");
			this.am.ToSnapshot("TMGAudioMixer", "mxs_base", 1f);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x000281B4 File Offset: 0x000263B4
		private void evt_holding_room_enter()
		{
			this.oc.Play("Holding");
			this.oc.Enable("Vent");
			this.oc.Destroy("Archives", true);
			this.oc.Destroy("Bridge", true);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x000047D4 File Offset: 0x000029D4
		private void evt_holding_room_exit()
		{
			this.oc.Stop("Holding");
		}

		// Token: 0x06000294 RID: 660 RVA: 0x000047E6 File Offset: 0x000029E6
		private void evt_holding_room2_enter()
		{
			this.am.ToSnapshot("Holding", "room2", 1f);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00004802 File Offset: 0x00002A02
		private void evt_holding_room2_exit()
		{
			this.am.ToSnapshot("Holding", "room1", 1f);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000481E File Offset: 0x00002A1E
		private void evt_vent_enter()
		{
			this.am.PlayAudio("sfx_vent_enter");
			this.oc.Play("Vent");
			this.oc.Enable("MapRoom");
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00028204 File Offset: 0x00026404
		private void evt_vent_exit()
		{
			this.am.PlayAudio("sfx_vent_exit");
			this.oc.Play("MapRoom");
			this.oc.Stop("Vent");
			this.oc.Enable("Warehouse");
			this.oc.Destroy("SpiralStairs", true);
			this.oc.Destroy("Holding", true);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00004850 File Offset: 0x00002A50
		private void evt_map_room_enter()
		{
			this.oc.Play("MapRoom");
			this.am.ToSnapshot("PropsStatic", "maproom", 2f);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000487C File Offset: 0x00002A7C
		private void evt_map_room_exit()
		{
			this.oc.Stop("MapRoom");
			this.am.ToSnapshot("PropsStatic", "default", 2f);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00028274 File Offset: 0x00026474
		private void evt_warehouse_enter()
		{
			this.oc.Play("Warehouse");
			this.oc.Destroy("Vent", true);
			this.oc.Enable("ResearchAndDesign");
			this.oc.Enable("ResearchAndDesign_Lower");
			this.oc.Enable("RideStorage");
			this.oc.Enable("Maintenance");
			this.oc.Enable("HauntedHouse");
		}

		// Token: 0x0600029B RID: 667 RVA: 0x000048A8 File Offset: 0x00002AA8
		private void evt_warehouse_exit()
		{
			this.oc.Stop("Warehouse");
		}

		// Token: 0x0600029C RID: 668 RVA: 0x000048BA File Offset: 0x00002ABA
		private void evt_research_and_design_upper_enter()
		{
			this.oc.Play("ResearchAndDesign");
		}

		// Token: 0x0600029D RID: 669 RVA: 0x000048CC File Offset: 0x00002ACC
		private void evt_research_and_design_upper_exit()
		{
			this.oc.Stop("ResearchAndDesign");
		}

		// Token: 0x0600029E RID: 670 RVA: 0x000048DE File Offset: 0x00002ADE
		private void evt_research_and_design_mix_enter()
		{
			this.am.ToSnapshot("ResearchAndDesign", "mxs_upper_occlusion", 3f);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x000048FA File Offset: 0x00002AFA
		private void evt_research_and_design_mix_exit()
		{
			this.am.ToSnapshot("ResearchAndDesign", "mxs_base", 3f);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00004916 File Offset: 0x00002B16
		private void evt_research_and_design_lower_enter()
		{
			this.oc.Play("ResearchAndDesign_Lower");
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00004928 File Offset: 0x00002B28
		private void evt_research_and_design_lower_exit()
		{
			this.oc.Stop("ResearchAndDesign_Lower");
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000493A File Offset: 0x00002B3A
		private void evt_ride_storage_enter()
		{
			this.oc.Play("RideStorage");
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000494C File Offset: 0x00002B4C
		private void evt_ride_storage_exit()
		{
			this.oc.Stop("RideStorage");
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000495E File Offset: 0x00002B5E
		private void evt_maintenance_enter()
		{
			this.am.PlayAudio("amb_original_horror_loop");
			this.oc.Play("Maintenance");
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00004980 File Offset: 0x00002B80
		private void evt_maintenance_exit()
		{
			this.am.StopAudio("amb_original_horror_loop", false);
			this.oc.Stop("Maintenance");
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x000049A3 File Offset: 0x00002BA3
		private void evt_maintenance_upper_enter()
		{
			this.am.ToSnapshot("Maintenance", "upper", 3f);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x000049BF File Offset: 0x00002BBF
		private void evt_maintenance_upper_exit()
		{
			this.am.ToSnapshot("Maintenance", "lower", 2f);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x000049DB File Offset: 0x00002BDB
		private void evt_haunted_house_enter()
		{
			this.am.PlayAudio("amb_original_horror_loop");
			this.oc.Play("HauntedHouse");
			this.oc.Enable("Ballroom");
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00004A0D File Offset: 0x00002C0D
		private void evt_haunted_house_exit()
		{
			this.am.StopAudio("amb_original_horror_loop", false);
			this.oc.Stop("HauntedHouse");
		}

		// Token: 0x060002AA RID: 682 RVA: 0x000282F4 File Offset: 0x000264F4
		private void evt_ballroom_enter()
		{
			this.am.StopAudio("amb_original_ambience_loop", false);
			this.oc.Play("Ballroom");
			this.oc.Destroy("MapRoom", true);
			this.oc.Destroy("ResearchAndDesign", true);
			this.oc.Destroy("ResearchAndDesign_Lower", true);
			this.oc.Destroy("Maintenance", true);
			this.oc.Destroy("RideStorage", true);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00004A30 File Offset: 0x00002C30
		private void evt_ballroom_exit()
		{
			this.oc.Stop("Ballroom");
			this.oc.Destroy("HauntedHouse", true);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00004713 File Offset: 0x00002913
		private void evt_CH4_save_point_01()
		{
			this.oc.Stop("StartingLift");
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00004A53 File Offset: 0x00002C53
		private void evt_CH4_save_point_02()
		{
			this.evt_CH4_save_point_01();
			this.oc.Destroy("StartingLift", true);
			this.oc.Destroy("Archives", true);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00004A7D File Offset: 0x00002C7D
		private void evt_CH4_save_point_03()
		{
			this.evt_CH4_save_point_02();
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00004A85 File Offset: 0x00002C85
		private void evt_CH4_save_point_04()
		{
			this.evt_CH4_save_point_03();
			this.oc.Play("Vent");
			this.oc.Enable("MapRoom");
			this.oc.Destroy("SpiralStairs", true);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00004ABE File Offset: 0x00002CBE
		private void evt_CH4_save_point_05()
		{
			this.evt_CH4_save_point_04();
			this.oc.Stop("Vent");
			this.oc.Play("MapRoom");
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00004AE6 File Offset: 0x00002CE6
		private void evt_CH4_save_point_06()
		{
			this.oc.Destroy("Vent", true);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00004AF9 File Offset: 0x00002CF9
		private void evt_CH4_save_point_07()
		{
			this.evt_CH4_save_point_06();
			this.evt_warehouse_enter();
			this.oc.Stop("MapRoom");
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00028378 File Offset: 0x00026578
		private void evt_CH4_save_point_08()
		{
			this.oc.Stop("Warehouse");
			this.oc.Play("Warehouse");
			this.oc.Enable("ResearchAndDesign");
			this.oc.Enable("ResearchAndDesign_Lower");
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00004B17 File Offset: 0x00002D17
		private void evt_CH4_save_point_09()
		{
			this.oc.Stop("Warehouse");
			this.oc.Play("Warehouse");
			this.oc.Enable("RideStorage");
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00004B49 File Offset: 0x00002D49
		private void evt_CH4_save_point_10()
		{
			this.oc.Stop("Warehouse");
			this.oc.Play("Warehouse");
			this.oc.Enable("Maintenance");
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00004B7B File Offset: 0x00002D7B
		private void evt_CH4_save_point_11()
		{
			this.oc.Stop("Warehouse");
			this.oc.Play("Warehouse");
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00004B9D File Offset: 0x00002D9D
		private void evt_CH4_save_point_12()
		{
			this.evt_CH4_save_point_11();
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00004BA5 File Offset: 0x00002DA5
		private void evt_CH4_save_point_13()
		{
			this.evt_CH4_save_point_12();
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00004BAD File Offset: 0x00002DAD
		private void evt_CH4_save_point_14()
		{
			this.evt_CH4_save_point_13();
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00004BB5 File Offset: 0x00002DB5
		private void evt_CH4_save_point_15()
		{
			this.evt_CH4_save_point_14();
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00004BBD File Offset: 0x00002DBD
		private void evt_ch5_scene06_complete()
		{
			this.am.PlayAudio("sfx_scene07_rocks_crumble");
			this.am.PlayAudio("sfx_scene07_stones");
			this.am.PlayAudio("sfx_scene07_bendy_heartbeat");
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00004BEF File Offset: 0x00002DEF
		private void evt_ch5_scene07_complete()
		{
			this.am.PlayAudio("sfx_scene07_shaking_loop");
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00004C01 File Offset: 0x00002E01
		private void evt_ch5_seeing_tool_active()
		{
			this.am.StopAudio("sfx_scene07_shaking_loop", false);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x000283C8 File Offset: 0x000265C8
		private void evt_ch5_boat_in_distance()
		{
			this.am.PlayAudio("sfx_boat_in_distance");
			this.am.StopAudio("sfx_scene07_rocks_crumble", false);
			this.am.StopAudio("sfx_scene07_stones", false);
			this.am.PlayAudio("sfx_boat_in_distance");
			this.am.PlayAudio("sfx_boat_launch");
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00028428 File Offset: 0x00026628
		private void evt_chute_brake_active()
		{
			this.am.PlayAudio("sfx_chutebrake_release_1");
			this.am.PlayAudio("sfx_chutebrake_release_2");
			this.am.PlayAudioDelayed("sfx_chutebrake_engage_1", 5f);
			this.am.PlayAudioDelayed("sfx_chutebrake_engage_2", 5f);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x00004C14 File Offset: 0x00002E14
		private void evt_boat_chute_slide1()
		{
			this.am.PlayAudio("sfx_chute_slide1");
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00004C26 File Offset: 0x00002E26
		private void evt_boat_chute_slide2()
		{
			this.am.PlayAudio("sfx_chute_slide2");
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x00004C38 File Offset: 0x00002E38
		private void evt_ch5_abyss_fall()
		{
			this.am.PlayAudio("sfx_abyss_fall");
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00004C4A File Offset: 0x00002E4A
		private void evt_ch5_joey_office_hiding()
		{
			this.am.PlayAudio("test_tone_beep");
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x00004C5C File Offset: 0x00002E5C
		private void evt_ch5_puzzle_piece_added()
		{
			this.am.PlayAudio("sfx_pipe_piece_added");
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x00004C6E File Offset: 0x00002E6E
		private void evt_film_vault_door_cleared()
		{
			this.am.PlayAudio("sfx_ink_drained_puzzle");
			this.oc.Destroy("VaultPuzzle_Flood", false);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x00004C91 File Offset: 0x00002E91
		private void evt_ch5_joey_speaks()
		{
			this.am.LerpMixerProperty("CH5 Ambience by Section", "WhistleVolume", -80f, 0.2f, false);
			this.am.StopAudioDelayed("amb_joey_dishes", 6f, false);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00004CC9 File Offset: 0x00002EC9
		private void evt_ch5_joey_kitchen_exit()
		{
			this.am.StopAudioDelayed("amb_joey_kitchen", 6f, false);
			this.am.StopAudio("amb_joey_whistle", false);
			this.am.PlayAudioDelayed("amb_chapter1_bake", 5.5f);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x00004D07 File Offset: 0x00002F07
		private void evt_ch5_joey_ketchen_resume()
		{
			this.am.PlayAudio("amb_joey_dishes");
			this.am.PlayAudio("amb_joey_kitchen");
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00028480 File Offset: 0x00026680
		private void evt_ch5_safehouse_enter()
		{
			this.oc.Play("Safehouse");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_bendy_loop");
			this.am.StopAudio("amb_wind_loop", false);
			this.am.ToSnapshot("CH5 Defaults", "mxs_safehouse", 2.5f);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00004D29 File Offset: 0x00002F29
		private void evt_ch5_safehouse_exit()
		{
			this.oc.Stop("Safehouse");
		}

		// Token: 0x060002CB RID: 715 RVA: 0x000284E8 File Offset: 0x000266E8
		private void evt_ch5_caves_enter()
		{
			this.oc.Play("Caves");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_wind_loop");
			this.am.StopAudio("amb_bendy_loop", false);
			this.am.StopAudio("amb_tunnel_loop", false);
			this.am.StopAudio("amb_airy_loop", false);
			this.am.ToSnapshot("CH5 Defaults", "mxs_caves", 4f);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00004D3B File Offset: 0x00002F3B
		private void evt_ch5_caves_exit()
		{
			this.oc.Stop("Caves");
		}

		// Token: 0x060002CD RID: 717 RVA: 0x00028574 File Offset: 0x00026774
		private void evt_ch5_dock_enter()
		{
			this.oc.Play("Dock");
			this.am.StopAudio("amb_wind_loop", false);
			this.am.PlayAudio("amb_airy_loop");
			this.am.StopAudio("amb_closeup_loop", false);
			this.am.ToSnapshot("CH5 Defaults", "mxs_dock", 2f);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00004D4D File Offset: 0x00002F4D
		private void evt_ch5_dock_exit()
		{
			this.oc.Stop("Dock");
		}

		// Token: 0x060002CF RID: 719 RVA: 0x000285E0 File Offset: 0x000267E0
		private void evt_ch5_tunnels_enter()
		{
			this.oc.Play("Tunnels");
			this.am.PlayAudio("amb_tunnel_loop");
			this.am.PlayAudio("amb_flood_loop");
			this.am.StopAudio("amb_airy_loop", false);
			this.am.ToSnapshot("CH5 Defaults", "mxs_tunnels", 2f);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00004D5F File Offset: 0x00002F5F
		private void evt_ch5_tunnels_exit()
		{
			this.oc.Stop("Tunnels");
			this.am.StopAudio("amb_flood_loop", false);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00028648 File Offset: 0x00026848
		private void evt_ch5_lost_harbour_enter()
		{
			this.oc.Play("LostHarbour");
			this.am.PlayAudio("amb_airy_loop");
			this.am.PlayAudio("amb_deep_loop");
			this.am.StopAudio("amb_tunnel_loop", false);
			this.am.StopAudio("amb_noisy_loop", false);
			this.am.ToSnapshot("CH5 Defaults", "mxs_lost_harbour", 2f);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00004D82 File Offset: 0x00002F82
		private void evt_ch5_lost_harbour_exit()
		{
			this.oc.Stop("LostHarbour");
			this.am.StopAudio("amb_airy_loop", false);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000286C4 File Offset: 0x000268C4
		private void evt_ch5_abyss_enter()
		{
			this.oc.Play("Abyss");
			this.am.PlayAudio("amb_deep_loop");
			this.am.PlayAudio("amb_noisy_loop");
			this.am.ToSnapshot("CH5 Defaults", "mxs_abyss", 2f);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00004DA5 File Offset: 0x00002FA5
		private void evt_ch5_abyss_exit()
		{
			this.oc.Stop("Abyss");
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0002871C File Offset: 0x0002691C
		private void evt_ch5_administration_enter()
		{
			this.oc.Play("Administration");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_noisy_loop");
			this.am.StopAudio("amb_deep_loop", false);
			this.am.StopAudio("amb_industrial_loop", false);
			this.am.ToSnapshot("CH5 Defaults", "mxs_administration", 4f);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00004DB7 File Offset: 0x00002FB7
		private void evt_ch5_administration_exit()
		{
			this.oc.Stop("Administration");
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x00028798 File Offset: 0x00026998
		private void evt_ch5_joeys_office_enter()
		{
			this.oc.Play("JoeysOffice");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_tunnel_loop");
			this.am.StopAudio("amb_noisy_loop", false);
			this.am.ToSnapshot("CH5 Defaults", "mxs_joeys_office", 2f);
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00004DC9 File Offset: 0x00002FC9
		private void evt_ch5_joeys_office_exit()
		{
			this.oc.Stop("JoeysOffice");
			this.am.StopAudio("amb_tunnel_loop", false);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00028800 File Offset: 0x00026A00
		private void evt_ch5_vault_puzzle_enter()
		{
			this.oc.Play("VaultPuzzle");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_noisy_loop");
			this.am.PlayAudio("amb_industrial_loop");
			this.am.ToSnapshot("CH5 Defaults", "mxs_vault_puzzle", 2f);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00004DEC File Offset: 0x00002FEC
		private void evt_ch5_vault_puzzle_exit()
		{
			this.oc.Stop("VaultPuzzle");
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00028868 File Offset: 0x00026A68
		private void evt_ch5_vault_enter()
		{
			this.oc.Play("Vault");
			this.am.PlayAudio("amb_closeup_loop");
			this.am.PlayAudio("amb_noisy_loop");
			this.am.PlayAudio("amb_industrial_loop");
			this.am.StopAudio("amb_horror_loop", false);
			this.am.ToSnapshot("CH5 Defaults", "mxs_vault", 2f);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00004DFE File Offset: 0x00002FFE
		private void evt_ch5_vault_exit()
		{
			this.oc.Stop("Vault");
		}

		// Token: 0x060002DD RID: 733 RVA: 0x000288E0 File Offset: 0x00026AE0
		private void evt_ch5_back_hall_enter()
		{
			this.oc.Play("BackHall");
			this.am.PlayAudio("amb_horror_loop");
			this.am.PlayAudio("amb_industrial_loop");
			this.am.StopAudio("amb_closeup_loop", false);
			this.am.StopAudio("amb_noisy_loop", false);
			this.am.StopAudio("amb_airy_loop", false);
			this.am.ToSnapshot("CH5 Defaults", "mxs_back_hall", 2f);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00004E10 File Offset: 0x00003010
		private void evt_ch5_back_hall_exit()
		{
			this.oc.Stop("BackHall");
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0002896C File Offset: 0x00026B6C
		private void evt_ch5_giant_ink_machine_enter()
		{
			this.oc.Play("GiantInkMachine");
			this.am.PlayAudio("amb_bendy_loop");
			this.am.PlayAudio("amb_airy_loop");
			this.am.StopAudio("amb_industrial_loop", false);
			this.am.StopAudio("amb_horror_loop", false);
			this.am.LerpMixerProperty("CH5 Ambience by Section", "SteamVolume", 0f, 2f, true);
			this.am.ToSnapshot("CH5 Defaults", "mxs_giant_ink_machine", 2f);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00028A08 File Offset: 0x00026C08
		private void evt_ch5_giant_ink_machine_exit()
		{
			this.oc.Stop("GiantInkMachine");
			this.am.PlayAudio("amb_industrial_loop");
			this.am.StopAudio("amb_bendy_loop", false);
			this.am.StopAudio("amb_airy_loop", false);
			this.am.LerpMixerProperty("CH5 Ambience by Section", "SteamVolume", -24f, 2f, true);
			this.am.ToSnapshot("CH5 Defaults", "mxs_throne_room", 2f);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00004E22 File Offset: 0x00003022
		private void evt_ch5_machine_interior_enter()
		{
			this.oc.Play("MachineInterior");
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00004E34 File Offset: 0x00003034
		private void evt_ch5_machine_interior_exit()
		{
			this.oc.Stop("MachineInterior");
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00028A94 File Offset: 0x00026C94
		private void evt_ch5_throne_room_enter()
		{
			this.oc.Play("ThroneRoom");
			this.am.PlayAudio("amb_industrial_loop");
			this.am.PlayAudio("amb_wind_loop");
			this.am.ToSnapshot("CH5 Defaults", "mxs_throne_room", 2f);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00004E46 File Offset: 0x00003046
		private void evt_ch5_throne_room_exit()
		{
			this.oc.Stop("ThroneRoom");
			this.am.StopAudio("amb_industrial_loop", false);
			this.am.StopAudio("amb_wind_loop", false);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00028AEC File Offset: 0x00026CEC
		private void evt_ch5_bendy_arena_enter()
		{
			this.oc.Play("BendyArena");
			this.am.PlayAudio("amb_industrial_loop");
			this.am.PlayAudio("amb_deep_loop");
			this.am.ToSnapshot("CH5 Defaults", "mxs_bendy_arena", 2f);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00004E7A File Offset: 0x0000307A
		private void evt_ch5_bendy_arena_exit()
		{
			this.oc.Stop("BendyArena");
			this.am.StopAudio("amb_industrial_loop", false);
			this.am.StopAudio("amb_deep_loop", false);
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00028B44 File Offset: 0x00026D44
		private void ResetMixers(int chapter = 0)
		{
			this.am.ToSnapshot("TMGAudioMixer", "mxs_base", 0f);
			this.am.ToSnapshot("S13BaseMixer", "mxs_reset", 0f);
			this.am.ToSnapshot("CharacterAnimations", "mxs_base", 0f);
			this.am.ToSnapshot("PropStatic", "default", 0f);
			switch (chapter)
			{
			case 1:
				this.am.ToSnapshot("CH1 Ambience by Section", "mxs_base", 0f);
				this.am.ToSnapshot("CH1Defaults", "mxs_base", 0f);
				this.am.ToSnapshot("CH1ScriptedEvents", "Base", 0f);
				break;
			case 2:
				this.am.ToSnapshot("CH2 Ambience by Section", "mxs_default", 0f);
				this.am.ToSnapshot("CH2Defaults", "Opening", 0f);
				this.am.ToSnapshot("Sewers", "Base", 0f);
				break;
			case 3:
				this.am.ToSnapshot("CH3 Ambience by Section", "mxs_ambience_base", 0f);
				this.am.ToSnapshot("CH3Defaults", "mxs_base", 0f);
				this.am.ToSnapshot("CH3Workshop", "1Active", 0f);
				break;
			case 4:
				this.am.ToSnapshot("CH4 Ambience by Section", "mxs_ambience_base", 0f);
				this.am.ToSnapshot("Bridge", "BathMuted", 0f);
				this.am.ToSnapshot("Holding", "room1", 0f);
				this.am.ToSnapshot("Maintenance", "upper", 0f);
				this.am.ToSnapshot("ResearchAndDesign", "mxs_base", 0f);
				this.am.ToSnapshot("RideStorage", "mxs_base", 0f);
				this.am.ToSnapshot("StartingLift", "BaseMix", 0f);
				break;
			case 5:
				this.am.ToSnapshot("CH5 Ambience by Section", "mxs_base", 0f);
				this.am.ToSnapshot("CH5Defaults", "mxs_base", 0f);
				this.am.ToSnapshot("CH5ScriptedEvents", "mxs_base", 0f);
				break;
			default:
				Debug.Log("No chapter selected, default mixers reset.", base.gameObject);
				break;
			}
		}

		// Token: 0x04000172 RID: 370
		public S13AudioManager am;

		// Token: 0x04000173 RID: 371
		public S13ObjectContainer oc;
	}
}
