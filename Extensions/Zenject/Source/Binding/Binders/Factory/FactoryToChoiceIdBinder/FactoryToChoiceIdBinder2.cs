using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject
{
    public class FactoryToChoiceIdBinder<TParam1, TParam2, TContract> : FactoryToChoiceBinder<TParam1, TParam2, TContract>
    {
        public FactoryToChoiceIdBinder(
            BindInfo bindInfo, FactoryBindInfo factoryBindInfo)
            : base(bindInfo, factoryBindInfo)
        {
        }

        public FactoryToChoiceBinder<TParam1, TParam2, TContract> WithId(object identifier)
        {
            BindInfo.Identifier = identifier;
            return this;
        }
    }
}

