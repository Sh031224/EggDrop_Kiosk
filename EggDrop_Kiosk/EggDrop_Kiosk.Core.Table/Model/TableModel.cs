using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace EggDrop_Kiosk.Core.Table.Model
{
    public class TableModel: BindableBase
    {
        public const int EXPIRE_SECOND = 60; 
        public int Number { get; set; }

        private DateTime _paidTime;
        public DateTime PaidTime
        {
            get => _paidTime;
            set
            {
                SetProperty(ref _paidTime, value);
                ExpireTime = PaidTime.AddSeconds(EXPIRE_SECOND);
                RemainSecond = EXPIRE_SECOND;
                IsUsing = true;
                SetRemainTimer();
            }
        }

        private DateTime _expireTime;
        public DateTime ExpireTime
        {
            get => _expireTime;
            set => SetProperty(ref _expireTime, value);
        }

        private int _remainSecond;
        public int RemainSecond
        {
            get => _remainSecond;
            set => SetProperty(ref _remainSecond, value);
        }

        private bool _isUsing;
        public bool IsUsing
        {
            get => _isUsing;
            set => SetProperty(ref _isUsing, value);
        }

        private void SetRemainTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler((object sender, EventArgs e) =>
            {
                if (RemainSecond <= 0)
                {
                    timer.Stop();
                    IsUsing = false;
                }
                RemainSecond -= 1;
            });

            timer.Start();
        }

    }
}
