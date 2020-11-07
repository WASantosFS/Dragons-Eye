using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using m4dragon.DAL_Server;
using m4dragon.Models_Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DragonsEye.Logic;
using Crypto = m4dragon.Models_Server.Crypto;
using System.Text.RegularExpressions;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using System.Reflection.Metadata.Ecma335;

namespace m4dragon.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private ICryptoSqlDAO cryptoDAO;
        private DragonsEye.Logic.Crypto cryptoLogic = new DragonsEye.Logic.Crypto();

        public CryptoController(ICryptoSqlDAO cryptoSql)
        {
            this.cryptoDAO = cryptoSql;
        }

        private bool IsEnciphered(string message)
        {
            string pattern = @"^([012]?[0-9]?[0-9]|3[0-5][0-9]|36[0-6]):([01]?[0-9]|2[0-3])\s?$";

            Regex regex = new Regex(pattern);

            if (int.TryParse(message.Substring(0,1), out int number))
            {
                string sub = message.Substring(0, message.IndexOf(" "));

                if (regex.IsMatch(sub)) 
                { 
                    return true; 
                }
                else { return false; }
            }
            else { return false; }
        }

        private string Encipher(string message)
        {
            string symbolsReplaced = message.ToUpper().FormatPunctuation(false);
            string encryptedMessage = cryptoLogic.Encrypt(symbolsReplaced).InsertGroupingSpaces();

            return encryptedMessage;
        }

        private string Decipher(string message)
        {
            string degroupedMessage = message.Substring(6).ToUpper().RemoveSpaces();
            string decipheredMessage = cryptoLogic.Encrypt(degroupedMessage).FormatPunctuation(true);

            return decipheredMessage;
        }

        [HttpPost]
        public ActionResult<string> Cipher(MessageInformation messageInformation)
        {     
            if (!IsEnciphered(messageInformation.Message))
            {
                List<Models_Server.Crypto> settings = this.cryptoDAO.SelectDailySettings(messageInformation.DayOfYear, messageInformation.Hour);

                this.cryptoLogic.SetRotors(settings[0].Rotors, settings[0].BetaOrGamma, settings[0].StartingPosition);
                
                return $"{messageInformation.DayOfYear}:{messageInformation.Hour} {Encipher(messageInformation.Message)}";
            }
            else
            {
                List<string> split = messageInformation.Message.Substring(0, messageInformation.Message.IndexOf(" ")).Split(":").ToList();
                
                List<Models_Server.Crypto> settings = this.cryptoDAO.SelectDailySettings(int.Parse(split[0]), int.Parse(split[1]));

                this.cryptoLogic.SetRotors(settings[0].Rotors, settings[0].BetaOrGamma, settings[0].StartingPosition);

                return Decipher(messageInformation.Message);
            }
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