using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ArchipelagoRandomizer
{
    public class SharedStoneHintData : MonoBehaviour
    {
        private static Dictionary<NomaiRemoteCameraPlatform.ID, GameObject> ProjectionStones;

        private CheckImportance importance;
        
        private IEnumerator Start()
        {
            // Waiting to ensure connected text has initialized
            int frames = Time.frameCount;
            yield return new WaitUntil(() => Time.frameCount >= frames + 40);

            NomaiSharedWhiteboard whiteboard = GetComponent<NomaiSharedWhiteboard>();
            for (int i = 0; i < whiteboard._nomaiTexts.Length; i++)
            {
                List<ArcHintData> arcs = whiteboard._nomaiTexts[i].GetComponentsInChildren<ArcHintData>().ToList();
                arcs.RemoveAll(x => x.Locations.Count == 0);
                // We can ignore trying to change scroll colors if there are no hints found
                if (arcs.Count == 0) yield break;
                importance = arcs.Max(x => x.DisplayImportance);
                Color iconColor = Color.white;
                Color trimColor = Color.white;
                if (arcs.All(x => x.HasBeenFound))
                {
                    iconColor = HintColors.FoundColor;
                    trimColor = HintColors.FoundColorTrim;
                }
                else
                {
                    switch (importance)
                    {
                        case CheckImportance.Filler:
                            {
                                iconColor = HintColors.FillerColor;
                                trimColor = HintColors.FillerColorTrim;
                                break;
                            }
                        case CheckImportance.Useful:
                            {
                                iconColor = HintColors.UsefulColor;
                                trimColor = HintColors.UsefulColorTrim;
                                break;
                            }
                        case CheckImportance.Progression:
                            {
                                iconColor = HintColors.ProgressionColor;
                                trimColor = HintColors.ProgressionColorTrim;
                                break;
                            }
                        default:
                            {
                                APRandomizer.OWMLModConsole.WriteLine($"Uh this code shouldn't have been reached, the scroll at {transform.parent.name} somehow didn't inherit an importance priority.", OWML.Common.MessageType.Error);
                                iconColor = Color.red;
                                trimColor = Color.red;
                                break;
                            }
                    }
                }
                GameObject stone = ProjectionStones[whiteboard._remoteIDs[i]];
                stone.transform.Find("AnimRoot/PlanetDecal").GetComponent<Renderer>().material.SetColor("_EmissionColor", iconColor);
                stone.transform.Find("AnimRoot/Props_NOM_SharedStone").GetComponent<Renderer>().material.SetColor("_EmissionColor", trimColor);
                APRandomizer.OWMLModConsole.WriteLine($"Stone that's the child of {transform.parent.name} has been given the color relating to importance {importance}");
            }
        }

        public static void RegisterStone(SharedStone stone)
        {
            if (ProjectionStones == null) ProjectionStones = new();
            ProjectionStones.Add(stone._connectedPlatform, stone.gameObject);
        }
    }
}
