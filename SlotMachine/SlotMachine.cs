using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotMachine
    {

        public int NumberOfSlots { get; set; }

        public int IconsPerSlot { get; set; }
        public int MinimumBet { get; set; }
        public int MaximumBet { get; set; }


        private int _currentBet;
        public int CurrentBet
        {
            get
            {
                return _currentBet;
            }
            set
            {
                _currentBet = value;
                if (_currentBet < MinimumBet)
                {
                    _currentBet = MinimumBet;
                }
                if (_currentBet > MaximumBet)
                {
                    _currentBet = MaximumBet;
                }
            }
        }

        /// <summary>
        /// An array of integers that is as long as the number of slots,
        /// with each element of the array representing a different slot
        /// </summary>
        public int[] icons = new int[3];

        public SlotMachine()
        {
            NumberOfSlots = 3;
            IconsPerSlot = 5;
            MinimumBet = 1;
            MaximumBet = 100;
        }

        /// <summary>
        /// Randomizes the contents of the icons
        /// </summary>
        public void PullLever()
        {
            Random random = new Random();
            //Console.WriteLine( random.Next(1, 6));
            //Console.WriteLine(random.Next(1, 6));
            //Console.WriteLine(random.Next(1, 6));
            for (int i = 0; i < icons.Length; i++)

            {
                int myRoll;
                myRoll = random.Next(1, 6);
                icons[i] = myRoll;
            }

        }

        /// <summary>
        /// Return the results from the slots
        /// </summary>
        /// <returns>an int[] with each slot as an element of the array</returns>
        public int[] GetResults()
        {
            // TODO
            PullLever();
            return icons;
        }

        /// <summary>
        /// Examine the contents of the slots and determine the appropriate payout
        /// based upon the CurrentBet.
        /// </summary>
        /// <returns>number of pennies to pay out</returns>
        public int GetPayout()

        {

            var i1 = (icons.GetValue(0));
            var i2 = (icons.GetValue(1));
            var i3 = (icons.GetValue(2));

            if (i1 == i2 && i2 == i3)
            {
                _currentBet = icons[1];
            }
            else _currentBet = 0;

            return _currentBet;
        }
           

    }


}

