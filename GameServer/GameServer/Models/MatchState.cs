using GameServer.Models.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Models
{
    [DataContract]
    public class MatchState
    {
        [DataMember]
        public Guid id;
        [DataMember]
        public Guid winnerId;
        [DataMember]
        public DateTime gameStartTime;
        [DataMember]
        public DateTime gameEndTime;
        [DataMember]
        public GameType gameType;
        [DataMember]
        public Guid playerTurnId;   //move this inside TicTacToeState ???
        //TODO: add game move counter to this and PlayerMove
        [DataMember]
        public GameOperationState operationState;
        [DataMember]
        public TicTacToeState inGameState;     //TODO: replace with generic game state
        [DataMember]
        public List<Guid> players;
    }
}
