const SolidityTest = artifacts.require("SolidityTest");

module.exports = function (deployer) {
  deployer.deploy(SolidityTest);
};
