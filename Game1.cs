using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace _0520_Mono
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        System.Random r = new System.Random();



        int playerHp;
        bool playerDaedF;
        Texture2D player;
        bool playerDamageF;
        Vector2 playerPos;
        Vector2 playerVel;

        int playerDamageAnimeTime = 0;
        int playerAlpha = 255;
        double playerAnimaTime = 0;
        int playerAnimaSum = 0;
        int playerAnimaSize = 0;
        bool playerAnimaEnd;



        //敵 弾は複数出すため、配列に
        Texture2D tama;
        int enemySyurui;
        public double settim = 0;
        public Vector2[] enemyTamaPos = new Vector2[20];      //弾の位置
        public Vector2[] enemyTamaVel = new Vector2[20];     //弾の移動
        public bool[] enemyTamaF = new bool[20];        //弾フラグ
        int enemyTamaSecond = 0;

        //プレイヤー 弾
        public Vector2[] playerTamaPos = new Vector2[20];      //弾の位置
        public Vector2[] playerTamaVel = new Vector2[20];     //弾の移動
        public bool[] playerTamaF = new bool[20];        //弾フラグ
        float tamaSpeed = 6.0f;
        int playerTamaSecond = 0;

        //敵
        int[] enemyHp = new int[20];
        Texture2D enemy01;
        int enemyPrefabTime = 0;
        bool[] enemyPrafabF = new bool[20];
        Vector2[] enemyPos = new Vector2[20];
        Vector2[] enemyVel = new Vector2[20];
        float enemySpeed = 2;
        bool[] enemyDaedF = new bool[20];

        bool[] BossEnemyF = new bool[20];
        int enemyPrefab02F;

        int[] enemyDamegeAnimeF = new int[20];
        int[] afterEnemyHp = new int[20];
        int[] enemyAlpha = new int[20];
        int[] enemyAnimaSize = new int[20];
        bool[] enemyAnimaEnd = new bool[20];

        //ドュン
        int dyunAnimeTime;
        int dyunAnimeSize;

        int dyunEnemyTime;
        int dyunEnemySize;

        //時計
        Texture2D tokei;
        Vector2 tokeiPos;
        Vector2 tokeiVel;
        float tokeiSpeed;
        int tokeiPrefabTime;
        int chronoTime = 180;
        bool tokeiPrefabF;

        bool chronoF;

        //衝突判定
        float Radius6406;
        float Radius6464;



        //背景
        Texture2D BgBoard;
        Texture2D BgDai01;
        Texture2D BgDai02;
        Texture2D BgSyou01;
        Texture2D BgSyou02;

        Vector2 BgDai01Pos = Vector2.Zero;
        Vector2 BgDai02Pos = Vector2.Zero;
        Vector2 BgSyou01Pos = Vector2.Zero;
        Vector2 BgSyou02Pos = Vector2.Zero;

        Vector2 BGVelo = Vector2.Zero;
        float BGSpeed = 0f;

        //UI
        Texture2D title;
        Vector2 titlePos;
        Texture2D sousa;
        Vector2 sousaPos;
        Texture2D gameOver;
        Vector2 gameOverPos;
        Texture2D gameClear;
        Vector2 gameClearPos;
        Texture2D pushEnter;
        Vector2 pushEnterPos;

        int UiAlphaTime;
        int UiAlpha = 255;

        bool pushEnterF;
        int BossNumF;


        //画面遷移
        int senniF;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            playerDaedF = false;

            playerDamageAnimeTime = 0;
            playerAlpha = 255;
            playerAnimaTime = 0;
            playerAnimaSum = 0;
            playerAnimaSize = 0;
            playerAnimaEnd = false;



            //敵 弾は複数出すため、配列に
            enemySyurui = 0;
            settim = 0;
            enemyTamaPos = new Vector2[20];      //弾の位置
            enemyTamaVel = new Vector2[20];     //弾の移動
            enemyTamaSecond = 0;

            //プレイヤー 弾
            playerTamaPos = new Vector2[20];      //弾の位置
            playerTamaVel = new Vector2[20];     //弾の移動
            playerTamaF = new bool[20];        //弾フラグ
            tamaSpeed = 6.0f;
            playerTamaSecond = 0;

            //敵
            enemyPrefabTime = 0;
            enemyPrafabF = new bool[20];
            enemyPos = new Vector2[20];
            enemySpeed = 2;
            enemyDaedF = new bool[20];

            BossEnemyF = new bool[20];
            enemyPrefab02F = 0;

            afterEnemyHp = new int[20];
            enemyAnimaSize = new int[20];

            //ドュン
            dyunAnimeTime = 0;
            dyunAnimeSize = 0;

            dyunEnemyTime = 0;
            dyunEnemySize = 0;

            //時計
            tokeiPos = Vector2.Zero;
            tokeiPrefabTime = 0;
            chronoTime = 180;
            tokeiPrefabF = false;

            chronoF = false;

            UiAlpha = 255;

            pushEnterF=false;
            BossNumF=0;

            // TODO: Add your initialization logic here
            senniF = 0;

            playerHp = 3;
            playerDamageF = false;
            playerPos = new Vector2(50, 50);
            playerVel = Vector2.Zero;

            //時計

            tokeiVel.X = -1;
            tokeiSpeed = 5;


            for (int i = 0; i < enemyTamaF.Length; i++)
            {
                enemyTamaF[i] = false;    //弾フラグクリア
                enemyVel[i].X = -2;
                enemyAlpha[i] = 255;
                enemyHp[i] = 2;
                enemyDamegeAnimeF[i] = 0;
                enemyAnimaEnd[i] = true;
            }

            Radius6406 = 6 + 32;
            Radius6464 = 32 + 32;

            BgDai01Pos.X = 0f;
            BgDai02Pos.X = graphics.PreferredBackBufferWidth;
            BgSyou01Pos.X = 0f;
            BgSyou02Pos.X = graphics.PreferredBackBufferWidth;
            BGVelo.X = -1f;
            BGSpeed = 2f;

            titlePos = new Vector2(160, 70);
            gameOverPos = new Vector2(170, 230);
            gameClearPos = new Vector2(160, 230);
            pushEnterPos = new Vector2(210, 420);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player = Content.Load<Texture2D>("Player02");
            tama = Content.Load<Texture2D>("Tama");
            enemy01 = Content.Load<Texture2D>("Enemy01");
            tokei = Content.Load<Texture2D>("Chrono");

            BgDai01 = Content.Load<Texture2D>("BgDai01");
            BgDai02 = Content.Load<Texture2D>("BgDai02");
            BgSyou01 = Content.Load<Texture2D>("BgSyou01");
            BgSyou02 = Content.Load<Texture2D>("BgSyou02");

            title = Content.Load<Texture2D>("Title");
            sousa = Content.Load<Texture2D>("Sousa");
            gameOver = Content.Load<Texture2D>("gameOver");
            gameClear = Content.Load<Texture2D>("gameClear");
            pushEnter = Content.Load<Texture2D>("PushEnter");

            BgBoard = Content.Load<Texture2D>("BgBoard");


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            switch (senniF)
            {

                case 0:
                    Window.Title = "MonoGames と Monochrome と Chrono を合わせたタイトルだよ！ダッサイね！！";
                    break;

                case 1:
                    Window.Title = "赤い敵を倒したら勝ちだよ！頑張ってね！！";
                    break;

                case 2:
                    switch (playerHp)
                    {
                        case 3:
                            Window.Title = "体力：♡ ♡ ♡ 　(*'ω'*)";
                            break;
                        case 2:
                            Window.Title = "体力：♡ ♡　(>_<)";
                            break;
                        case 1:
                            Window.Title = "体力：♡　(´；ω；`)";
                            break;
                    }
                    break;

                case 3:
                    Window.Title = "Enterキーでタイトルへ";
                    break;

                case 4:
                    Window.Title = "すごい！遊んでくれてありがとう！！　　Enterキーでタイトルへ";
                    break;
            }

            //ドゅん
            dyunAnimeTime++;
            if (dyunAnimeTime < 23)
            {
                dyunAnimeSize--;
            }
            else
            {
                dyunAnimeSize += 5;

            }

            if (dyunAnimeTime > 27)
            {
                dyunAnimeSize = 0; ;

                dyunAnimeTime = 0;
            }




            //背景
            if (!chronoF)
            {
                BgDai01Pos += BGVelo * BGSpeed;
                BgDai02Pos += BGVelo * BGSpeed;
                BgSyou01Pos += BGVelo * (BGSpeed + 1f);
                BgSyou02Pos += BGVelo * (BGSpeed + 1f);

                if (BgDai01Pos.X < -graphics.PreferredBackBufferWidth)
                {
                    BgDai01Pos.X = graphics.PreferredBackBufferWidth;
                }
                if (BgDai02Pos.X < -graphics.PreferredBackBufferWidth)
                {
                    BgDai02Pos.X = graphics.PreferredBackBufferWidth;
                }
                if (BgSyou01Pos.X < -graphics.PreferredBackBufferWidth)
                {
                    BgSyou01Pos.X = graphics.PreferredBackBufferWidth;
                }
                if (BgSyou02Pos.X < -graphics.PreferredBackBufferWidth)
                {
                    BgSyou02Pos.X = graphics.PreferredBackBufferWidth;
                }

            }

            //タイトル
            if (senniF == 0)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    pushEnterF = true;
                }
                else if (!Keyboard.GetState().IsKeyDown(Keys.Enter) && pushEnterF)
                {
                    pushEnterF = false;
                    senniF = 1;

                }
            }

            if (senniF == 1)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    pushEnterF = true;
                }
                else if (!Keyboard.GetState().IsKeyDown(Keys.Enter) && pushEnterF)
                {
                    pushEnterF = false;
                    senniF = 2;

                }
            }

            if (senniF == 3)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    pushEnterF = true;
                }
                else if (!Keyboard.GetState().IsKeyDown(Keys.Enter) && pushEnterF)
                {
                    //初期化
                    Initialize();


                    pushEnterF = false;

                }
            }
            if (BossNumF >= 3)
            {
                senniF = 4;
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    pushEnterF = true;
                }
                else if (!Keyboard.GetState().IsKeyDown(Keys.Enter) && pushEnterF)
                {
                    //初期化
                    Initialize();


                    pushEnterF = false;
                    //senniF = 2;

                }

            }

            Console.WriteLine("pos:" + tokeiPos);






            if (senniF == 2)
            {
                //時計
                if (!chronoF)
                {
                    tokeiPrefabTime++;
                    if (tokeiPrefabTime > 480)
                    {
                        tokeiPos = new Vector2(750, r.Next(30, 500));

                        tokeiPrefabF = true;
                        tokeiPrefabTime = 0;

                    }

                    if (tokeiPrefabF)
                    {
                        tokeiPos += tokeiVel * tokeiSpeed;
                        if (tokeiPos.X < -10)
                        {
                            tokeiPrefabF = false;
                        }
                    }
                }
                else
                {

                    chronoTime--;
                    if (chronoTime < 0)
                    {
                        chronoF = false;
                        tokeiPrefabTime = 0;
                        chronoTime = 180;
                    }
                }


                Console.WriteLine(dyunEnemySize + ":" + dyunEnemySize);

                //アニメーション プレイヤー
                playerAnimaTime++;
                if (playerAnimaTime >= 5)
                {
                    playerAnimaTime = 0;
                    if (playerAnimaSum < 2)
                    {
                        playerAnimaSum++;
                    }
                    else
                    {
                        playerAnimaSum = 0;
                    }
                }

                //敵
                for (int i = 0; i < enemyTamaF.Length; i++)
                {

                    if (enemyDaedF[i])
                    {
                        if (enemyAlpha[i] >= 0)
                        {
                            enemyAlpha[i] -= 8;
                            enemyAnimaSize[i] += 1;

                        }
                        else
                        {
                            enemyAnimaEnd[i] = true;
                            if (BossEnemyF[i])
                            {
                                Debug.WriteLine(i + ":" + enemyAnimaEnd[i]);

                                BossNumF++;
                                BossEnemyF[i] = false;
                            }
                        }
                    }
                    else if (!(afterEnemyHp[i] == enemyHp[i]))
                    {
                        enemyDamegeAnimeF[i] = 1;
                    }

                    if (!enemyDaedF[i])
                    {
                        if (enemyDamegeAnimeF[i] > 0 && enemyDamegeAnimeF[i] % 7 == 0)
                        {
                            enemyDamegeAnimeF[i]++;
                            enemyAlpha[i] = 255;
                        }
                        else if (enemyDamegeAnimeF[i] > 0)
                        {
                            enemyDamegeAnimeF[i]++;
                            enemyAlpha[i] = 100;
                        }
                        if (enemyDamegeAnimeF[i] > 14)
                        {
                            enemyDamegeAnimeF[i] = 0;
                            enemyAlpha[i] = 255;
                        }
                    }
                    else
                    {
                        enemyDamegeAnimeF[i] = 0;

                    }

                    //switch (enemyDamegeAnimeF[i])
                    //{
                    //    case 0:
                    //        break;

                    //    case 1:
                    //    case 2:
                    //    case 3:
                    //    case 4:
                    //    case 5:
                    //    case 6:
                    //        enemyDamegeAnimeF[i]++;
                    //        enemyAlpha[i] = 100;
                    //        break;

                    //    default:
                    //        enemyDamegeAnimeF[i] = 0;
                    //        enemyAlpha[i] = 255;
                    //        break;

                    //}


                }

                //移動
                playerVel = Vector2.Zero;
                if (!playerDaedF)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.D) && playerPos.X < 730)
                    {
                        playerVel.X = 1.0f;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.A) && playerPos.X > 5)
                    {
                        playerVel.X = -1.0f;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.W) && playerPos.Y > 8)
                    {
                        playerVel.Y = -1.0f;
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.S) && playerPos.Y < 530)
                    {
                        playerVel.Y = 1.0f;

                    }


                }

                if (playerVel.Length() != 0)
                {
                    playerVel.Normalize();
                }
                float speed = 5.0f;
                playerPos += playerVel * speed;



                if (playerDamageF)
                {
                    playerDamageAnimeTime++;

                    if (playerDamageAnimeTime % 7 == 0)
                    {
                        playerAlpha = 255;
                    }
                    else
                    {
                        playerAlpha = 75;
                    }

                    if (playerDamageAnimeTime > 20)
                    {
                        playerDamageAnimeTime = 0;
                        playerDamageF = false;
                        playerAlpha = 255;
                    }

                }

                if (playerDaedF)
                {
                    if (playerAlpha >= 0)
                    {
                        playerAlpha -= 8;
                        playerAnimaSize += 1;

                    }
                    else
                    {
                        senniF = 3;
                        playerAnimaEnd = true;

                    }

                }

                //敵

                if (!chronoF)
                {
                    //どゅん
                    dyunEnemyTime++;
                    if (dyunEnemyTime < 20)
                    {
                        dyunEnemySize--;
                    }
                    else
                    {
                        dyunEnemySize += 3;

                    }
                    if (dyunEnemyTime > 25)
                    {
                        dyunEnemySize = 0;

                        dyunEnemyTime = 0;
                    }

                    enemySyurui++;
                    for (int i = 0; i < enemyTamaF.Length; i++)
                    {
                        if (!enemyDaedF[i])
                        {

                            if (BossEnemyF[i] && enemyPos[i].X < 760)
                            {

                            }
                            else
                            {
                                // enemyVel[i].Normalize();
                                enemyPos[i] += enemyVel[i] * enemySpeed;




                                if (enemyPos[i].Y < 30 || enemyPos[i].Y > 550)
                                {
                                    enemyVel[i].Y = -enemyVel[i].Y;
                                }
                            }
                        }


                        if (BossEnemyF[i])
                        {
                            enemyTamaSecond++;


                            if (enemyTamaSecond > 50)
                            {
                                if (!enemyTamaF[i])
                                {
                                    enemyTamaSecond = 0;
                                    enemyTamaF[i] = true;
                                    enemyTamaPos[i] = new Vector2(enemyPos[i].X - 50, enemyPos[i].Y + 24);
                                    enemyTamaVel[i].X = -1.0f;

                                }
                            }


                        }
                    }


                    //プレイヤーダメージ

                    if (!playerDaedF)
                    {


                        float length = 0;

                        for (int i = 0; i < enemyTamaF.Length; i++)
                        {
                            length = (playerPos - enemyPos[i]).Length();

                            if (length < Radius6464)
                            {
                                if (!playerDamageF && !enemyDaedF[i])
                                {

                                    playerHp--;
                                    enemyDaedF[i] = true;
                                    playerDamageF = true;
                                }

                            }

                            length = (playerPos - enemyTamaPos[i]).Length();

                            if (length < Radius6406)
                            {
                                if (!playerDamageF && enemyTamaF[i])
                                {

                                    playerHp--;
                                    enemyTamaF[i] = false;
                                    playerDamageF = true;
                                }

                            }

                            length = (playerPos - tokeiPos).Length();

                            if (length < Radius6464 && tokeiPrefabF)
                            {
                                chronoF = true;
                                tokeiPrefabF = false;
                                tokeiPos.Y = -10;


                            }
                        }

                        if (playerHp <= 0)
                        {
                            playerDaedF = true;
                        }
                    }



                    for (int i = 0; i < enemyTamaF.Length; i++)
                    {
                        if (enemyTamaF[i])
                        {
                            //進む
                            enemyTamaPos[i] += enemyTamaVel[i] * tamaSpeed;
                            if (enemyTamaVel[i].X > 0 && enemyTamaPos[i].X > graphics.PreferredBackBufferWidth + 20)
                            {
                                enemyTamaF[i] = false;
                            }
                            if (enemyTamaVel[i].X < 0 && enemyTamaPos[i].X < -10)
                            {
                                enemyTamaF[i] = false;
                            }
                        }
                    }

                    //増殖
                    if (enemyPrefab02F < 3)
                    {
                        enemyPrefabTime++;
                    }
                    for (int i = 0; i < enemyTamaF.Length; i++)
                    {
                        if (enemyPrefabTime > 30 && !enemyPrafabF[i])
                        {
                            enemyAnimaEnd[i] = false;

                            enemyDaedF[i] = false;
                            enemyPrafabF[i] = true;

                            enemyAlpha[i] = 255;
                            enemyAnimaSize[i] = 0;


                            if (enemySyurui > 1200)
                            {


                                switch (enemyPrefab02F)
                                {
                                    case 0:
                                        enemyPrefab02F = 1;
                                        break;
                                    case 1:
                                        BossEnemyF[i] = true;

                                        enemyPos[i] = new Vector2(graphics.PreferredBackBufferWidth - 10, 100);
                                        enemyVel[i].Y = 0;
                                        enemyPrefab02F++;
                                        break;
                                    case 2:
                                        BossEnemyF[i] = true;

                                        enemyPos[i] = new Vector2(graphics.PreferredBackBufferWidth - 10, 300);
                                        enemyVel[i].Y = 0;
                                        enemyPrefab02F++;
                                        break;
                                    case 3:
                                        BossEnemyF[i] = true;

                                        enemyPos[i] = new Vector2(graphics.PreferredBackBufferWidth - 10, 500);
                                        enemyVel[i].Y = 0;
                                        enemyPrefab02F++;
                                        enemyPrefabTime = 0;
                                        break;

                                }



                            }
                            if (1200 >= enemySyurui && enemySyurui > 600)
                            {
                                int velY = r.Next(0, 2);
                                if (velY == 0)
                                {
                                    enemyVel[i].Y = 1;
                                    enemyPos[i] = new Vector2(graphics.PreferredBackBufferWidth - 10, r.Next(30, 500 + 1));
                                    enemyPrefabTime = 0;

                                }
                                else
                                {
                                    enemyVel[i].Y = -1;
                                    enemyPos[i] = new Vector2(graphics.PreferredBackBufferWidth - 10, r.Next(30, 500 + 1));
                                    enemyPrefabTime = 0;


                                }

                            }
                            if (enemySyurui < 600)
                            {
                                enemyPos[i] = new Vector2(graphics.PreferredBackBufferWidth - 10, r.Next(30, 500 + 1));
                                enemyPrefabTime = 0;

                            }






                            if (BossEnemyF[i])
                            {
                                enemyHp[i] = 7;
                            }
                            else
                            {
                                enemyHp[i] = 2;
                            }
                        }
                        if (enemyPos[i].X < -10)
                        {
                            enemyPrafabF[i] = false;
                        }
                    }
                }

                //攻撃
                if (Keyboard.GetState().IsKeyDown(Keys.J))
                {

                    for (int i = 0; i < playerTamaF.Length; i++)
                    {
                        if (settim + 200 < gameTime.TotalGameTime.TotalMilliseconds)
                        {
                            if (!playerTamaF[i])
                            {
                                settim = gameTime.TotalGameTime.TotalMilliseconds;
                                playerTamaF[i] = true;

                                playerTamaPos[i] = new Vector2(playerPos.X + 50, playerPos.Y + 24);
                                playerTamaVel[i].X = 1.0f;
                            }
                        }
                    }
                }
                if (Keyboard.GetState().IsKeyDown(Keys.K))
                {
                    bool xyF = false;

                    for (int i = 0; i < playerTamaF.Length; i++)
                    {
                        if (settim + 600 < gameTime.TotalGameTime.TotalMilliseconds)
                        {
                            if (!playerTamaF[i])
                            {
                                playerTamaF[i] = true;

                                if (xyF)
                                {
                                    playerTamaPos[i] = new Vector2(playerPos.X + 50, playerPos.Y + 50);
                                    xyF = false;
                                    settim = gameTime.TotalGameTime.TotalMilliseconds;
                                }
                                else
                                {
                                    playerTamaPos[i] = new Vector2(playerPos.X + 50, playerPos.Y - 3);
                                    xyF = true;
                                }

                                playerTamaVel[i].X = 1.0f;
                            }
                        }
                    }

                }




                for (int i = 0; i < playerTamaF.Length; i++)
                {
                    if (playerTamaF[i])
                    {
                        //進む
                        playerTamaPos[i] += playerTamaVel[i] * tamaSpeed;
                        if (playerTamaVel[i].X > 0 && playerTamaPos[i].X > graphics.PreferredBackBufferWidth + 50)
                        {
                            playerTamaF[i] = false;
                        }
                        if (playerTamaVel[i].X < 0 && playerTamaPos[i].X < -10)
                        {
                            playerTamaF[i] = false;
                        }
                    }
                }





                // Debug.WriteLine(i + ":" + enemyDaedF[i]+":"+ enemyPrafabF[i]);





                //敵 当たり判定移動
                //モグラたたき x150 700 y30 500
                for (int e = 0; e < enemyTamaF.Length; e++)
                {
                    afterEnemyHp[e] = enemyHp[e];

                    if (enemyDaedF[e] && enemyAnimaEnd[e])
                    {

                        enemyPrafabF[e] = false;
                    }
                    else
                    {
                        if (enemyHp[e] <= 0)
                        {
                            enemyDaedF[e] = true;

                        }

                        //衝突判定 

                        if (!enemyDaedF[e])
                        {
                            float[] length = new float[20];
                            for (int t = 0; t < playerTamaF.Length; t++)
                            {
                                length[t] = (enemyPos[e] - playerTamaPos[t]).Length();
                                if (length[t] <= Radius6406)
                                {

                                    if (playerTamaF[t])
                                    {

                                        enemyHp[e]--;

                                    }
                                    playerTamaF[t] = false;

                                }
                            }
                            /*
                            float x = enemy01Pos.X  - tamaPos[i].X ;
                            float y = enemy01Pos.Y - tamaPos[i].Y;
                           double length = System.Math.Sqrt(x * x + y * y);

                            if (length  <= radiusSum)
                            {
                                tamaF[i] =false;
                                enemy01Hp--;
                            }
                            */
                        }
                    }

                }


            }
            Console.WriteLine(tokeiPrefabTime);
            //pushEnterF = false;
            // Debug.WriteLine("out:" + pushEnterF);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            //黒くする




            // TODO: Add your drawing code here


            spriteBatch.Begin();

            //背景
            spriteBatch.Draw(BgDai01, BgDai01Pos, Color.White * 0.1f);
            spriteBatch.Draw(BgDai02, BgDai02Pos, Color.White * 0.1f);
            spriteBatch.Draw(BgSyou01, BgSyou01Pos, Color.White * 0.3f);
            spriteBatch.Draw(BgSyou02, BgSyou02Pos, Color.White * 0.3f);


            if (chronoF)
            {
                spriteBatch.Draw(BgBoard, new Rectangle(0, 0, 800, 600), Color.Black * (130 / 255f));

            }

            //時計
            if (tokeiPrefabF)
            {
                spriteBatch.Draw(tokei, tokeiPos, Color.White);
            }





            for (int i = 0; i < enemyTamaF.Length; i++)
            {
                if (enemyTamaF[i])
                {
                    spriteBatch.Draw(tama, enemyTamaPos[i], Color.Red);
                }


                //敵
                if (!enemyAnimaEnd[i])
                {
                    //衝突判定直す


                    spriteBatch.Draw(enemy01, new Rectangle((int)enemyPos[i].X - 20, (int)enemyPos[i].Y - 23, 64 + enemyAnimaSize[i] + dyunEnemySize, 64 + enemyAnimaSize[i] + dyunEnemySize), Color.White * (enemyAlpha[i] / 255f));

                    if (BossEnemyF[i])
                    {
                        spriteBatch.Draw(enemy01, new Rectangle((int)enemyPos[i].X - 20, (int)enemyPos[i].Y - 23, 64 + enemyAnimaSize[i] + dyunEnemySize, 64 + enemyAnimaSize[i] + dyunEnemySize), Color.Red * (enemyAlpha[i] / 255f));

                    }
                }
            }

            if (senniF == 3)
            {
                spriteBatch.Draw(BgBoard, new Rectangle(0, 0, 800, 600), Color.Black * (130 / 255f));

            }

            //プレイヤー
            if (!playerAnimaEnd && senniF == 2 || senniF == 4)
            {
                spriteBatch.Draw(player, new Rectangle((int)playerPos.X, (int)playerPos.Y, 64 + playerAnimaSize, 64 + playerAnimaSize), new Rectangle(64 * playerAnimaSum, 0, 64, 64), Color.White * (playerAlpha / 255f));
            }



            //弾

            for (int i = 0; i < playerTamaF.Length; i++)
            {
                if (playerTamaF[i])
                {
                    spriteBatch.Draw(tama, playerTamaPos[i], Color.White);
                }
            }



            //UI
            if (senniF == 0)
            {
                spriteBatch.Draw(title, new Rectangle((int)titlePos.X, (int)titlePos.Y, 480 + dyunAnimeSize, 250 + dyunAnimeSize), Color.White);
                spriteBatch.Draw(pushEnter, pushEnterPos, Color.White);

            }
            if (senniF == 1)
            {
                spriteBatch.Draw(sousa, sousaPos, Color.White);
                spriteBatch.Draw(tokei, new Vector2(190, 375), Color.White);
                spriteBatch.Draw(pushEnter, new Vector2(230, 490), Color.White);


            }
            if (senniF == 3)
            {
                spriteBatch.Draw(gameOver, gameOverPos, Color.White);

            }
            if (senniF == 4)
            {
                spriteBatch.Draw(BgBoard, new Rectangle(0, 0, 800, 600), Color.White * (170 / 255f));

                spriteBatch.Draw(gameClear, gameClearPos, Color.White);

            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
