using LinqProject.Input;
using System;

namespace LinqProject
{
    class MainProject
    {
        static void Main(string[] args)
        {

            #region instance of classes      
            AggregateOperators aggregateOperators = new AggregateOperators();
            ElementOperators elementOperators = new ElementOperators();
            EqualityOperator equalityOperator = new EqualityOperator();
            FilteringOperators filteringOperators = new FilteringOperators();
            GenerationOperators generationOperators = new GenerationOperators();
            GroupingOperators groupingOperators = new GroupingOperators();
            JoiningOperators joiningOperators = new JoiningOperators();
            PartitioningOperators partitioningOperators = new PartitioningOperators();
            ProjectionOperators projectionOperators = new ProjectionOperators();
            QuantifierOperators quantifierOperators = new QuantifierOperators();
            SetOperators setOperators = new SetOperators();
            SortingOperators sortingOperators = new SortingOperators();
            #endregion

            #region Aggregate(Average,Count,Max,Min,Sum)
            aggregateOperators.AverageOperator();
            aggregateOperators.CountOperator();
            aggregateOperators.MaxOperator();
            aggregateOperators.MinOperator();
            aggregateOperators.SumOperator();
            #endregion

            #region Filtering(Where,OfType,Where..Contains)
            filteringOperators.WhereOperator();
            filteringOperators.OfTypeOperator();
            #endregion

            #region Element(ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault)
            elementOperators.ElementAtOperator();
            elementOperators.ElementAtOrDefaultOperator();
            elementOperators.FirstOperator();
            elementOperators.FirstOrDefaultOperator();
            elementOperators.LastOperator();
            elementOperators.LastOrDefaultOperator();
            elementOperators.SingleOperator();
            elementOperators.SingleOrDefaultOperator();
            #endregion

            #region Equality(SequenceEqual)
            equalityOperator.SequenceEqualOperator();
            #endregion

            #region Generation(DefaultIfEmpty,Empty,Range,Repeat)
            generationOperators.DefaultIfEmptyOperator();
            generationOperators.EmptyOperator();
            generationOperators.RangeOperator();
            generationOperators.RepeatOperator();
            #endregion

            #region Gouping(GroupBy,ToLookup)
            groupingOperators.GroupByDepartmentNGenderOperator();
            groupingOperators.GroupByOperator();
            groupingOperators.ToLookupOperator();
            #endregion

            #region Joining(Join,GroupJoin)
            joiningOperators.LeftOuterJoinOperator();
            joiningOperators.JoinOperators();
            joiningOperators.GroupJoin();
            #endregion

            #region Partitioning(Skip,SkipWhile,Take,TakeWhile)
            partitioningOperators.TakeOperator();
            partitioningOperators.SkipOperator();
            partitioningOperators.TakeWhileOperator();
            partitioningOperators.SkipWhileOperator();
            #endregion

            #region Projection(Select,SelectMany)
            projectionOperators.SelectOperator();
            projectionOperators.SelectManyOperator();
            #endregion

            #region Quantifier(All, Any, Contains)
            quantifierOperators.AllOperators();
            quantifierOperators.AnyOperators();
            quantifierOperators.ContainsOperators();
            #endregion

            #region Set(Distinct,Except,Intersect,Union)
            setOperators.DistinctOperator();
            setOperators.ExceptOperator();
            setOperators.IntersectOperator();
            setOperators.UnionOperator();
            #endregion

            #region Sorting(OrderBy,OrderByDecending,ThenBy,ThenByDescending, Reverse)
            sortingOperators.OrderByOperator();
            sortingOperators.OrderByDecendingOperator();
            sortingOperators.ThenByOperator();
            sortingOperators.ThenByDescendingOperator();
            #endregion

            Console.ReadLine();
        }
    }
}
