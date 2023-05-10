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
using SpaceEngineers.Game.ModAPI.Ingame;
using VRage.Utils;
using DarkVault.RecolorableThrusters;
using Sandbox.Game.Gui;
using System.Runtime.CompilerServices;
using VRage.Library.Utils;
using VRage.Game.ObjectBuilders.VisualScripting;
using VRage;

namespace Script1
{
    public sealed class Program : MyGridProgram

    {
        Random ra = new Random();
        List<IMyThrust> thrusters = new List<IMyThrust>();

        private void Clownify()
        {
            foreach (IMyThrust thrust in thrusters)
                thrust.SetValue("FlameIdleColorOverride", new Color(ra.Next(1, 256), ra.Next(1, 256), ra.Next(1, 256)));
            Echo("\nDONE");
        }

        private void Colorfy()
        {
            // Colros are in Color(RED, GREEN, BLUE, ALPHA(keep at 255) format)
            // To add new color - put your color in RGBA format (look one line up), add it as new var, put name in a "color_array"

            Color RED = new Color(255, 0, 0, 255);
            Color ORANGE = new Color(255, 120, 0, 255);
            Color YELLOW = new Color(255, 255, 0, 255);
            Color GREEN = new Color(0, 255, 0, 255);
            Color CYAN = new Color(0, 255, 255, 255);
            Color BLUE = new Color(0, 0, 255, 255);
            Color PURPLE = new Color(120, 0, 255, 255);


            VRageMath.Color[] color_array =
            { RED, ORANGE, YELLOW, GREEN, CYAN, BLUE, PURPLE };

            foreach (IMyThrust thrust in thrusters)
                thrust.SetValue("FlameIdleColorOverride", color_array[ra.Next(0, color_array.Length)]);
            Echo("\nDONE");
        }
        private enum Mode
        {
            COLOR,
            CLOWN
        }

        private void GetThrusters()
        {
            GridTerminalSystem.GetBlocksOfType(thrusters);
        }

        public void Main(string argument)
        {
            // NO EDIT BELOW THIS LINE !!!

            Runtime.UpdateFrequency = UpdateFrequency.Update100;

            Echo ("Set mode by typing it into \"Argument\" section of Programmable Block.\nAvailable modes: ");
            foreach (string value in Enum.GetNames(typeof(Mode)))
            {
                Echo(value);
            }


            GetThrusters();
            if (argument == (Mode.CLOWN).ToString())
            {
                Clownify();
            }

            if (argument == (Mode.COLOR).ToString())
            {
                Colorfy();
            }
        }






    }
}