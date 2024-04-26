using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFabric
{
    public class WEKeysProcessor
    {
        public const int MILLIS_MIN = 100;
        public const int MILLIS_BASE = 150;
        public const int MILLIS_BETWEEN_ACTIONS = 300;
        PlayersActionsQueue PJActionQueue;
        DBPlayerList PlayerList;

        public PlayersActionsQueue ProcessKeysQueue(KeysStatesList KeysQueue, DBPlayerList playerList)
        {
            PJActionQueue = new PlayersActionsQueue();
            PlayerList = playerList;

            foreach (KeyValuePair<string, KeysState> PlayerKeys in KeysQueue)
            {
                ProcessPlayerKeys(PlayerKeys.Key, PlayerKeys.Value);
            }
            
            PlayersActionsQueue local = PJActionQueue;
            PJActionQueue = null;
            PlayerList = null;
            return local;
        }

        private void ProcessPlayerKeys(string PlayerUID, KeysState Keys)
        {
            DBPlayer Player = PlayerList[PlayerUID];
            TimeSpan inactivityBaseTime, inactivityMinTime, inactivityInitiativeTime, inactivityInteractTime; // = new TimeSpan(0, 0, 0, 0, MILLIS_BETWEEN_ACTIONS);
            TimeSpan LapseMove = DateTime.Now - Player.MovementStart;
            TimeSpan LapseFace = DateTime.Now - Player.Facing_Timestamp;
            TimeSpan LapseInteract = DateTime.Now - Player.Interact_Timestamp;            
            TimeSpan LapseAttack = DateTime.Now - Player.AttackStart;

            //SPECIAL: Juego para que la iniciativa sirva para algo mas que para el orden de resolucion del gameTick. El PJ se empana menos entre acciones.
            int InitiativeMillis = (Player.Initiative % (MILLIS_BETWEEN_ACTIONS + 1));
            InitiativeMillis = (Player.Initiative == InitiativeMillis) ? InitiativeMillis : MILLIS_BETWEEN_ACTIONS; //Limit [[0..300]..infinite]
            inactivityInitiativeTime = new TimeSpan(0, 0, 0, 0, (MILLIS_BASE + MILLIS_BETWEEN_ACTIONS) - InitiativeMillis);//Limit [150..450]
            inactivityInteractTime = new TimeSpan(0, 0, 0, 0, MILLIS_BASE + MILLIS_BETWEEN_ACTIONS);
            inactivityBaseTime = new TimeSpan(0, 0, 0, 0, MILLIS_BASE);
            inactivityMinTime = new TimeSpan(0, 0, 0, 0, MILLIS_MIN);


            if ((Keys.Interact || Keys.PullInteract) && (LapseInteract > inactivityInteractTime))
            {
                PJActionQueue.Add(new PlayerInteract(PlayerUID));
            }

            //Facing while moving
            if ((LapseFace > inactivityBaseTime) && (Player.Movement != 0)) //Para que cuando termine el movimiento pueda quedar encarado distinto. (Se puede cambiar varias veces entre movimientos y permite salir más rápido/fluido en una nueva dirección tras cambiar de tile)
            {
                //Facing
                if (Keys.PullUp && !Keys.Down && (Player.Facing != 1))
                {
                    PJActionQueue.Add(new PlayerFace(PlayerUID, 1));
                }
                if (Keys.PullDown && !Keys.Up && (Player.Facing != 3))
                {
                    PJActionQueue.Add(new PlayerFace(PlayerUID, 3));
                }
                if (Keys.PullRight && !Keys.Left && (Player.Facing != 2))
                {
                    PJActionQueue.Add(new PlayerFace(PlayerUID, 2));
                }
                if (Keys.PullLeft && !Keys.Right && (Player.Facing != 4))
                {
                    PJActionQueue.Add(new PlayerFace(PlayerUID, 4));
                }
            }

            if ((LapseMove > inactivityInitiativeTime) && (LapseFace > inactivityInitiativeTime) && (Player.Movement == 0))//Para que no se conecten movimientos indeseados (Tested, 100 está OK). Tras eso le añadí lo de la iniciativa.
            {
                
                if ((Keys.Up || Keys.PullUp) && !Keys.Down && !Keys.Left && !Keys.Right)
                {
                    if (Player.Facing == 1)
                    {
                        PJActionQueue.Add(new PlayerMove(PlayerUID, 1));
                    }
                    else
                    {
                        PJActionQueue.Add(new PlayerFace(PlayerUID, 1));
                    }
                }
                if (!Keys.Up && (Keys.Down || Keys.PullDown) && !Keys.Left && !Keys.Right)
                {
                    if (Player.Facing == 3)
                    {
                        PJActionQueue.Add(new PlayerMove(PlayerUID, 3));
                    }
                    else
                    {
                        PJActionQueue.Add(new PlayerFace(PlayerUID, 3));
                    }
                }
                if (!Keys.Up && !Keys.Down && (Keys.Left || Keys.PullLeft) && !Keys.Right)
                {
                    if (Player.Facing == 4)
                    {
                        PJActionQueue.Add(new PlayerMove(PlayerUID, 4));
                    }
                    else
                    {
                        PJActionQueue.Add(new PlayerFace(PlayerUID, 4));
                    }
                }
                if (!Keys.Up && !Keys.Down && !Keys.Left && (Keys.Right || Keys.PullRight))
                {
                    if (Player.Facing == 2)
                    {
                        PJActionQueue.Add(new PlayerMove(PlayerUID, 2));
                    }
                    else
                    {
                        PJActionQueue.Add(new PlayerFace(PlayerUID, 2));
                    }
                }                
            }
        }
    }
}
