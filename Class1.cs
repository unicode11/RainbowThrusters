using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using VRageMath;
using VRage.Game;
using Sandbox.ModAPI.Interfaces;
using Sandbox.ModAPI.Ingame;
using Sandbox.Game.EntityComponents;
using VRage.Game.Components;
using VRage.Collections;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game.ModAPI.Ingame;
using SpaceEngineers.Game.ModAPI.Ingame;
using VRage.Utils;
using Sandbox.ModAPI;
using DarkVault.RecolorableThrusters;
using Sandbox.Game.Gui;
using System.Runtime.CompilerServices;
using VRage.Library.Utils;

namespace Script1
{
    public sealed class Program : MyGridProgram
    {
        
        bool COLORS = true ; // To modify colors - scroll down until "var" section
        bool CLOWN  = false ;

        // SCRIPT START BELOVE


        Random ra = new Random();
        List<Sandbox.ModAPI.Ingame.IMyThrust> thrusters = new List<Sandbox.ModAPI.Ingame.IMyThrust>();

        public void Main(string args)
        {
            // Vars are in Color(RED, GREEN, BLUE, ALPHA(keep at 255) format)
            // To add new color - put your color in RGBA format (look one line up), add it as new var, put name in a "color_array"
            var RED = new Color(255, 0, 0, 255);
            var ORANGE = new Color(255, 120, 0, 255);
            var YELLOW = new Color(255, 255, 0, 255);
            var GREEN = new Color(0, 255, 0, 255);
            var CYAN = new Color(0, 255, 255, 255);
            var BLUE = new Color(0, 0, 255, 255);
            var PURPLE = new Color(120, 0, 255, 255);

            VRageMath.Color[] color_array =
                { RED, ORANGE, YELLOW, GREEN, CYAN, BLUE, PURPLE };



            GridTerminalSystem.GetBlocksOfType(thrusters);
            foreach (Sandbox.ModAPI.Ingame.IMyThrust thrust in thrusters)
            {

                if (CLOWN == true)
                {
                    thrust.SetValue("FlameIdleColorOverride", new Color(ra.Next(1, 256), ra.Next(1, 256), ra.Next(1, 256)));
                }

                if (COLORS == true)
                {
                    thrust.SetValue("FlameIdleColorOverride", color_array[ra.Next(0, color_array.Length)]);
                }
            }
        }
    }
}


        // SCRIPT START ABOVE