using Microsoft.AspNetCore.Mvc;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NethereumCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockChainController: ControllerBase
    {
        public BlockChainController()
        {

        }

        [HttpGet]
        public async Task<dynamic> Get()
        {
            //var web3 = new Web3("https://ropsten.infura.io/v3/4ca92ff296f346f7989c4b056a93ff3a");

            var web3 = new Web3();

            var balance = await web3.Eth.GetBalance.SendRequestAsync("0x781645B723450a82f1D9890eFb633E4F522133CE");
            var etherAmount = Web3.Convert.FromWei(balance.Value);

            var latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            var latestBlock = await web3.Eth.Blocks.GetBlockWithTransactionsHashesByNumber.SendRequestAsync(latestBlockNumber);


            var balance1 = await web3.Eth.GetBalance.SendRequestAsync("0x12890d2cce102216644c59daE5baed380d84830c");
            var etherAmount1 = Web3.Convert.FromWei(balance1.Value);

            var privateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
            var account = new Account(privateKey);

            var web = new Web3(account);

            var toAddress = "0x81b7E08F65Bdf5648606c89998A9CC8164397647";

            var transaction = await web.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(toAddress, (decimal)0.1, 2, 23000);

            return etherAmount;
        }
    }
}
