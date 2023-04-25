/* AdminCon 8.0 Command Line Interface Edition - Source Code - Vector.cs
 * Intro: (Experimental) Impliments Mathematical Vectors.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/

//(Issue #00002, Code Not Audited)
//Updated @ Oct 1st, 2022; IP Addr @ 112.245.49.15; OSEnv: Windows 10 E(LTSC) 64-bit; <Ziyi Wang>.

//实验性代码：研究通过线性变换实现的图像处理算法。

namespace System.Collections.Generic
{
    public class Vector
    {
        private List<Double> BaseVectorValues; //存储n维向量的基向量值
        public Int32 Dimension;                //向量的维数

        /// <summary>
        /// .ctor()
        /// </summary>
        public Vector(Int32 Dimension)
        {
            BaseVectorValues = new List<Double>(Dimension);
            this.Dimension = this.BaseVectorValues.Count;
        }

        /// <summary>
        /// .ctor()
        /// </summary>
        public Vector(params Double[] baseVectorValues)
        {
            BaseVectorValues = new List<Double>();
            foreach (Double value in baseVectorValues) BaseVectorValues.Add(value);
            this.Dimension = this.BaseVectorValues.Count;
        }

        #region 向量的运算符重载
        /// <summary>
        /// 定义向量的加法。
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        /// <exception cref="ArithmeticException">不同维的向量无法求和。</exception>
        public static Vector operator + (Vector vec1, Vector vec2)
        {
            if (vec1.Dimension != vec2.Dimension) throw new ArithmeticException("不同维的向量无法求和。");
            Vector result = new Vector(vec1.Dimension);
            for(Int32 i = 0; i < vec1.Dimension; i ++)
            {
                result.BaseVectorValues[i] = vec1.BaseVectorValues[i] + vec2.BaseVectorValues[i];  
            }
            return result;
        }

        /// <summary>
        /// 定义向量的减法。
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        /// <exception cref="ArithmeticException">不同维的向量无法求差。</exception>
        public static Vector operator - (Vector vec1, Vector vec2)
        {
            if (vec1.Dimension != vec2.Dimension) throw new ArithmeticException("不同维的向量无法求差。");
            Vector result = new Vector(vec1.Dimension);
            for (Int32 i = 0; i < vec1.Dimension; i++)
            {
                result.BaseVectorValues[i] = vec1.BaseVectorValues[i] - vec2.BaseVectorValues[i];
            }
            return result;
        }

        /// <summary>
        /// 定义向量的内积。
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Double operator * (Vector vec1, Vector vec2)
        {
            return Vector.GetInnerProduct(vec1, vec2);
        }

        /// <summary>
        /// 定义向量与实数的乘积。
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Vector operator * (Double k, Vector vec)
        {
            Vector result = vec;
            for(Int32 i = 0; i < result.Dimension; i++)
            {
                result.BaseVectorValues[i] *= k;
            }
            return result;
        }
        public static Vector operator * (Vector vec, Double k)
        {
            Vector result = vec;
            for (Int32 i = 0; i < result.Dimension; i++)
            {
                result.BaseVectorValues[i] *= k;
            }
            return result;
        }

        /// <summary>
        /// 定义向量的夹角。
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Double operator ^ (Vector vec1, Vector vec2)
        {
            return Math.Acos(Vector.GetInnerProduct(vec1, vec2)/(vec1.GetNorm()*vec2.GetNorm()));
        }
        #endregion

        #region 向量的数值计算与变换
        /// <summary>
        /// 获取向量的欧几里得范数
        /// </summary>
        /// <returns>向量的欧式范数</returns>
        public Double GetNorm()
        {
            Int32 normSquare = 0;
            foreach(Int32 val in this.BaseVectorValues)
            {
                normSquare += val * val;
            }
            return Math.Sqrt(normSquare);
        }

        /// <summary>
        /// 求两个向量的内积。
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        /// <exception cref="ArithmeticException">两个向量维数不同时抛出异常。</exception>
        public static Double GetInnerProduct(Vector vec1, Vector vec2)
        {
            if(vec1.Dimension!=vec2.Dimension) throw new ArithmeticException("不同维的向量无法求内积。");
            Double result = 0;
            for(Int32 i = 0; i < vec1.Dimension; i++)
            {
                result += vec1.BaseVectorValues[i] * vec2.BaseVectorValues[i];
            }
            return result;
        }

        /// <summary>
        /// 将一个向量单位化。
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        /// <exception cref="ArithmeticException">零向量无法单位化。</exception>
        public static Vector Unitize(Vector vector)
        {
            foreach(Double value in vector.BaseVectorValues)
            {
                if(value != 0)
                {
                    Vector result = vector;
                    Double norm = result.GetNorm();
                    for (Int32 i = 0; i < vector.Dimension; i++)
                    {
                        result.BaseVectorValues[i] /= norm;
                    }
                    return result;
                }
            }
            throw new ArithmeticException("零向量无法单位化。");
        }

        /// <summary>
        /// 通过Schmidt正交化求得空间中一组规范正交基。
        /// </summary>
        /// <param name="vectors"></param>
        /// <returns></returns>
        /// <exception cref="ArithmeticException">线性相关的向量组无法正交化。</exception>
        public static Vector[] SchmidtOrthogonalize(params Vector[] alpha)
        {
            //如果向量组线性相关，则无法进行施密特正交化。
            //向量维数是否一致会在判断线性相关之前检查，此处无需判断。
            if (Vector.IsLinearCorrelative(alpha)) throw new ArithmeticException("线性相关的向量组无法正交化。");

            //Schmidt正交化。
            Vector[] beta = new Vector[alpha.Length];
            beta[0] = alpha[0];
            for(Int32 i = 1; i < beta.Length; i++)
            {
                for (Int32 j = 1; j < i; j++)
                {
                    alpha[i] -= (Vector.GetInnerProduct(alpha[i], beta[j]) / Vector.GetInnerProduct(beta[j], beta[j])) * beta[j];
                }
                beta[i] = alpha[i];
            }

            //单位化可得一组规范正交基。
            Vector[] UnitizedVecs = new Vector[beta.Length];
            for (Int32 i = 0; i < beta.Length; i++)
            {
                UnitizedVecs[i] = Vector.Unitize(beta[i]);
            }
            return UnitizedVecs;
        }
        #endregion

        #region 判断向量之间的关系
        /// <summary>
        /// 判断向量之间是否线性相关。如果参数中有不同维数的向量，则抛出异常。
        /// </summary>
        /// <param name="vectors"></param>
        /// <returns>如果存在一个向量与其它向量线性无关（即无法被其余向量线性表示），则返回false</returns>
        /// <exception cref="ArithmeticException">两个向量维数不同时抛出异常。</exception>
        public static Boolean IsLinearCorrelative(params Vector[] vectors)
        {
            //检查是否有不同维的向量
            for(Int32 i = 0; i < vectors.Length-1; i++)
            {
                if (vectors[i].Dimension != vectors[i+1].Dimension)
                {
                    throw new ArithmeticException($"第 {i+1} 个向量的维数不一致。");
                }
            }

            Int32 dimension = vectors[0].Dimension;
            List<Double> vecPrior = new List<Double>();
            List<Double> vecNext = new List<Double>();
            for (Int32 counter = 0; counter < vectors.Length - 1; counter ++)
            {
                vecPrior = vectors[counter].BaseVectorValues;
                vecNext = vectors[counter+1].BaseVectorValues;
                for(Int32 baseVectorIndex = 0; baseVectorIndex < dimension - 1; baseVectorIndex ++)
                {
                    if (vecPrior[baseVectorIndex] / vecNext[baseVectorIndex] != vecPrior[baseVectorIndex+1] / vecNext[baseVectorIndex+1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 判断向量之间是否线性无关。如果参数中有不同维数的向量，则抛出异常。
        /// </summary>
        /// <param name="vectors"></param>
        /// <returns>如果存在一个向量与其它向量线性相关（即可以被其余向量线性表示），则返回false</returns>
        /// <exception cref="ArithmeticException">两个向量维数不同时抛出异常。</exception>
        public static Boolean IsNotLinearCorrelative(params Vector[] vectors)
        {
            //检查是否有不同维的向量
            for (Int32 i = 0; i < vectors.Length - 1; i++)
            {
                if (vectors[i].Dimension != vectors[i + 1].Dimension)
                {
                    throw new ArithmeticException($"第 {i+1} 个向量的维数不一致。");
                }
            }

            Int32 dimension = vectors[0].Dimension;
            List<Double> vecPrior = new List<Double>();
            List<Double> vecNext = new List<Double>();
            for (Int32 counter = 0; counter < vectors.Length - 1; counter++)
            {
                vecPrior = vectors[counter].BaseVectorValues;
                vecNext = vectors[counter + 1].BaseVectorValues;
                for (Int32 baseVectorIndex = 0; baseVectorIndex < dimension - 1; baseVectorIndex++)
                {
                    if (vecPrior[baseVectorIndex] / vecNext[baseVectorIndex] == vecPrior[baseVectorIndex + 1] / vecNext[baseVectorIndex + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 判断两个向量是否正交。
        /// </summary>
        /// <param name="vec1"></param>
        /// <param name="vec2"></param>
        /// <returns></returns>
        public static Boolean IsOrthogonal(Vector vec1, Vector vec2)
        {
            return Vector.GetInnerProduct(vec1,vec2)==0?true:false;
        }
        #endregion
    }
}
