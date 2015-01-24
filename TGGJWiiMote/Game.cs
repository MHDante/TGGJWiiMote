using System;
using WiimoteLib;

namespace TGGJWiiMote
{
    internal class Game{
        private readonly Wiimote _wiimote;
        public bool IsExiting = false;
        private int _index;

        public Game()
        {
            var wiimotes = new WiimoteCollection();
            try{ wiimotes.FindAllWiimotes(); }
            catch (WiimoteNotFoundException ex){
                Console.WriteLine(ex.Message, "Wiimote not found error");
                Console.WriteLine("Try Again?");
                Exit(Utils.YesOrNo());
                return;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message, "Unknown error");
                Exit(false);
            }

            if(wiimotes.Count > 1) Console.WriteLine("Only the First WiiMote will be used!");
            _wiimote = wiimotes[0];
            // connect it and set it up as always
            _wiimote.WiimoteChanged += WiimoteHandler.WiimoteChanged;
            //We don't care about extensions.
            //wm.WiimoteExtensionChanged += wm_WiimoteExtensionChanged;
            _wiimote.Connect();
            if (_wiimote.WiimoteState.ExtensionType != ExtensionType.BalanceBoard)
                _wiimote.SetReportType(InputReport.IRExtensionAccel, IRSensitivity.Maximum, true);
        }

        private int _timer;
        private bool _ding;
        public void Update(int deltatime)
        {
            Console.WriteLine();
            _timer += deltatime;
            if (_timer > 500)
            {
                _wiimote.SetLEDs( 1<<(_index = (_index+1)%4));
                _wiimote.SetRumble(true);
                _timer = 0;
                _ding = true;
            }

            if (_timer > 25 && _ding)
            {
                _wiimote.SetRumble(false);
                _ding = false;

            }
        }

        private void Exit(bool restart)
        {
            _wiimote.SetRumble(false);
            Program.IsRestarting = true;
            IsExiting = true;
        }
    }
}