<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class SavePermissionRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     *
     * @return bool
     */
    public function authorize()
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array
     */
    public function rules()
    {
        return [
            'id'=>'required',
            'name'=>'required',
            'state'=>'required'
        ];

    }

    // public function messages(){
    //     return [
    //         'id.required' => 'El proyecto necesita un id',
    //         'name.required' => 'El proyecto necesita un id',
    //         'state.required' => 'El proyecto necesita un id'
    //     ];
    // }
}
