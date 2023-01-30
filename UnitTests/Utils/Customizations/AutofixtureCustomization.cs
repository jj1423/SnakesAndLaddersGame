using AutoFixture.AutoMoq;

namespace UnitTests.Utils.Customizations
{
    /// <summary>
    /// Autofixture customization
    /// </summary>
    public class AutoFixtureCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize(new AutoMoqCustomization());
        }
    }
}
