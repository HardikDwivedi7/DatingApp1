import { Component, EventEmitter, inject, input, output, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountService = inject(AccountService);
  private toaster = inject(ToastrService);
  // @Input() usersFromHomeComponent: any; old approach before angular 17.3
  // usersFromHomeComponent= input.required<any>()
  // @Output() cancelRegister= new EventEmitter();
  cancelRegister= output<boolean>();
  model: any ={}

  register(){
    // console.log(this.model);
    this.accountService.register(this.model).subscribe({
      next: response =>{
        console.log(response);
        this.cancel();
      },
      // error: error=>console.log(error)
      error: error=>this.toaster.error(error.error)
    })
  }

  cancel(){
    this.cancelRegister.emit(false);
    // console.log('cancelled');
  }
}
