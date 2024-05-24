using UnityEngine;

namespace ArchipelagoRandomizer
{
    public class CheckHintData : MonoBehaviour
    {
        public string CheckName;
        public CheckImportance Importance = CheckImportance.Junk;
        public bool HasBeenFound = false;

        public static Color JunkColor = new(0, 2, 0, 1);
        public static Color UsefulColor = new(0, 2f, 2, 1);
        public static Color ProgressionColor = new(2, 1.5f, 0, 1);
        public static Color FoundColor = new(2, 2, 2, 1);

        public Color NomaiWallColor()
        {
            if (HasBeenFound) return FoundColor;
            switch (Importance)
            {
                case CheckImportance.Junk:
                    return JunkColor;
                case CheckImportance.Useful:
                    return UsefulColor;
                case CheckImportance.Progression:
                    return ProgressionColor;
                default:
                    {
                        int rnd = Random.Range(0, 3);
                        switch (rnd)
                        {
                            case 0:
                                return JunkColor;
                            case 1:
                                return UsefulColor;
                            default:
                                return ProgressionColor;
                        }    
                    }
            }
        }

        public void SetImportance(CheckImportance importance)
        {
            if ((int)Importance < (int)importance)
            {
                Importance = importance;
            }
        }

        private void Awake()
        {
            APRandomizer.OWMLModConsole.WriteLine($"I've been added to {transform.parent.name}/{gameObject.name}!");
        }
    }
    public enum CheckImportance
    {
        Trap = 0,
        Junk = 1,
        Useful = 2,
        Progression = 3
    }
}
