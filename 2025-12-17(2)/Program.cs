using System;
using System.Threading.Tasks;



class Program
{
    static async Task Main()
    {
        var account = new Account(1000);
        var tasks = new Task[100];
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() => Update(account));
        }
        await Task.WhenAll(tasks);  //等待所有线程任务执行完 执行流才往下走
                                    //这种等待主线程没有锁死
                                    //而Task.WaitAll(tasks),主线程是锁死的
        Console.WriteLine($"余额是: {account.GetBalance()}");
        // Output:
        // Account's balance is 2000
    }

    /// <summary>
    /// 每次执行余额增加10
    /// </summary>
    /// <param name="account"></param>
    static void Update(Account account)
    {
        decimal[] amounts = new decimal[] { 0, 2, -3, 6, -2, -1, 8, -5, 11, -6 };
        foreach (var amount in amounts)
        {
            if (amount >= 0)
            {
                account.Credit(amount); //存钱
            }
            else
            {
                account.Debit(Math.Abs(amount)); //取钱
            }
        }
    }
}







public class Account
{
    /// <summary>
    /// 线程锁
    /// </summary>
    private readonly object _balanceLock = new object();
    /// <summary>
    /// 余额
    /// </summary>
    private decimal _balance;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="initialBalance"></param>
    public Account(decimal initialBalance) => _balance = initialBalance;


    /// <summary>
    /// 取钱
    /// </summary>
    /// <param name="amount"></param>
    /// <returns>实际取到金额</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public decimal Debit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "取款金额不能为负数.");
        }

        decimal appliedAmount = 0;
        lock (_balanceLock)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                appliedAmount = amount;
            }
        }
        return appliedAmount;
    }

    /// <summary>
    /// 存钱
    /// </summary>
    /// <param name="amount"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Credit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "存款金额不能为负数");
        }

        lock (_balanceLock)
        {
            _balance += amount;
        }
    }

    /// <summary>
    /// 获取余额
    /// </summary>
    /// <returns>实际余额</returns>
    public decimal GetBalance()
    {
        lock (_balanceLock)
        {
            return _balance;
        }
    }
}

