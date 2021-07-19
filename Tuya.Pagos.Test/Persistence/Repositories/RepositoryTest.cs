using Tuya.Pagos.Test.TestConfigurations;

using Xunit;

namespace Tuya.Pagos.Test.Persistence.Repositories
{
    public class RepositoryTest: MemoryDbFactoryTest
    {


        public RepositoryTest()
        {
            base.Init();
        }



        [Fact]
        public void Should_Save()
        {

        }
    }
}
