using JetFlow.Infra.Services;
using JetFlow.Infra.UseCases.User.Command;
using JwtFlow.Auth.Test.Mock;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace JwtFlow.Auth.Test.Infra.UseCases.Commands;

public class EntityTestBaseCommand
{
    protected readonly HandlerCommand HandlerCommand;
    
    private readonly FakeUnitOfWork _fakeUnitOfWork = new FakeUnitOfWork();
    private readonly IConfiguration _mockConfiguration; 
    private readonly IMemoryCache _mockCache; 

    protected EntityTestBaseCommand()
    {
        _mockConfiguration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {"Jwt:PrivateKey", "-----BEGIN RSA PRIVATE KEY-----\nMIIEoQIBAAKCAQEAxfXqYokkLtqe/nCK9DnLPcFtWaUWTr/BdrE83q/FVYitx0IG\n7wxQ1lMnaC+SEBIu++WOq0AR2GD/Jr0WTAnE5Hrk7AAkOuTYyVFfhNJA8zwmGWG1\nK/5BwsqPtbx5B76zVfFIVMfbUuvUvBkxoafOu9QaK42gH55ncJawEWYbhG11z4VC\nLI8OLq2HVFZwG7rX4aBMQhTl4amkRmep75RaOggqQ4gKkAXFFj/3RYo8BoCh2XSz\nI3TpYfSZYtKHT7hLr9IsQsvlSkv1gqQf8fCv2k/Ok6CBLtKlgk/0rjQnx2SnBBR6\nIWuBSnspEHEtCn0Z1e3A2RfCmw7LFUWZZFl3JQIDAQABAoIBAHxSUl6LjiO2vL9C\nYqG6Yf9oqInx+a5/Erq92GJptN5gtfI7bytVarcPBeKSbYKWSNd9dTnrRMnFMLhd\na9FZGUP8QiRMenRaICNebUR23r9i+PJbwHHefeIdYF9b/A53Hx1MKIbF9OGApdtz\nXw4M2vJu4/iSOwtgacn1eKGUpJdnIf7/hZ0a//PfVAGtDOYtSJ8ldrtCFB7YWtjr\ndfINo/y5i/9kZuwXYKxa/JQk6SZlLTxearQbV5fVCdbnTAFKhZcDuhmqdgghlFgd\nhrj4P4VDibuT+xjo0MYRPw/Z8e/JOE1mt/kHRSCoXve1pBaErCCS2z9xR1SfmO/q\n3XDE4gkCgYEAxxhFFZnrpGvwEa0P3Vm8TZR0f+9D/VcyXXNcHzoGiM1+0wE8McHS\ntZHGvVcvmKxbNsYoefWozGKA0opXTdZSUQorG5bW8mWoNAesaURF5Adsj98JfhU1\nl07q/u0b7NLo5oo/3G5GjWrOgmMpOaNQtvA9vsUIzC2s/sO9BJ/DTRMCgYEA/oqo\nIVkgARYURzWLOa5Ddu4OKsmP3TowQmZ6/2Xt0PYf0kiNETE7OpYA4JGH7HDPP+ZB\nUcG+jkFqvCj/Xhfw8HliJC5ipTo0F7P0mTFcq7gylIiXhJfw3WTH0ARwFPpPfYIb\n8ApzuIxnswEY2s70VziLGaM5wD1lS+Rv54hZyecCgYArLLQujwZuzYluC92Y3tDa\n8gqhg712vuYJJe8gRnEMUaPjFi17jNCo10gF31ZPAXF2W1qDuCY2zFWrUpzEIGoR\ncOcQQJG0Vx82yUM2QLv3SzTbrj5cvTS170M+rSSVItemxuw6XR+nozXNSLuz6Bqk\n0UxShl/2ByGwzbm7uvmbSQJ/dFTqglM5TUXJ/sF53+LE8pXZ47Q7C+CMLcyoahEr\nn1TdNj3yOulFKIFl5Tyd4nGsRof1Umg5rso2/ce+7kIC2+Sd9es9KkZviGW2ZE0r\nDVAhzcCffvnyGzz0FR3yG6RKsBHGsu4T9UQ2IJlfwqDTCwnMiOsQecuVgBnnCupG\nHwKBgQCcgCmxGL9MPYFlXQzXXk9OFgpcSVsti3QAzGcghiH9cPqAjwNj8F0C2qVF\nCBrtiKptIi+LogUPsDM4NKDY3/BhCwoWlPUbM0i98R7fyVnHMqRdOfcZPgBkjsJQ\nRTc5iNjdRuV+8gfsBDQdFUBT6+FJiwjGYtowO7vZRxJHW+i8kg==\n-----END RSA PRIVATE KEY-----"} 
            })
            .Build();
        _mockCache = new MemoryCache(new MemoryCacheOptions());

        var serviceToken = new ServiceToken(_mockConfiguration,_mockCache);

        HandlerCommand = new HandlerCommand(_fakeUnitOfWork, serviceToken);
    }
}