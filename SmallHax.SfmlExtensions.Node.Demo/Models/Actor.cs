using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHax.SfmlExtensions.Node.Demo.Models
{
    public enum Affinity
    {
        Red = 10,
        Blue = 20,
        Green = 30,
        Purple = 100
    }

    public delegate void ActorChangeHandler(Actor sender);

    public class Actor
    {
        public string Image { get; set; }
        public Affinity Affinity { get; set; }
        public int Level { get; set; }
        private int _maxHp { get; set; } = 1;
        public int MaxHp
        {
            get
            {
                return _maxHp;
            }
            set
            {
                if (value == MaxHp)
                {
                    return;
                }
                if (value <= 0)
                {
                    throw new Exception("MaxHp cannot be lower than 1");
                }
                _maxHp = value;
                HpChanged?.Invoke(this);
            }
        }
        private int _hp { get; set; } = 0;
        public int Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                if (value == Hp)
                {
                    return;
                }
                if (value < 0)
                {
                    throw new Exception("Hp cannot go below 0");
                }
                if (value > MaxHp)
                {
                    throw new Exception("Hp cannot be greater than MaxHp");
                }
                _hp = value;
                HpChanged?.Invoke(this);
            }
        }

        private int _turnInterval { get; set; } = 100;
        public int TurnInterval
        {
            get
            {
                return _turnInterval;
            }
            set
            {
                if (value == _turnInterval)
                {
                    return;
                }
                if (value < 1)
                {
                    throw new Exception("TurnInterval cannot be lower than 1");
                }
                if (value < TurnProgress)
                {
                    _turnProgress = value;
                }
                _turnInterval = value;
                TurnProgressChanged?.Invoke(this);
            }
        }

        private int _turnProgress { get; set; } = 0;
        public int TurnProgress
        {
            get
            {
                return _turnProgress;
            }
            set
            {
                if (value == TurnProgress)
                {
                    return;
                }
                if (value < 0)
                {
                    throw new Exception("TurnProgress cannot go below 0");
                }
                if (value > TurnInterval)
                {
                    throw new Exception("TurnProgress cannot be greater than TurnInterval");
                }
                _turnProgress = value;
                TurnProgressChanged?.Invoke(this);
            }
        }

        public event ActorChangeHandler HpChanged;
        public event ActorChangeHandler TurnProgressChanged;
    }
}
