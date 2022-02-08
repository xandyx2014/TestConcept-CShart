using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace Education.Application.Cursos
{
    [TestFixture]
    public class GetCursoQueryNUnitTests
    {
#pragma warning disable CS8618 
        private GetCursoQuery.GetCursoQueryHandler handlerAllCursos;
#pragma warning restore CS8618 


        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            cursoRecords.Add(fixture.Build<Curso>()
                .With(tr => tr.CursoId, Guid.Empty)
                .Create()
            );


            var options = new DbContextOptionsBuilder<EducationDbContext>()
               .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
               .Options;

            var educationDbContextFake = new EducationDbContext(options);
            educationDbContextFake.Cursos.AddRange(cursoRecords);
            educationDbContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            }
            );
            var mapper = mapConfig.CreateMapper();

            handlerAllCursos = new GetCursoQuery.GetCursoQueryHandler(educationDbContextFake, mapper);

        }


        [Test]
        public async void GetCursoQueryHandler_ConsultaCursos_ReturnsTrue()
        {
            // 1. Emular al Context que representa la instancia de EF - Listo


            // 2. Emular al Mapping Profile


            // 3. Instanciar un objeto de la clase GetCursoQuery.GetCursoQueryHandler y pasarle
            // como parametros los objetos context y mapping
            // GetCursoQueryHandler(context, mapping)  => handle

            GetCursoQuery.GetCursoQueryRequest request = new();
            var resultados = await handlerAllCursos.Handle(request, null);

            Assert.IsNotNull(resultados);
        }
    }
}
