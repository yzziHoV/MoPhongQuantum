using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace MoPhongQuantum.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() { return View(); }
        public IActionResult LyThuyet() { return View(); }
        public IActionResult Quiz() { return View(); }

        [HttpPost]
        public IActionResult TinhToan(int n, List<int> at, List<int> bt, int quantum)
        {
            // at = Arrival Time, bt = Burst Time
            int completed = 0;
            int currentTime = 0;
            int[] rt = bt.ToArray(); // Thời gian còn lại
            int[] wt = new int[n];
            int[] tat = new int[n];
            int[] ct = new int[n]; // Thời điểm hoàn thành
            bool[] inQueue = new bool[n];

            Queue<int> queue = new Queue<int>();
            var steps = new List<object>();

            while (completed < n)
            {
                // 1. Đưa các tiến trình đã đến tại currentTime vào hàng đợi
                for (int i = 0; i < n; i++)
                {
                    if (at[i] <= currentTime && rt[i] > 0 && !inQueue[i])
                    {
                        queue.Enqueue(i);
                        inQueue[i] = true;
                    }
                }

                // 2. Nếu hàng đợi trống, CPU rảnh rỗi (Idle), nhảy cóc thời gian đến tiến trình gần nhất
                if (queue.Count == 0)
                {
                    int nextArrival = int.MaxValue;
                    for (int i = 0; i < n; i++)
                    {
                        if (at[i] > currentTime && rt[i] > 0)
                            nextArrival = Math.Min(nextArrival, at[i]);
                    }

                    if (nextArrival != int.MaxValue)
                    {
                        steps.Add(new { Process = "IDLE", Start = currentTime, End = nextArrival, Duration = nextArrival - currentTime });
                        currentTime = nextArrival;
                    }
                    continue;
                }

                // 3. Xử lý tiến trình đang ở đầu hàng đợi
                int idx = queue.Dequeue();
                inQueue[idx] = false;

                int runTime = Math.Min(rt[idx], quantum);
                steps.Add(new { Process = "P" + (idx + 1), Start = currentTime, End = currentTime + runTime, Duration = runTime });

                currentTime += runTime;
                rt[idx] -= runTime;

                // 4. Kiểm tra xem trong lúc tiến trình này chạy, có ai mới đến không
                for (int i = 0; i < n; i++)
                {
                    if (at[i] <= currentTime && rt[i] > 0 && !inQueue[i] && i != idx)
                    {
                        queue.Enqueue(i);
                        inQueue[i] = true;
                    }
                }

                // 5. Nếu tiến trình hiện tại chưa chạy xong, đẩy nó xuống cuối hàng đợi
                if (rt[idx] > 0)
                {
                    queue.Enqueue(idx);
                    inQueue[idx] = true;
                }
                else
                {
                    completed++;
                    ct[idx] = currentTime;
                    tat[idx] = ct[idx] - at[idx];
                    wt[idx] = tat[idx] - bt[idx];
                }
            }

            ViewBag.SoTienTrinh = n;
            ViewBag.ArrivalTimes = at;
            ViewBag.BurstTimes = bt;
            ViewBag.WaitingTimes = wt;
            ViewBag.TurnaroundTimes = tat;
            ViewBag.Quantum = quantum;
            ViewBag.Steps = JsonSerializer.Serialize(steps);

            return View("KetQua");
        }
    }
}