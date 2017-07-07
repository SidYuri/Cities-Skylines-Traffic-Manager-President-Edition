﻿using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrafficManager.Custom.PathFinding;
using TrafficManager.State;
using UnityEngine;

namespace TrafficManager.UI.MainMenu {
	public class StatsLabel : UILabel {
		public override void Start() {
			size = new Vector2(MainMenuPanel.MENU_WIDTH / 2, MainMenuPanel.TOP_BORDER);
			text = "";
			relativePosition = new Vector3(MainMenuPanel.MENU_WIDTH / 2, 5f);
			textAlignment = UIHorizontalAlignment.Right;
			anchor = UIAnchorStyle.Top | UIAnchorStyle.Right;
		}

#if QUEUEDSTATS
		public override void Update() {
			if (Options.showPathFindStats) {
				uint queued = CustomPathManager.TotalQueuedPathFinds;
				if (queued < 1000) {
					textColor = Color.Lerp(Color.green, Color.yellow, (float)queued / 1000f);
				} else if (queued < 2500) {
					textColor = Color.Lerp(Color.yellow, Color.red, (float)(queued - 1000f) / 1500f);
				} else {
					textColor = Color.red;
				}

				text = CustomPathManager.TotalQueuedPathFinds.ToString() + " PFs";
			} else {
				text = "";
				m_TextColor = Color.white;
			}
		}
#endif
	}
}