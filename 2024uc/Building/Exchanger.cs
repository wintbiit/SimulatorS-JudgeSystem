using Event;
using JudgeSystem._2024uc.Building.Interfaces;
using JudgeSystem._2024uc.Event;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Building
{
    public class Exchanger: global::JudgeSystem.Building, IExchangerController
    {
        public const ushort ID = 0x02;
        
        public Exchanger(Camp camp): base(camp, ID)
        {
        }

        private int _exchangeGrade;
        private readonly ExchangerGradeSelectEvent _exchangerGradeSelectEvent = new ();
        public int ExchangeGrade
        {
            get => _exchangeGrade;
            set
            {
                if (_exchangeGrade == value) return;
                _exchangeGrade = value;
                _exchangerGradeSelectEvent.Reset();
                _exchangerGradeSelectEvent.ReadFrom(this);
                _exchangerGradeSelectEvent.Grade = value;
                _exchangerGradeSelectEvent.Publish();
            }
        }
        
        private readonly ExchangeOreEvent _exchangeOreEvent = new ();
        public void Exchange(IIdentityHolder exchanger, Ore ore)
        {
            _exchangeOreEvent.Reset();
            _exchangeOreEvent.ReadFrom(this);
            _exchangeOreEvent.Ore = ore;
            _exchangeOreEvent.Grade = _exchangeGrade;
            _exchangeOreEvent.Publish();
        }
    }
}