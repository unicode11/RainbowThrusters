using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
using System.Security.Cryptography.X509Certificates;

namespace Script1
{
    public sealed class MyClass : MyGridProgram

    {
        // Colros are in new Color(RED, GREEN, BLUE, ALPHA(keep at 255) format)
        // To add new color - put your color in RGBA format (look one line up), add it as new Color
        
        VRageMath.Color[] color_array =
        {

            /* RED */    (new Color(255, 0, 0, 255)),
            /* BLUE */   (new Color(0, 0, 255, 255)),
            /* GREEN */  (new Color(0, 255, 0, 255)),
            /* ORANGE */ (new Color(255, 120, 0, 255)), 
            /* YELLOW */ (new Color(255, 255, 0, 255)),
            /* CYAN */   (new Color(0, 255, 255, 255)),
            /* PURPLE */ (new Color(120, 0, 255, 255))
        };

        // NO EDIT BELOW THIS LINE



        // можно сделать так, шобы челик указывал какую сторону окрашивать в поле Argument (типа COLOR FORWARD; CLOWN BACK; CLOWN UP)


        Random ra = new Random();
        List<IMyThrust> thrusters = new List<IMyThrust>();



        private void Colorfy()
        {
            foreach (IMyThrust thrust in thrusters)
                thrust.SetValue("FlameIdleColorOverride", color_array[ra.Next(0, color_array.Length)]);
            Echo("\nDONE");
        }


        private void Clownify()
        {
            foreach (IMyThrust thrust in thrusters)
                thrust.SetValue("FlameIdleColorOverride", new Color(ra.Next(1, 256), ra.Next(1, 256), ra.Next(1, 256)));
            Echo("\nDONE");
        }

        
        private enum Side
        {
            FORWARD,
            BACK,
            LEFT,
            RIGHT,
            UP,
            DOWN
        }

        private enum Mode
        {
            COLOR,
            CLOWN
        }

        private void GetThrusters()
        {
            GridTerminalSystem.GetBlocksOfType(thrusters);
            GridTerminalSystem.GetBlockWithName("Thruster ");
        }

        public void Main(string argument)
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update100;
            GetThrusters();

                if (argument == (Mode.CLOWN).ToString())
                {
                    Clownify();
                }

                if (argument == (Mode.COLOR).ToString())
                {
                    Colorfy();
                }
                else
                {
                    Echo("Set mode by typing it into \"Argument\" section of Programmable Block.\nAvailable modes: ");
                    foreach (string value in Enum.GetNames(typeof(Mode)))
                        Echo(value);
                }


        }






    }
}