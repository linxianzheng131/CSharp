using System.Net.NetworkInformation;

namespace C_入门实践_完整
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1 控制台基础设置   
            //隐藏光标
            Console.CursorVisible = false;
            //通过两个变量来存储 舞台的大小
            int w = 50;
            int h =30;
            //设置舞台（控制台）的大小
            Console.SetWindowSize(w, h);
            Console.SetBufferSize(w, h);
            #endregion

            #region 2多个场景
            int nowSelindex = 0;
            int nowScenceID = 1;
            string gameOverIfo = "";
            while(true)
            {
                bool isQuitWhile= false;
                switch (nowScenceID)
                {
                    case 1:
                        Console.Clear();
                        #region 3 开始界面逻辑的实现
                        Console.SetCursorPosition(w / 2 - 5, 8);
                        Console.Write("英雄救公主");                        
                        while (true)
                        {
                            Console.SetCursorPosition(w / 2 - 4, 13);
                            Console.ForegroundColor = nowSelindex == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.WriteLine("开始游戏");
                            Console.SetCursorPosition(w / 2 - 4, 15);
                            Console.ForegroundColor = nowSelindex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.WriteLine("退出游戏");
                            char input1 = Console.ReadKey(true).KeyChar;
                            switch (input1)
                            {
                                case 'w':
                                case 'W':
                                    --nowSelindex;
                                    if (nowSelindex < 0)
                                    {
                                        nowSelindex = 0;
                                    }
                                    break;
                                case 's':
                                case 'S':
                                    ++nowSelindex;
                                    if (nowSelindex > 1)
                                    {
                                        nowSelindex = 1;
                                    }
                                    break;
                                case 'j':
                                case 'J':
                                    if (nowSelindex == 0)
                                    {
                                        nowScenceID = 2;
                                        isQuitWhile = true;
                                    }
                                    else if (nowSelindex == 1)
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            if (isQuitWhile == true)
                            {
                                break;
                            }
                        }
                        #endregion
                        break;
                    case 2:
                        Console.Clear();
                        #region 4 不变的红墙

                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 0; i < w; i += 2)
                        {
                            //上方墙
                            Console.SetCursorPosition(i, 0);
                            Console.Write("■");
                            //下方墙
                            Console.SetCursorPosition(i, h - 1);
                            Console.Write("■");
                            //中间墙
                            Console.SetCursorPosition(i, h - 6);
                            Console.Write("■");
                        }
                        for (int i = 0; i < h; i++)
                        {
                            //左边的墙
                            Console.SetCursorPosition(0, i);
                            Console.Write("■");
                            //右边的墙
                            Console.SetCursorPosition(w - 2, i);
                            Console.Write("■");
                        }
                        #endregion

                        #region 5 boss属性相关
                        int bossX = 24;
                        int bossY = 15;
                        int bossAtkMin = 7;
                        int bossAtkMax = 13;
                        int bossHp = 100;
                        string bossIcon = "■";
                        ConsoleColor bossColor = ConsoleColor.Green;
                        #endregion

                        #region 6 player属性相关
                        int playerX = 4;
                        int playerY = 5;
                        int playerAtkMin = 8;
                        int playerAtkMax = 12;
                        int playerHp = 100;
                        string playerIcon = "■";
                        #endregion

                        #region 8 公主属性相关
                        ConsoleColor playerColor = ConsoleColor.Yellow;
                        int princessX = 24;
                        int princessY = 5;
                        string princessIcon = "■";
                        ConsoleColor princessColor = ConsoleColor.Blue;
                        #endregion

                        #region 玩家战斗相关
                        bool isFight = false;
                        bool isOver = false;
                        char playerInput;
                        #endregion
                        while (true)
                        {
                            #region boss属性使用
                                if (bossHp > 0)
                                {
                                Console.SetCursorPosition(bossX, bossY);
                                Console.ForegroundColor = bossColor;
                                Console.Write(bossIcon);
                                
                                }
                            #endregion
                                else
                            
                                {
                                #region 公主属性使用
                                Console.SetCursorPosition(princessX,princessY);
                                Console.ForegroundColor = princessColor;
                                Console.Write(princessIcon);
                                #endregion
                                }
                                #region 玩家移动属性
                            Console.SetCursorPosition(playerX, playerY);
                            Console.ForegroundColor = playerColor;
                            Console.Write(playerIcon);
                            playerInput = Console.ReadKey(true).KeyChar;
                            #endregion

                            if (isFight)
                            {
                                #region 打架逻辑
                                if (playerInput == 'j' || playerInput == 'J')
                                {
                                    if (playerHp <= 0)
                                    {
                                        nowScenceID = 3;
                                        break;
                                    }
                                    else if (bossHp <= 0)
                                    {
                                        Console.SetCursorPosition(bossX, bossY);
                                        Console.Write("  ");
                                        isFight = false;
                                    }
                                    else
                                    {
                                        Random r = new Random();
                                        int playerAtk = r.Next(playerAtkMin, playerAtkMax);
                                        bossHp -= playerAtk;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.SetCursorPosition(2, h - 4);
                                        Console.Write("                                         ");
                                        Console.SetCursorPosition(2, h - 4);
                                        Console.Write("你对boss{0}点伤害，boss剩余血量为{1}", playerAtk, bossHp);

                                        if (bossHp > 0)
                                        {

                                            int bossAtk = r.Next(bossAtkMin, bossAtkMax);
                                            playerHp -= bossAtk;
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.SetCursorPosition(2, h - 3);
                                            Console.Write("                                       ");
                                            if (playerHp <= 0)
                                            {
                                                Console.SetCursorPosition(2, h - 3);
                                                Console.Write("你挂了");
                                                gameOverIfo = "游戏失败";
                                            }
                                            else
                                            {
                                                Console.SetCursorPosition(2, h - 3);
                                                Console.Write("boss对你{0}点伤害，你的剩余血量为{1}", bossAtk, playerHp);
                                            }
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.Write("                                       ");
                                            Console.SetCursorPosition(2, h - 4);
                                            Console.Write("                                       ");
                                            Console.SetCursorPosition(2, h - 3);
                                            Console.Write("                                       ");
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.Write("你战胜了boss，快去救公主吧");
                                            Console.SetCursorPosition(2, h - 4);
                                            Console.Write("按j键继续，前往公主身边按j健继续");
                                        }
                                    }
                                }
                                #endregion
                            }
                            else
                            {                                
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write("  ");
                                switch (playerInput)
                                {
                                    #region player 玩家移动属性使用
                                    case 'w':
                                    case 'W':
                                        playerY -= 1;
                                        if (playerY < 1)
                                        {
                                            playerY = 1;
                                        }
                                        else if (playerX == bossX && playerY == bossY && bossHp > 0)
                                        {
                                            ++playerY;
                                            // playerY = bossY + 1;
                                        }
                                        else if (playerX == princessX && playerY == princessY && bossHp < 0)
                                        {
                                            ++playerY;
                                        }
                                        break;
                                    case 'a':
                                    case 'A':
                                        playerX -= 2;
                                        if (playerX < 2)
                                        {
                                            playerX = 2;
                                        }
                                        else if (playerX == bossX && playerY == bossY && bossHp > 0)
                                        {
                                            playerX += 2;
                                            //playerX = bossX + 2;
                                        }
                                        else if (playerX == princessX && playerY == princessY && bossHp < 0)
                                        {
                                            playerX += 2;
                                        }
                                        break;
                                    case 's':
                                    case 'S':
                                        playerY += 1;
                                        if (playerY > h - 7)
                                        {
                                            playerY = h - 7;
                                        }
                                        else if (playerX == bossX && playerY == bossY && bossHp > 0)
                                        {
                                            --playerY;
                                            //playerY = bossY - 1;
                                        }
                                        else if (playerX == princessX && playerY == princessY && bossHp < 0)
                                        {
                                            --playerY;
                                        }
                                        break;
                                    case 'd':
                                    case 'D':
                                        playerX += 2;
                                        if (playerX > w - 4)
                                        {
                                            playerX = w - 4;
                                        }
                                        else if (playerX == bossX && playerY == bossY && bossHp > 0)
                                        {
                                            playerX -= 2;
                                            //playerX = bossX - 2;
                                        }
                                        else if (playerX == princessX && playerY == princessY && bossHp < 0)
                                        {
                                            playerX -= 2;
                                        }
                                        #endregion

                                        break;
                                    case 'j':
                                    case 'J':

                                        #region 玩家战斗相关
                                        if ((playerX == bossX && playerY == bossY - 1 ||
                                             playerX == bossX && playerY == bossY + 1 ||
                                             playerX == bossX - 2 && playerY == bossY ||
                                             playerX == bossX + 2 && playerY == bossY) && bossHp > 0)
                                        {
                                            isFight = true;
                                            Console.SetCursorPosition(2, h - 5);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write("开始和boss战斗了，按j健继续");
                                            Console.SetCursorPosition(2, h - 4);
                                            Console.Write("玩家当前的血量为{0}", playerHp);
                                            Console.SetCursorPosition(2, h - 3);
                                            Console.Write("boss当前的血量为{0}", bossHp);

                                        }
                                        else if ((playerX == princessX && playerY == princessY - 1 ||
                                             playerX == princessX && playerY == princessY + 1 ||
                                             playerX == princessX - 2 && playerY == princessY ||
                                             playerX == princessX + 2 && playerY == princessY) && bossHp <0)
                                        {
                                            nowScenceID = 3;
                                            isOver = true;
                                            gameOverIfo = "游戏通关";
                                        }                                      
                                        #endregion

                                        break;
                                }                                
                            }
                            if(isOver)
                            {
                                break;
                            }
                        }
                
                        break;
                    case 3:
                        Console.Clear();
                        #region 结束界面逻辑实现
                        Console.SetCursorPosition(w/2-4,4);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("gameOver");
                        Console.SetCursorPosition(w/2-4,5);
                        Console.Write(gameOverIfo);
                        Console.SetCursorPosition(w/2-4,9);
                        Console.ForegroundColor= nowSelindex ==0 ? ConsoleColor.Red : ConsoleColor.White;
                        Console.Write("重新开始");
                        Console.SetCursorPosition(w / 2 - 4, 15);
                        Console.ForegroundColor = nowSelindex == 1 ? ConsoleColor.Red : ConsoleColor.White;
                        Console.WriteLine("退出游戏");
                        char input2 = Console.ReadKey(true).KeyChar;
                        switch (input2)
                        {
                            case 'w':
                            case 'W':
                                --nowSelindex;
                                if (nowSelindex < 0)
                                {
                                    nowSelindex = 0;
                                }
                                break;
                            case 's':
                            case 'S':
                                ++nowSelindex;
                                if (nowSelindex > 1)
                                {
                                    nowSelindex = 1;
                                }
                                break;
                            case 'j':
                            case 'J':
                                if (nowSelindex == 0)
                                {
                                    nowScenceID = 2;
                                    isQuitWhile = true;
                                }
                                else if (nowSelindex == 1)
                                {
                                    Environment.Exit(0);
                                }
                                break;
                        }
                        if (isQuitWhile == true)
                        {
                            break;
                        }                        
                        #endregion

                        break;
                }
            }
            #endregion
        }
    }
}
