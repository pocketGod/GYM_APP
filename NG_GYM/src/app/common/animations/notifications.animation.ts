import { trigger, transition, query, style, stagger, animate, state } from "@angular/animations";

export const slideDown = trigger('slideDown', [
  transition('* <=> *', [
    query(':enter, :leave', [
      style({ transform: 'translateY(-100%)' }),
    ], { optional: true }),
    query(':enter', [
      stagger('300ms', [
        animate('300ms ease-in', style({ transform: 'translateY(0%)' }))
      ])
    ], { optional: true })
  ])
]);

export const slideInOut = trigger('slideInOut', [
  state('in', style({ transform: 'translateY(0)' })),
  state('void', style({ transform: 'translateY(-100%)' })),
  transition(':enter', [
    style({ transform: 'translateY(-100%)' }),
    animate('300ms ease-in')
  ]),
  transition(':leave', [
    animate('300ms ease-in', style({ transform: 'translateY(-100%)' }))
  ])
]);

export const fadeOut = trigger('fadeOut', [
    transition(':leave', [
      animate('300ms ease-in', style({ opacity: 0 }))
    ])
]);
