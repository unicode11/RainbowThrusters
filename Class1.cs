using System;
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




namespace Script1
{
    public sealed class Program : MyGridProgram
    {

        // COPY FROM HERE





        List<Sandbox.ModAPI.Ingame.IMyThrust> thrusters = new List<Sandbox.ModAPI.Ingame.IMyThrust>();
        public Program()
        {

        }


        public void Main(string args)
        // The main entry point of the script, invoked every time
        // one of the programmable block's Run actions are invoked,
        // or the script updates itself. The updateSource argument
        // describes where the update came from. Be aware that the
        // updateSource is a  bitfield  and might contain more than
        // one update type.


        {
            var myColor = new Color(255, 255, 255, 255);
            GridTerminalSystem.GetBlocksOfType(thrusters);
            foreach (Sandbox.ModAPI.Ingame.IMyThrust thrust in thrusters)
            {
                thrust.Enabled = false;
            }
                
            // Определение уже имеющегося цвета
            // foreach (IMyInteriorLight lamp in thrusters)
            // {
            //    if (lamp.Color.R == 255 && lamp.Color.G == 255 && lamp.Color.B == 255) lamp.Color = new Color(lamp.Color.R, lamp.Color.G, lamp.Color.B);
              
            // }

        }


        // TO HERE


        //------------END--------------
    }
}