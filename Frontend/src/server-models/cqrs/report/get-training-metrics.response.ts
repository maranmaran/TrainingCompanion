import { ChartData } from 'src/server-models/entities/chart-data';

export class GetTrainingMetricsResponse {
  totalVolumeChartData:              ChartData<number, string>;
  volumeSplitChartData:              ChartData<number, string>;
  weightedAverageIntensityChartData: ChartData<number, string>;
  numberOfLiftsChartData:            ChartData<number, string>;
  relativeZoneOfIntensityChartData:  ChartData<string, string>;
}
