using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System;

namespace Gra
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int width;
        int height;
        Random random = new Random();
        //Timer
        int counter = 1;
        int counter2 = 1;
        int counter3 = 1;
        int limit = 30; //zmiana
        int limit2 = 50;
        int limit3 = 30;
        float countDuration1s = 1f; //1s
        float countDuration3s = 3f; //3s
        float countDuration13s = 1f;
        float currentTime = 0f;
        float currentTime2 = 0f;
        float currentTime3 = 0f;
        //Controll panel
        Texture2D panelTexture;
        Rectangle panelPosition;
        Texture2D gaugeTexture;
        Rectangle gaugePosition;
        Texture2D pointerTexture;
        Rectangle pointerPosition;
        Texture2D downTexture;
        Rectangle downPosition;
        Texture2D upTexture;
        Rectangle upPosition;
        Texture2D leftTexture;
        Rectangle leftPosition;
        Texture2D rightTexture;
        Rectangle rightPosition;
        Texture2D shootTexture;
        Rectangle shootPosition;
        Texture2D startTexture;
        Rectangle startPosition;
        SpriteFont tekst;
        int life = 3;
        int point = 0;
        //Raider and bullet
        Texture2D raiderTexture;
        Rectangle raiderPosition;
        Color[] raiderTextureData;
        Texture2D raiderMoveTexture;
        Rectangle raiderMovePosition;
        Texture2D raiderMoveLTexture;
        Rectangle raiderMoveLPosition;
        Texture2D raiderMoveRTexture;
        Rectangle raiderMoveRPosition;
        Boolean moveR = false;
        Boolean moveL = false;
        Texture2D bulletTexture;
        Rectangle bulletPosition;
        Boolean shoot = false;
        Boolean dead = false;
        Texture2D explosionTexture;
        Rectangle explosionPosition;
        Boolean hit = false;
        //Background
        int downY = 3;
        Texture2D fuelTexture;
        Rectangle fuelPosition;
        int fuelX  ,fuelY ;
        Texture2D jetLeftTexture;
        Rectangle jetLeftPosition;
        int jetLeftX , jetLeftY , jetLeftMove = 5;
        Texture2D jetRightTexture;
        Rectangle jetRightPosition;
        int jetRightX , jetRightY , jetRightMove = 5;
        Texture2D edgeLeftTexture;
        Rectangle edgeLeftPosition;
        Color[] edgeLeftTextureData;
        Texture2D edgeRightTexture;
        Rectangle edgeRightPosition;
        Color[] edgeRightTextureData;
        Texture2D ship1Texture;
        Texture2D ship1RTexture;
        Rectangle ship1Position;
        Rectangle ship1RPosition;
        int ship1X, ship1Y, ship1Move = 2;
        Boolean ship1LtR = true;
        Texture2D ship2Texture;
        Texture2D ship2RTexture;
        Rectangle ship2Position;
        Rectangle ship2RPosition;
        int ship2X, ship2Y;
        Boolean ship2LtR = false;
        Texture2D heliLTexture;
        Rectangle heliLPosition;
        Texture2D heliL2Texture;
        Rectangle heliL2Position;
        int heliLX, heliLY , heliMove = 2;
        Boolean heliMoveEffect = true;
        Texture2D edgev2LeftTexture;
        Rectangle edgev2LeftPosition;
        Texture2D edgev2RightTexture;
        Rectangle edgev2RightPosition;
        Texture2D bridgeTexture;
        Rectangle bridgePosition;
        Boolean bridgeshow = true;
        //Menu and GameOver
        Boolean endGame = false;
        Boolean pause = true;
        Texture2D gameoverTexture;
        Rectangle gameoverPosition;
        //Sound
        List<SoundEffect> soundEffects;
        Boolean musicPlay = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            soundEffects = new List<SoundEffect>();

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            width = graphics.GraphicsDevice.Viewport.Width;
            height = graphics.GraphicsDevice.Viewport.Height;
            //Loading texture
            panelTexture = Content.Load<Texture2D>("panel");
            gaugeTexture = Content.Load<Texture2D>("gauge");
            pointerTexture = Content.Load<Texture2D>("pointer");
            downTexture = Content.Load<Texture2D>("down");
            upTexture = Content.Load<Texture2D>("up");
            leftTexture = Content.Load<Texture2D>("left");
            rightTexture = Content.Load<Texture2D>("right");
            shootTexture = Content.Load<Texture2D>("shoot");
            startTexture = Content.Load<Texture2D>("start");
            tekst = Content.Load<SpriteFont>("tekst");

            raiderTexture = Content.Load<Texture2D>("raider");
            raiderMoveTexture = Content.Load<Texture2D>("raider2");
            raiderMoveRTexture = Content.Load<Texture2D>("raider_mv");
            raiderMoveLTexture = Content.Load<Texture2D>("raider_mvL");
            bulletTexture = Content.Load<Texture2D>("bullet");
            explosionTexture = Content.Load<Texture2D>("explosion");
            fuelTexture = Content.Load<Texture2D>("fuel");
            jetLeftTexture = Content.Load<Texture2D>("jetLeft");
            jetRightTexture = Content.Load<Texture2D>("jetRight");
            edgeLeftTexture = Content.Load<Texture2D>("edge");
            edgeRightTexture = Content.Load<Texture2D>("edge2");
            ship1Texture = Content.Load<Texture2D>("shipLeft");
            ship1RTexture = Content.Load<Texture2D>("shipRight");
            ship2Texture = Content.Load<Texture2D>("shipLeft");
            ship2RTexture = Content.Load<Texture2D>("shipRight");
            heliLTexture = Content.Load<Texture2D>("heliL");
            heliL2Texture = Content.Load<Texture2D>("heliL2");
            edgev2LeftTexture = Content.Load<Texture2D>("edgev2");
            edgev2RightTexture = Content.Load<Texture2D>("edgev2");
            bridgeTexture = Content.Load<Texture2D>("bridge");
            gameoverTexture = Content.Load<Texture2D>("gameover1");
            //Loading sound
            soundEffects.Add(Content.Load<SoundEffect>("engineSound"));
            soundEffects.Add(Content.Load<SoundEffect>("fuelSound"));
            soundEffects.Add(Content.Load<SoundEffect>("hitSound"));
            soundEffects.Add(Content.Load<SoundEffect>("shootSound"));

            soundEffects[0].Play();
            var instance = soundEffects[0].CreateInstance();
            instance.IsLooped = true;
            instance.Play();
            //soundEffects[0].CreateInstance().Play();
            SoundEffect.MasterVolume = 0.0f;

            //Set rectangle - position, width nad height texture (skalowanie na zasacie proporci x = (szerokosc tekstury * szerokosc ekranu) / szerokosc na jakie bylo robione))
            panelPosition = new Rectangle(0, height - panelTexture.Height * height / 1920, (1080 * width) / 1080, (410 * height) / 1920);
            leftPosition = new Rectangle(panelPosition.X, panelPosition.Y + (panelTexture.Height * height / 1920) / 2 - (leftTexture.Height * height / 1920) / 2, (200 * width) / 1080, (200 * height) / 1920);
            downPosition = new Rectangle(leftPosition.X + leftTexture.Width * width / 1080, panelPosition.Y + upTexture.Height * height / 1920, (200 * width) / 1080, (200 * height) / 1920);
            upPosition = new Rectangle(leftPosition.X + leftTexture.Width * width / 1080, panelPosition.Y, (200 * width) / 1080, (200 * height) / 1920);
            rightPosition = new Rectangle(upPosition.X + upTexture.Width * width / 1080, panelPosition.Y + (panelTexture.Height * height / 1920) / 2 - (rightTexture.Height * height / 1920) / 2, (200 * width) / 1080, (200 * height) / 1920);
            shootPosition = new Rectangle(width - shootTexture.Width * width / 1080, panelPosition.Y + (panelTexture.Height * height / 1920) / 2 - (shootTexture.Height * height / 1920) / 2, (200 * width) / 1080, (200 * height) / 1920);
            gaugePosition = new Rectangle((rightPosition.X + rightTexture.Width * width / 1080 + shootPosition.X) / 2 - (gaugeTexture.Width * width / 1080) / 2,rightPosition.Y - (gaugeTexture.Height * height / 1920) / 2,(300 * width) / 1080, (80 * height) / 1920);
            pointerPosition = new Rectangle(gaugePosition.X + gaugeTexture.Width * width / 1080 - pointerTexture.Width * width / 1080, gaugePosition.Y, (10 * width) / 1080, (80 * height) / 1920);
            startPosition = new Rectangle(gaugePosition.X + (gaugeTexture.Width * width / 1080) / 2 - (startTexture.Width * width / 1080) / 2,panelPosition.Y + panelTexture.Height * height / 1920 - (startTexture.Height * height / 1920) - (startTexture.Height * height / 1920) / 2, (150 * width) / 1080, (100 * height) / 1920);

            edgeLeftPosition = new Rectangle(0, 0 - edgeLeftTexture.Height * height/ 1920 + height - panelTexture.Height * height/1920, (300 * width) / 1080, (8000 * height) / 1920);
            edgeLeftTextureData = new Color[(edgeLeftTexture.Width) * (edgeLeftTexture.Height)];
            edgeLeftTexture.GetData(edgeLeftTextureData);
            edgeRightPosition = new Rectangle(width - edgeRightTexture.Width * width / 1080,0 - edgeRightTexture.Height * height / 1920 + height - panelTexture.Height * height / 1920, (300 * width) / 1080, (8000 * height) / 1920);
            edgeRightTextureData = new Color[(edgeRightTexture.Width) * (edgeRightTexture.Height)];
            edgeRightTexture.GetData(edgeRightTextureData);
            edgev2LeftPosition = new Rectangle(edgeLeftPosition.X, edgeLeftPosition.Y - (edgev2LeftTexture.Height * height / 1920), (300 * width) / 1080, (3000 * height) / 1920);
            edgev2RightPosition = new Rectangle(edgeRightPosition.X, edgeRightPosition.Y - (edgev2RightTexture.Height * height / 1920), (300 * width) / 1080, (3000 * height) / 1920);
            bridgePosition = new Rectangle(edgev2LeftPosition.X + edgev2LeftTexture.Width * width / 1080, edgev2LeftPosition.Y, (510 * width) / 1080, (200 * height) / 1920);
            raiderPosition = new Rectangle(graphics.GraphicsDevice.Viewport.Width / 2 - (raiderTexture.Width * width / 1080) / 2,panelPosition.Y - (raiderTexture.Height * height / 1920) * 2, (105 * width) / 1080, (112 * height) / 1920);
            raiderTextureData = new Color[(raiderTexture.Width ) * (raiderTexture.Height)];
            raiderTexture.GetData(raiderTextureData);
            raiderMovePosition = new Rectangle(graphics.GraphicsDevice.Viewport.Width / 2 - (raiderMoveTexture.Width * width / 1080) / 2, panelPosition.Y - (raiderMoveTexture.Height * height / 1920) * 2, (105 * width) / 1080, (112 * height) / 1920);
            raiderMoveRPosition = new Rectangle(graphics.GraphicsDevice.Viewport.Width / 2 - (raiderMoveRTexture.Width * width / 1080) / 2, panelPosition.Y - (raiderMoveRTexture.Height * height / 1920) * 2, (75 * width) / 1080, (112 * height) / 1920);
            raiderMoveLPosition = new Rectangle(graphics.GraphicsDevice.Viewport.Width / 2 - (raiderMoveLTexture.Width * width / 1080) / 2, panelPosition.Y - (raiderMoveLTexture.Height * height / 1920) * 2, (75 * width) / 1080, (112 * height) / 1920);
            bulletPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (5 * width) / 1080, (20 * height) / 1920);
            explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);

            fuelX = random.Next(edgeLeftPosition.X + edgeLeftTexture.Width * width / 1080, width - edgeRightTexture.Width * width / 1080 - fuelTexture.Width * width / 1080);
            fuelY = random.Next(-40 - fuelTexture.Height, -20 - fuelTexture.Height);
            fuelPosition = new Rectangle(fuelX, fuelY, (90 * width) / 1080, (150 * height) / 1920);
            jetLeftPosition = new Rectangle(jetLeftX, jetLeftY, (80 * width) / 1080, (45 * height) / 1920);
            jetRightPosition = new Rectangle(jetRightX, jetRightY, (80 * width) / 1080, (45 * height) / 1920);
            ship1X = width / 2 - ship1Texture.Width;
            ship1Y = random.Next(-500 - ship1Texture.Height, -100 - ship1Texture.Height);
            ship1Position = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
            ship1RPosition = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
            ship2X = width / 2 - ship2Texture.Width;
            ship2Y = random.Next(-500 - ship2Texture.Height, -100 - ship2Texture.Height);
            ship2Position = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
            ship2RPosition = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
            heliLX = random.Next(edgeLeftPosition.X + edgeLeftTexture.Width * width / 1080 , width / 3);
            heliLY = random.Next(-500, -100);
            heliLPosition = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
            heliL2Position = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
            gameoverPosition = new Rectangle(width / 2 - (gameoverTexture.Width * width / 1080) / 2, height / 2 - panelTexture.Height * height / 1920, (850 * width) / 1080, (480 * height) / 1920);
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();
            //timer
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (counter >= limit)
            {
                counter = 0;
            }
            currentTime2 += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(counter2 >= limit2)
            {
                counter2 = 0;
            }
            currentTime3 += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (counter3 >= limit3)
            {
                counter3 = 0;
            }
            //sound

            //controll
            TouchCollection touchPlaces = TouchPanel.GetState();
            foreach (TouchLocation touch in touchPlaces)
            {
                Vector2 touchPosition = touch.Position;
                if (touch.State == TouchLocationState.Moved)
                {
                    if (touchPosition.X > leftPosition.X && touchPosition.X < leftPosition.X + leftPosition.Width && touchPosition.Y > leftPosition.Y && touchPosition.Y < leftPosition.Y + leftPosition.Height && raiderPosition.X > 0 && dead == false && pause == false)
                    {
                        raiderPosition.X -= 5;
                        raiderMovePosition.X -= 5;
                        raiderMoveRPosition.X -= 5;
                        raiderMoveLPosition.X -= 5;
                        moveL = true;
                        if (shoot == false)
                        { 
                            bulletPosition.X -= 5;
                            explosionPosition.X -= 5;
                        }
                    }
                    if (touchPosition.X > rightPosition.X && touchPosition.X < rightPosition.X + rightPosition.Width && touchPosition.Y > rightPosition.Y && touchPosition.Y < rightPosition.Y + rightPosition.Height && raiderPosition.X < width - raiderTexture.Width * width / 1080 && dead == false && pause == false)
                    {
                        raiderPosition.X += 5;
                        raiderMovePosition.X += 5;
                        raiderMoveRPosition.X += 5;
                        raiderMoveLPosition.X += 5;
                        moveR = true;
                        if (shoot == false)
                        {
                            bulletPosition.X += 5;
                            explosionPosition.X += 5;
                        }
                    }
                    if (touchPosition.X > upPosition.X && touchPosition.X < upPosition.X + upPosition.Width && touchPosition.Y > upPosition.Y && touchPosition.Y < upPosition.Y + upPosition.Height && raiderPosition.Y > 0 && dead == false && pause == false)
                    {
                        downY = 6;
                    }
                    if (touchPosition.X > downPosition.X && touchPosition.X < downPosition.X + downPosition.Width && touchPosition.Y > downPosition.Y && touchPosition.Y < downPosition.Y + upPosition.Height && raiderPosition.Y + (raiderTexture.Height * height / 1920) < panelPosition.Y && dead == false && pause == false)
                    {
                        downY = 1;
                    }
                }
                if(touch.State == TouchLocationState.Pressed)
                {
                    if(touchPosition.X > shootPosition.X && touchPosition.X < shootPosition.X + shootPosition.Width && touchPosition.Y > shootPosition.Y && touchPosition.Y < shootPosition.Y + shootPosition.Height && bulletPosition.Y > raiderPosition.Y && dead == false && pause == false)
                    {
                        shoot = true;
                        soundEffects[3].Play();
                    }
                    if (touchPosition.X > startPosition.X && touchPosition.X < startPosition.X + startPosition.Width && touchPosition.Y > startPosition.Y && touchPosition.Y < startPosition.Y + startPosition.Height && endGame == true)
                    {
                        endGame = false;
                        point = 0;
                        life = 4;
                        dead = true;
                        pointerPosition = new Rectangle(gaugePosition.X + gaugeTexture.Width * width / 1080 - pointerTexture.Width * width / 1080, gaugePosition.Y, (10 * width) / 1080, (80 * height) / 1920);
                    }
                    if (touchPosition.X > startPosition.X && touchPosition.X < startPosition.X + startPosition.Width && touchPosition.Y > startPosition.Y && touchPosition.Y < startPosition.Y + startPosition.Height && endGame == false)
                    {
                        pause = !pause;
                        if (pause == true)
                            SoundEffect.MasterVolume = 0.0f;
                    }
                }
                if(touch.State == TouchLocationState.Released)
                {
                    if (touchPosition.X > leftPosition.X && touchPosition.X < leftPosition.X + leftPosition.Width && touchPosition.Y > leftPosition.Y && touchPosition.Y < leftPosition.Y + leftPosition.Height && raiderPosition.X > 0)
                    {
                        moveL = false;
                    }
                    if (touchPosition.X > rightPosition.X && touchPosition.X < rightPosition.X + rightPosition.Width && touchPosition.Y > rightPosition.Y && touchPosition.Y < rightPosition.Y + rightPosition.Height && raiderPosition.X < width - raiderTexture.Width * width / 1080)
                    {
                        moveR = false;
                    }
                    if (touchPosition.X > upPosition.X && touchPosition.X < upPosition.X + upPosition.Width && touchPosition.Y > upPosition.Y && touchPosition.Y < upPosition.Y + upPosition.Height && raiderPosition.Y > 0)
                    {
                        downY = 3;
                    }
                    if (touchPosition.X > downPosition.X && touchPosition.X < downPosition.X + downPosition.Width && touchPosition.Y > downPosition.Y && touchPosition.Y < downPosition.Y + upPosition.Height && raiderPosition.Y + (raiderTexture.Height * height / 1920) < panelPosition.Y)
                    {
                        downY = 3;
                    }
                }
            }
            //move
            if(life <= 0 || pointerPosition.X < gaugePosition.X)
            {
                endGame = true;
                SoundEffect.MasterVolume = 0.0f;
            }
            if(dead == false && endGame == false && pause == false)
            {
                SoundEffect.MasterVolume = 1.0f;
                edgeLeftPosition.Y += downY;
                edgeRightPosition.Y += downY;
                edgev2LeftPosition.Y += downY;
                edgev2RightPosition.Y += downY;
                bridgePosition.Y += downY;
                fuelPosition.Y += downY;
                jetLeftPosition.Y += downY;
                jetLeftPosition.X += jetLeftMove;
                jetRightPosition.Y += downY;
                jetRightPosition.X -= jetRightMove;
                ship1Position.Y += downY;
                ship1RPosition.Y += downY;
                ship2Position.Y += downY;
                ship2RPosition.Y += downY;
                heliLPosition.Y += downY;
                heliL2Position.Y += downY;
                if (ship1LtR == true)
                {
                    ship1Position.X += ship1Move;
                    ship1RPosition.X += ship1Move;
                }
                if (ship1LtR == false)
                {
                    ship1Position.X -= ship1Move;
                    ship1RPosition.X -= ship1Move;
                }
                if (ship2LtR == true)
                {
                    ship2Position.X += ship1Move;
                    ship2RPosition.X += ship1Move;
                }
                if (ship2LtR == false)
                {
                    ship2Position.X -= ship1Move;
                    ship2RPosition.X -= ship1Move;
                }
                if(raiderPosition.X > heliLPosition.X && heliLPosition.Y > height / 3)
                {
                    heliLPosition.X += heliMove;
                    heliL2Position.X += heliMove;
                }
            }

            if (currentTime >= countDuration1s)//timer wait 1s and do 
            {
                counter++;
                currentTime -= countDuration1s;
                if(endGame == false && pause == false)
                    pointerPosition.X -= 4;
                heliMoveEffect = !heliMoveEffect;
                if (hit == true)
                {
                    explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);
                    hit = false;
                    shoot = false;
                }
            }
            if(currentTime2 >= countDuration3s)
            {
                counter2++;
                currentTime2 -= countDuration3s;
                if (dead == true)
                {
                    SoundEffect.MasterVolume = 0.0f;
                    edgeLeftPosition = new Rectangle(0, 0-edgeLeftTexture.Height * height / 1920 + height - panelTexture.Height * height / 1920, (300 * width) / 1080, (8000 * height) / 1920);;
                    edgeRightPosition = new Rectangle(width - edgeRightTexture.Width * width / 1080, 0-edgeRightTexture.Height * height / 1920 + height - panelTexture.Height * height / 1920, (300 * width) / 1080, (8000 * height) / 1920);
                    edgev2LeftPosition = new Rectangle(edgeLeftPosition.X, edgeLeftPosition.Y - (edgev2LeftTexture.Height * height / 1920), (300 * width) / 1080, (3000 * height) / 1920);
                    edgev2RightPosition = new Rectangle(edgeRightPosition.X, edgeRightPosition.Y - (edgev2RightTexture.Height * height / 1920), (300 * width) / 1080, (3000 * height) / 1920);
                    bridgePosition = new Rectangle(edgev2LeftPosition.X + edgev2LeftTexture.Width * width / 1080, edgev2LeftPosition.Y, (510 * width) / 1080, (200 * height) / 1920);
                    explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);
                    raiderPosition = new Rectangle(graphics.GraphicsDevice.Viewport.Width / 2 - (raiderTexture.Width * width / 1080) / 2, panelPosition.Y - (raiderTexture.Height * height / 1920) * 2, (105 * width) / 1080, (112 * height) / 1920);
                    raiderMovePosition = new Rectangle(graphics.GraphicsDevice.Viewport.Width / 2 - (raiderMoveTexture.Width * width / 1080) / 2, panelPosition.Y - (raiderMoveTexture.Height * height / 1920) * 2, (105 * width) / 1080, (112 * height) / 1920);
                    raiderMoveRPosition = new Rectangle(graphics.GraphicsDevice.Viewport.Width / 2 - (raiderMoveRTexture.Width * width / 1080) / 2, panelPosition.Y - (raiderMoveRTexture.Height * height / 1920) * 2, (75 * width) / 1080, (112 * height) / 1920);
                    raiderMoveLPosition = new Rectangle(graphics.GraphicsDevice.Viewport.Width / 2 - (raiderMoveLTexture.Width * width / 1080) / 2, panelPosition.Y - (raiderMoveLTexture.Height * height / 1920) * 2, (75 * width) / 1080, (112 * height) / 1920);
                    bulletPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (5 * width) / 1080, (20 * height) / 1920);
                    dead = false;
                    life -= 1;
                    fuelX = random.Next(edgeLeftPosition.X + edgeLeftTexture.Width * width / 1080, width - edgeRightTexture.Width * width / 1080 - fuelTexture.Width * width / 1080);
                    fuelY = random.Next(-40 - fuelTexture.Height, -20 - fuelTexture.Height);
                    fuelPosition = new Rectangle(fuelX, fuelY, (90 * width) / 1080, (150 * height) / 1920);
                    jetLeftPosition = new Rectangle(jetLeftX, jetLeftY, (80 * width) / 1080, (45 * height) / 1920);
                    jetRightPosition = new Rectangle(jetRightX, jetRightY, (80 * width) / 1080, (45 * height) / 1920);
                    ship1X = width / 2 - ship1Texture.Width;
                    ship1Y = random.Next(-40 - ship1Texture.Height, -20 - ship1Texture.Height);
                    ship1Position = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
                    ship1RPosition = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
                    ship2X = width / 2 - ship2Texture.Width;
                    ship2Y = random.Next(-400 - ship2Texture.Height, -200 - ship2Texture.Height);
                    ship2Position = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
                    ship2RPosition = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
                    heliLX = random.Next(edgeLeftPosition.X + edgeLeftTexture.Width * width / 1080 , width / 3);
                    heliLY = random.Next(-500, -200);
                    heliLPosition = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
                    heliL2Position = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
                    // reset enemys bo inaczej wlatuja w strefe respawnu
                }
            }

            if(shoot==true && hit==false)
            {
                bulletPosition.Y -= 20;
                explosionPosition.Y -= 20;
            }
            if(shoot==false)
            {
                bulletPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (5 * width) / 1080, (20 * height) / 1920);
                explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);
            }
            if(bridgeshow==false)
            {
                if (edgev2LeftPosition.Y < 0)
                {
                    bridgePosition = new Rectangle(edgev2LeftPosition.X + edgev2LeftTexture.Width * width / 1080, edgev2LeftPosition.Y, (510 * width) / 1080, (200 * height) / 1920);
                    bridgeshow = true;
                }
            }
                   
            //Rectangle (kolizje)
            if (bulletPosition.Y <= 0)
            {
                shoot = false;
            }
            if (raiderPosition.Intersects(fuelPosition) && pointerPosition.X + pointerTexture.Width < gaugePosition.X + gaugeTexture.Width * width / 1080)
            {
                pointerPosition.X += 1;
                if (currentTime3 >= countDuration13s)//timer wait 1s and do 
                {
                    counter3++;
                    currentTime3 -= countDuration13s;
                    soundEffects[1].Play();
                }
            }
            if(edgeLeftPosition.Y > panelPosition.Y)
            {
                edgeLeftPosition = new Rectangle(edgev2LeftPosition.X, edgev2LeftPosition.Y - edgeLeftTexture.Height * height / 1920, (300 * width) / 1080, (8000 * height) / 1920);
                edgeRightPosition = new Rectangle(edgev2RightPosition.X, edgev2RightPosition.Y - edgeRightTexture.Height * height / 1920, (300 * width) / 1080, (8000 * height) / 1920);
            }
            if(edgev2LeftPosition.Y > panelPosition.Y)
            {
                edgev2LeftPosition = new Rectangle(edgeLeftPosition.X, edgeLeftPosition.Y - (edgev2LeftTexture.Width * width / 1080), (300 * width) / 1080, (1920 * height) / 1920);
                edgev2RightPosition = new Rectangle(edgeRightPosition.X, edgeRightPosition.Y - (edgev2RightTexture.Width * width / 1080), (300 * width) / 1080, (1920 * height) / 1920);
            }
            if (raiderPosition.Intersects(edgev2LeftPosition) || raiderPosition.Intersects(edgev2RightPosition))
            {
                explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);
                dead = true;
            }
            if (IntersectsPixel(raiderPosition, raiderTextureData, edgeLeftPosition, edgeLeftTextureData))
            {
                explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);
                dead = true;
            }
            if (IntersectsPixel(raiderPosition, raiderTextureData, edgeRightPosition, edgeRightTextureData))
            {
                explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);
                dead = true;
            }
            if (fuelPosition.Y > panelPosition.Y)
            {
                fuelX = random.Next(edgeLeftPosition.X + edgeLeftTexture.Width * width / 1080, width - edgeRightTexture.Width * width / 1080 - fuelTexture.Width * width / 1080);
                fuelY = random.Next(-40 - fuelTexture.Height, -20 - fuelTexture.Height);
                fuelPosition = new Rectangle(fuelX, fuelY, (90 * width) / 1080, (150 * height) / 1920);
            }
            if(bulletPosition.Intersects(fuelPosition) && shoot==true && hit == false)
            {
                point += 80;
                fuelX = random.Next(edgeLeftPosition.X + edgeLeftTexture.Width * width / 1080, width - edgeRightTexture.Width * width / 1080 - fuelTexture.Width * width / 1080);
                fuelY = random.Next(-60 - fuelTexture.Height, -40 - fuelTexture.Height);
                fuelPosition = new Rectangle(fuelX, fuelY, (90 * width) / 1080, (150 * height) / 1920);
                hit = true;
                soundEffects[2].Play();
            }
            if(bulletPosition.Intersects(jetLeftPosition) && shoot==true && hit == false)
            {
                point += 100;
                hit = true;
                soundEffects[2].Play();
                jetLeftX = random.Next(-500, -200);
                jetLeftY = random.Next(0, height / 3);
                jetLeftPosition = new Rectangle(jetLeftX, jetLeftY, (80 * width) / 1080, (45 * height) / 1920);
            }
            if(jetLeftPosition.X > width + jetLeftTexture.Width)
            {
                jetLeftX = random.Next(-500, -200);
                jetLeftY = random.Next(0, height / 3);
                jetLeftPosition = new Rectangle(jetLeftX, jetLeftY, (80 * width) / 1080, (45 * height) / 1920);
            }
            if(raiderPosition.Intersects(jetLeftPosition))
            {
                explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);
                dead = true;
                jetLeftX = random.Next(-500, -200);
                jetLeftY = random.Next(0, height / 3);
                jetLeftPosition = new Rectangle(jetLeftX, jetLeftY, (80 * width) / 1080, (45 * height) / 1920);
            }
            if (bulletPosition.Intersects(jetRightPosition) && shoot == true && hit == false)
            {
                point += 100;
                hit = true;
                soundEffects[2].Play();
                jetRightX = random.Next(width, width + 500);
                jetRightY = random.Next(0, height / 3);
                jetRightPosition = new Rectangle(jetRightX, jetRightY, (80 * width) / 1080, (45 * height) / 1920);
            }
            if (jetRightPosition.X < 0 - jetRightTexture.Width)
            {
                jetRightX = random.Next(width, width + 500);
                jetRightY = random.Next(0, height / 3);
                jetRightPosition = new Rectangle(jetRightX, jetRightY, (80 * width) / 1080, (45 * height) / 1920);
            }
            if (raiderPosition.Intersects(jetRightPosition))
            {
                explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);
                dead = true;
                jetRightX = random.Next(width + 50, width + 500);
                jetRightY = random.Next(0, height / 3);
                jetRightPosition = new Rectangle(jetRightX, jetRightY, (80 * width) / 1080, (45 * height) / 1920);
            }
            if(ship1Position.Y > panelPosition.Y)
            {
                ship1X = width / 2 - ship1Texture.Width;
                ship1Y = random.Next(-40 - ship1Texture.Height, -20 - ship1Texture.Height);
                ship1Position = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
                ship1RPosition = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
            }
            if(raiderPosition.Intersects(ship1Position))
            {
                explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);
                dead = true;
                ship1X = width / 2 - ship1Texture.Width;
                ship1Y = random.Next(-60 - ship1Texture.Height, -40 - ship1Texture.Height);
                ship1Position = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
                ship1RPosition = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
            }
            if(bulletPosition.Intersects(ship1Position) && shoot == true && hit == false)
            {
                point += 30;
                hit = true;
                soundEffects[2].Play();
                ship1X = width / 2 - ship1Texture.Width;
                ship1Y = random.Next(-40 - ship1Texture.Height, -20 - ship1Texture.Height);
                ship1Position = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
                ship1RPosition = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
            }
            if(ship1Position.Intersects(edgeLeftPosition) || ship1Position.Intersects(edgeRightPosition) || ship1Position.Intersects(edgev2LeftPosition) || ship1Position.Intersects(edgev2RightPosition))
            {
                ship1LtR = !ship1LtR;
            }
            if (ship2Position.Y > panelPosition.Y)
            {
                ship2X = width / 2 - ship2Texture.Width;
                ship2Y = random.Next(-40 - ship2Texture.Height, -20 - ship2Texture.Height);
                ship2Position = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
                ship2RPosition = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
            }
            if (raiderPosition.Intersects(ship2Position))
            {
                explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);
                dead = true;
                ship2X = width / 2 - ship2Texture.Width;
                ship2Y = random.Next(-40 - ship2Texture.Height, -20 - ship2Texture.Height);
                ship2Position = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
                ship2RPosition = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
            }
            if (bulletPosition.Intersects(ship2Position) && shoot == true && hit == false)
            {
                point += 30;
                hit = true;
                soundEffects[2].Play();
                ship2X = width / 2 - ship2Texture.Width;
                ship2Y = random.Next(-40 - ship2Texture.Height, -20 - ship2Texture.Height);
                ship2Position = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
                ship2RPosition = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
            }
            if (ship2Position.Intersects(edgeLeftPosition) || ship2Position.Intersects(edgeRightPosition) || ship2Position.Intersects(edgev2LeftPosition) || ship2Position.Intersects(edgev2RightPosition))
            {
                ship2LtR = !ship2LtR;
            }
            if(heliLPosition.Y > panelPosition.Y)
            {
                heliLX = random.Next(edgeLeftPosition.X + edgeLeftTexture.Width * width / 1080 , width / 3);
                heliLY = random.Next(-500, -200);
                heliLPosition = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
                heliL2Position = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
            }
            if(raiderPosition.Intersects(heliLPosition))
            {
                explosionPosition = new Rectangle(raiderPosition.X + (raiderTexture.Width * width / 1080) / 2 - (explosionTexture.Width * width / 1080) / 2, raiderPosition.Y + (raiderTexture.Height * height / 1920) / 2, (60 * width) / 1080, (60 * height) / 1920);
                dead = true;
                heliLX = random.Next(edgeLeftPosition.X + edgeLeftTexture.Width * width / 1080 , width / 3);
                heliLY = random.Next(-500, -200);
                heliLPosition = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
                heliL2Position = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
            }
            if(bulletPosition.Intersects(heliLPosition) && shoot == true && hit == false)
            {
                point += 60;
                hit = true;
                soundEffects[2].Play();
                heliLX = random.Next(edgeLeftPosition.X + edgeLeftTexture.Width * width / 1080 , width / 3);
                heliLY = random.Next(-500, -200);
                heliLPosition = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
                heliL2Position = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
            }
            if (bulletPosition.Intersects(bridgePosition) && bridgeshow == true)
            {
                point += 500;
                hit = true;
                soundEffects[2].Play();
                bridgeshow = false;
            }
            if(bridgePosition.Intersects(fuelPosition))
            {
                fuelX = random.Next(edgeLeftPosition.X + edgeLeftTexture.Width * width / 1080, width - edgeRightTexture.Width * width / 1080 - fuelTexture.Width * width / 1080);
                fuelY = random.Next(-40 - fuelTexture.Height, -20 - fuelTexture.Height);
                fuelPosition = new Rectangle(fuelX, fuelY, (90 * width) / 1080, (150 * height) / 1920);
            }
            if(bridgePosition.Intersects(ship1Position))
            {
                ship1X = width / 2 - ship1Texture.Width;
                ship1Y = random.Next(-40 - ship1Texture.Height, -20 - ship1Texture.Height);
                ship1Position = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
                ship1RPosition = new Rectangle(ship1X, ship1Y, (150 * width) / 1080, (75 * height) / 1920);
            }
            if(bridgePosition.Intersects(ship2Position))
            {
                ship2X = width / 2 - ship2Texture.Width;
                ship2Y = random.Next(-40 - ship2Texture.Height, -20 - ship2Texture.Height);
                ship2Position = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
                ship2RPosition = new Rectangle(ship2X, ship2Y, (150 * width) / 1080, (75 * height) / 1920);
            }
            if(bridgePosition.Intersects(heliLPosition))
            {
                heliLX = random.Next(edgeLeftPosition.X + edgeLeftTexture.Width * width / 1080, width / 3);
                heliLY = random.Next(-500, -200);
                heliLPosition = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
                heliL2Position = new Rectangle(heliLX, heliLY, (113 * width) / 1080, (64 * height) / 1920);
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            spriteBatch.Begin();
                if (endGame == false)
                {
                    spriteBatch.Draw(fuelTexture, fuelPosition, Color.White);
                    if (hit == true || dead == true)
                        spriteBatch.Draw(explosionTexture, explosionPosition, Color.White);
                    if (hit == false && dead == false)
                        spriteBatch.Draw(bulletTexture, bulletPosition, Color.White);
                    if (moveR == false && moveL == false && dead == false)
                        spriteBatch.Draw(raiderMoveTexture, raiderMovePosition, Color.White);
                    if (moveR == true && dead == false)
                        spriteBatch.Draw(raiderMoveRTexture, raiderMoveRPosition, Color.White);
                    if (moveL == true && dead == false)
                        spriteBatch.Draw(raiderMoveLTexture, raiderMoveLPosition, Color.White);
                    if (ship1LtR == true)
                        spriteBatch.Draw(ship1Texture, ship1Position, Color.White);
                    if (ship1LtR == false)
                        spriteBatch.Draw(ship1RTexture, ship1RPosition, Color.White);
                    if (ship2LtR == true)
                        spriteBatch.Draw(ship2Texture, ship2Position, Color.White);
                    if (ship2LtR == false)
                        spriteBatch.Draw(ship2RTexture, ship2RPosition, Color.White);
                    spriteBatch.Draw(edgeLeftTexture, edgeLeftPosition, Color.Green);
                    spriteBatch.Draw(edgeRightTexture, edgeRightPosition, Color.Green);
                    spriteBatch.Draw(edgev2LeftTexture, edgev2LeftPosition, Color.White);
                    spriteBatch.Draw(edgev2RightTexture, edgev2RightPosition, Color.White);
                    if (bridgeshow == true)
                        spriteBatch.Draw(bridgeTexture, bridgePosition, Color.White);
                    spriteBatch.Draw(jetLeftTexture, jetLeftPosition, Color.White);
                    spriteBatch.Draw(jetRightTexture, jetRightPosition, Color.White);
                    if (heliMoveEffect == true)
                        spriteBatch.Draw(heliLTexture, heliLPosition, Color.White);
                    if (heliMoveEffect == false)
                        spriteBatch.Draw(heliL2Texture, heliL2Position, Color.White);
                }

                if (endGame == true)
                {
                    spriteBatch.Draw(gameoverTexture,gameoverPosition,Color.White);
                }

            spriteBatch.Draw(panelTexture, panelPosition, Color.White);
            spriteBatch.Draw(pointerTexture, pointerPosition, Color.White);
            spriteBatch.Draw(gaugeTexture, gaugePosition, Color.White);
            spriteBatch.Draw(downTexture, downPosition, Color.White);
            spriteBatch.Draw(upTexture, upPosition, Color.White);
            spriteBatch.Draw(leftTexture, leftPosition, Color.White);
            spriteBatch.Draw(rightTexture, rightPosition, Color.White);
            spriteBatch.Draw(shootTexture, shootPosition, Color.White);
            spriteBatch.Draw(startTexture, startPosition, Color.White);
            spriteBatch.DrawString(tekst, "Score: " + point , new Vector2(gaugePosition.X + (gaugeTexture.Width * width / 1080) / 3, gaugePosition.Y - gaugeTexture.Height/2), Color.Yellow);
            spriteBatch.DrawString(tekst, "Life: " + life, new Vector2(gaugePosition.X + (gaugeTexture.Width * width / 1080) / 3, (gaugePosition.Y + gaugeTexture.Height) + gaugeTexture.Height / 3), Color.Yellow);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        //Kolizja na podstawie pikseli
        static bool IntersectsPixel(Rectangle rect1, Color[] data1, Rectangle rect2, Color[] data2)
        {
            int top = Math.Max(rect1.Top, rect2.Top);
            int bottom = Math.Min(rect1.Bottom, rect2.Bottom);
            int left = Math.Max(rect1.Left, rect2.Left);
            int right = Math.Min(rect1.Right, rect2.Right);

            for(int y = top; y < bottom; y++)
                for(int x = left; x < right; x++)
                {
                    Color colour1 = data1[(x - rect1.Left) + (y - rect1.Top) * rect1.Width];
                    Color colour2 = data2[(x - rect2.Left) + (y - rect2.Top) * rect2.Width];

                    if (colour1.A != 0 && colour2.A != 0)
                        return true;
                }

            return false;
        }

    }
}
