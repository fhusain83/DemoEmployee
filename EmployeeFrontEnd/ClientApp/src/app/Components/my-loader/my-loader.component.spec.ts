
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { MyLoaderComponent } from './my-loader.component';

let component: MyLoaderComponent;
let fixture: ComponentFixture<MyLoaderComponent>;

describe('my-loader component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ MyLoaderComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(MyLoaderComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});
