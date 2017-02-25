#if ENABLE_UNET

namespace UnityEngine.Networking
{
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class CustomNetworkHUD : MonoBehaviour
	{
		public NetworkManager manager;
		[SerializeField] public bool showGUI = true;
		[SerializeField] public int offsetX;
		[SerializeField] public int offsetY;

		// Runtime variable
//		bool showServer = false;

		void Awake()
		{
			manager = GetComponent<NetworkManager>();
		}

		void OnGUI()
		{
			if (!showGUI)
				return;

			int xpos = 10 + offsetX;
			int ypos = 40 + offsetY;
			int spacing = 24;
				if (manager.matchMaker == null)
				{
					if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Enable Match Maker (M)"))
					{
						manager.StartMatchMaker();
					}
					ypos += spacing;
				}
				else
				{
					if (manager.matchInfo == null)
					{
						if (manager.matches == null)
						{
							if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Create Internet Match"))
							{
								manager.matchMaker.CreateMatch (manager.matchName, manager.matchSize, true, "", "", "", 0, 0, manager.OnMatchCreate);
							}
							ypos += spacing;

							GUI.Label(new Rect(xpos, ypos, 100, 20), "Room Name:");
							manager.matchName = GUI.TextField(new Rect(xpos+100, ypos, 100, 20), manager.matchName);
							ypos += spacing;

							ypos += 10;

							if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Find Internet Match"))
							{
								manager.matchMaker.ListMatches (0, 20, "", false, 0, 0, manager.OnMatchList);
							}
							ypos += spacing;
						}
						else
						{
							foreach (var match in manager.matches)
							{
								if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Join Match:" + match.name))
								{
									manager.matchName = match.name;
									manager.matchSize = (uint)match.currentSize;
									manager.matchMaker.JoinMatch (match.networkId, "", "", "", 0, 0, manager.OnMatchJoined);
								}
								ypos += spacing;
							}
						}
					}

					ypos += spacing;

					GUI.Label(new Rect(xpos, ypos, 300, 20), "MM Uri: " + manager.matchMaker.baseUri);
					ypos += spacing;

					if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Disable Match Maker"))
					{
						manager.StopMatchMaker();
					}
					ypos += spacing;
			}
		}
	}
};
#endif //ENABLE_UNET
