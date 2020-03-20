import { Guid } from 'guid-typescript';
import { TrackItem } from '../../../../server-models/entities/track-item.model';
import { TestCardComponent } from '../dashboard-home/track-items-sidebar/card-components/test-card/test-card.component';

export enum DashboardCards {
  Test = 'Test',
  Test1 = 'Test1',
  Test2 = 'Test2',
  Test3 = 'Test3',
  Test4 = 'Test4',
}

export const dashboardCards = {
  Test: TestCardComponent,
  Test1: TestCardComponent,
  Test2: TestCardComponent,
  Test3: TestCardComponent,
  Test4: TestCardComponent,
}

export const sidebarCards = {
  Test: `
          <h4>Track pie chart data: </h4>
          <i class="fas fa-chart-pie fa-5x row-center additional-padding"></i>
        `,
  Test1: `
          <h4>Track bar chart data: </h4>
          <i class="fas fa-chart-bar fa-5x row-center additional-padding"></i>
        `,
  Test2: `
          <h4>Track line chart data: </h4>
          <i class="fas fa-chart-line fa-5x row-center additional-padding"></i>
        `,
  Test3: `
          <h4>See latest activities: </h4>
          <i class="fas fa-list fa-5x row-center additional-padding"></i>
        `,
  Test4: `
          <h4>Track your todos: </h4>
          <i class="fas fa-tasks fa-5x row-center additional-padding"></i>
        `,
}

export const mainDashboardComponents: TrackItem[] = [
  { component: DashboardCards.Test, code: 'test', id: Guid.EMPTY, params: null },
  { component: DashboardCards.Test1, code: 'test1', id: Guid.EMPTY, params: null },
  { component: DashboardCards.Test2, code: 'test2', id: Guid.EMPTY, params: null },
  { component: DashboardCards.Test3, code: 'test3', id: Guid.EMPTY, params: null },
  { component: DashboardCards.Test4, code: 'test4', id: Guid.EMPTY, params: null },
  { component: DashboardCards.Test4, code: 'test4', id: Guid.EMPTY, params: null },
  { component: DashboardCards.Test4, code: 'test4', id: Guid.EMPTY, params: null },
]
