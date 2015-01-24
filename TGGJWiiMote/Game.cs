using System;
using WiimoteLib;

namespace TGGJWiiMote
{
    internal class Game{
        public bool IsExiting = false;

        public Game() {
            var wiimotes = new WiimoteCollection();
            try{ wiimotes.FindAllWiimotes(); }
            catch (WiimoteNotFoundException ex){
                Console.WriteLine(ex.Message, "Wiimote not found error");
                Console.WriteLine("Try Again?");
                Exit(Utils.YesOrNo());
            } catch (Exception ex) {
                Console.WriteLine(ex.Message, "Unknown error");
                Exit(false);
            }
        }

        public void Update() {

        }

        private void Exit(bool restart) {
            IsExiting = true;
        }
    }
}