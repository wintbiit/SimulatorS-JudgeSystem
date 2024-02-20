using Event;
using JudgeSystem._2024uc.Buildings.Interfaces;
using JudgeSystem._2024uc.Events;
using JudgeSystem.Interfaces;

namespace JudgeSystem._2024uc.Buildings
{
    public partial class Exchanger: IExchangerController
    {
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