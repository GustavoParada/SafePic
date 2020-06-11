using AutoFixture;
using Swashbuckle.AspNetCore.Examples;

namespace Infra.IoC
{
    public abstract class ModelExample<T> : IExamplesProvider where T : class
    {
        private readonly IFixture _fixture;

        protected ModelExample()
        {
            this._fixture = new Fixture();
        }

        public virtual object GetExamples()
        {
            return this._fixture.Create<T>();
        }
    }
}
