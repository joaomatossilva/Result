namespace Kspace.Result.Tests;

public class MatchTests
{
    [Fact]
    public void Success_Match_MatchSuccessPart()
    {
        var result = Result<Model>.Success(new Model());

        var isMatchSuccess = result.Match(_ => true, _ => false);

        isMatchSuccess.Should().BeTrue();
    }

    [Fact]
    public void StaticSuccess_Match_MatchSuccessPart()
    {
        var result = Result.Success(new Model());

        var isMatchSuccess = result.Match(_ => true, _ => false);

        isMatchSuccess.Should().BeTrue();
    }

    [Fact]
    public void Error_Match_MatchErrorPart()
    {
        var result = Result<Model>.Error(new Exception());

        var isMatchSuccess = result.Match(_ => true, _ => false);

        isMatchSuccess.Should().BeFalse();
    }

    [Fact]
    public async Task Success_MatchAsync_MatchSuccessPart()
    {
        var result = Result<Model>.Success(new Model());

        var isMatchSuccess = await result.Match(async _ => true, async _ => false);

        isMatchSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Error_MatchAsync_MatchErrorPart()
    {
        var result = Result<Model>.Error(new Exception());

        var isMatchSuccess = await result.MatchAsync(async _ => true, async _ => false);

        isMatchSuccess.Should().BeFalse();
    }
}