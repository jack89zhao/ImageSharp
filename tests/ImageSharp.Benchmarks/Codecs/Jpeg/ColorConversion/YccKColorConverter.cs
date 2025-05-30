// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

using BenchmarkDotNet.Attributes;
using SixLabors.ImageSharp.Formats.Jpeg.Components;

namespace SixLabors.ImageSharp.Benchmarks.Codecs.Jpeg;

[Config(typeof(Config.Short))]
public class YccKColorConverter : ColorConversionBenchmark
{
    public YccKColorConverter()
        : base(4)
    {
    }

    [Benchmark(Baseline = true)]
    public void Scalar()
    {
        JpegColorConverterBase.ComponentValues values = new(this.Input, 0);

        new JpegColorConverterBase.YccKScalar(8).ConvertToRgbInPlace(values);
    }

    [Benchmark]
    public void SimdVector128()
    {
        JpegColorConverterBase.ComponentValues values = new(this.Input, 0);

        new JpegColorConverterBase.YccKVector128(8).ConvertToRgbInPlace(values);
    }

    [Benchmark]
    public void SimdVector256()
    {
        JpegColorConverterBase.ComponentValues values = new(this.Input, 0);

        new JpegColorConverterBase.YccKVector256(8).ConvertToRgbInPlace(values);
    }

    [Benchmark]
    public void SimdVector512()
    {
        JpegColorConverterBase.ComponentValues values = new(this.Input, 0);

        new JpegColorConverterBase.YccKVector512(8).ConvertToRgbInPlace(values);
    }
}
