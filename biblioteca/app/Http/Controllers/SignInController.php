<?php

namespace App\Http\Controllers;
use App\Http\Controllers\BibliotecaController;
use Illuminate\Http\Request;
use GuzzleHttp\Client;
use GuzzleHttp\Exception\GuzzleException;
use function GuzzleHttp\json_decode;
use function GuzzleHttp\json_encode;
use Session;

class SignInController extends Controller
{
    public function store()
    {
        $client = new Client([
            'headers'=>['Content-Type' => 'application/json']
         ]);
        $response = $client->post('34.217.191.19/libraryapi/api/Security/LoginUser', [
            'body'=>json_encode([
                'username' => request('id'),
                'password' => request('password'),
            ])
         ]);
        $datos = json_decode($response->getBody()->getContents());

        $user = ''; $id = ''; $name =''; $roleId=''; $permisions =''; $vector[] = array();
        $permiso1 = ''; $permiso2 = ''; $permiso3 = '';
        foreach ($datos as $value) {
            foreach ($value as $data) {
                //dd($data);
                $user = with($data->Estado);
                $id = with($data->UserId);
                $name = with($data->UserName);
                $roleId = with($data->RoleId);


                $permisions = with($data->Permisision);

                foreach ($permisions as $permiso) {
                    $vector[] = $permiso->PermissionsId;
                }
            }
        }

        // $client = new Client();
        // $request = $client->get('http://34.217.191.19/LibraryApi/api/Category/ListCategory');
        // $menu = $request->getBody();
        session([
            'user'=> $user,
            'id'=> $id,
            'name'=> $name,
            'roleId'=> $roleId,
            // 'permiso1'=> $vector[1],
            // 'permiso2'=> $vector[2],
            // 'permiso3'=> $vector[3]
        ]);

        return redirect()->route('inicio');
    }
}
