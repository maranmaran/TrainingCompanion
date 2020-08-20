import { animate, style, transition, trigger } from '@angular/animations';
export const easeInOut =

    trigger('easeInOut', [
        // route 'enter and leave (<=>)' transition
        transition('*<=>*', [

            // css styles at start of transition
            style({ opacity: 0 }),

            // animation and styles at end of transition
            animate('0.5s', style({ opacity: 1 }))
        ]),
    ]);