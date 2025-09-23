using DevTracker.Application.Interfaces;
using DevTracker.Application.Services;
using DevTracker.Data.Repositories.Interfaces;
using NSubstitute;

namespace DevTracker.Application.Tests.TagServiceTests;

public class TestBase
{
    protected ITagService _sut;
    protected ITagRepository _tagRepo = Substitute.For<ITagRepository>();

    public TestBase()
    {
        _sut = Substitute.For<TagService>(_tagRepo);
    }
}
