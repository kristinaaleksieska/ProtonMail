using NUnit.Framework;

namespace ProtonMail.TestBase
{   
    public class TestBase
    {
        //happens only once, before all tests
        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            BeforeAll();
        }

        //happens before each test
        [SetUp]
        public virtual void SetUp()
        {
            BeforeEach();
        }
        
        //happens after each test
        [TearDown]
        public virtual void TearDown()
        {
            AfterEach();
        }

        //happens after all of the tests are finished
        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            AfterAll();
        }

        public virtual void BeforeAll()
        {

        }

        public virtual void BeforeEach()
        { 
        }

        public virtual void AfterEach()
        {

        }

        public virtual void AfterAll()
        {

        }
    }
}
