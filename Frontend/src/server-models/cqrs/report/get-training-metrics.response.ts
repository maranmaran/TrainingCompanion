import { ChartData } from 'src/server-models/entities/chart-data';

export class GetTrainingMetricsResponse {
  totalVolumeChartData:              ChartData<number>;
  volumeSplitChartData:              ChartData<number>;
  weightedAverageIntensityChartData: ChartData<number>;
  numberOfLiftsChartData:            ChartData<number>;
  relativeZoneOfIntensityChartData:  ChartData<string>;
}
