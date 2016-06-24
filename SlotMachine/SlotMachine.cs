using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotMachine
    {
        public int[] icons;
        private int _numberOfSlots;
        public int NumberOfSlots
        {
            get
            {
                return _numberOfSlots;
            }

            set
            {
                _numberOfSlots = value;
                icons = new int[_numberOfSlots];
            }
        }


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

            for (int i = 0; i < icons.Length; i++)

            {
                //int myRoll;

                icons[i] = random.Next(IconsPerSlot) + 1;// +1 can be in parenthises
            }

        }

        /// <summary>
        /// Return the results from the slots
        /// </summary>
        /// <returns>an int[] with each slot as an element of the array</returns>
        public int[] GetResults()
        {

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
            int i1 = (icons[0]);
            int i2 = (icons[1]);
            int i3 = (icons[2]);
            int payout = 0;

            if (i1 == i2 && i2 == i3)
            {
                payout = icons[1] * 1000 * CurrentBet;
            }
            return payout;

        }
    }

}




