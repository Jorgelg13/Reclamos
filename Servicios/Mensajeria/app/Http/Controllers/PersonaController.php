<?php

namespace App\Http\Controllers;

use Illuminate\Support\Facades\DB;
use App\Http\Controllers\Controller;

class PersonaController extends Controller
{
    public function todos()
    {
        $personas = DB::table('prueba')->get();
        return $personas;
    }

}
