using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using m4dragon.DAL_Server;
using m4dragon.Models_Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DragonsEye.Logic;
using DragonsEye;
using Crypto = m4dragon.Models_Server.Crypto;

namespace m4dragon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        // TODO: Get to pull all messages encrypted.
        // TODO: Get to pull individual message.
        // TODO: Post to insert a message.
        // TODO: Get to pull daily_settings.

        private ICryptoSqlDAO cryptoDAO;
        private DragonsEye.Logic.Crypto cryptoLogic = new DragonsEye.Logic.Crypto();

        public CryptoController(ICryptoSqlDAO cryptoSql)
        {
            this.cryptoDAO = cryptoSql;
        }

        [HttpPost]
        public ActionResult<string> Encipher(MessageInformation messageInformation)
        {            
            List<Models_Server.Crypto> settings = this.cryptoDAO.SelectDailySettings(messageInformation.DayOfYear, messageInformation.Hour);

            this.cryptoLogic.SetRotors(settings[0].Rotors, settings[0].BetaOrGamma, settings[0].StartingPosition);

            string symbolsReplaced = messageInformation.Message.ToUpper().FormatPunctuation(false);
            string encryptedMessage = cryptoLogic.Encrypt(symbolsReplaced).InsertGroupingSpaces();

            return Ok(encryptedMessage);
        }

        [HttpPut]
        public ActionResult<string> Decipher(MessageInformation messageInformation)
        {
            List<Models_Server.Crypto> settings = this.cryptoDAO.SelectDailySettings(messageInformation.DayOfYear, messageInformation.Hour);

            this.cryptoLogic.SetRotors(settings[0].Rotors, settings[0].BetaOrGamma, settings[0].StartingPosition);

            string degroupedMessage = messageInformation.Message.ToUpper().RemoveSpaces();
            string decipheredMessage = cryptoLogic.Encrypt(degroupedMessage).FormatPunctuation(true);

            return Ok(decipheredMessage);
        }
    }
}

/*        [HttpGet]
        public ActionResult<List<Models_Server.Crypto>> GetDailySettings(int dayOfYear, int hour)
        {
            List<Models_Server.Crypto> settings = cryptoDAO.SelectDailySettings(dayOfYear, hour);
            if (settings == null) { return NotFound(); }
            else { return Ok(settings); }
        }*/