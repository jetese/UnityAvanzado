﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Método de extensión que nos permite añadir al GameMgr nuestros Managers específicos par el juego.
/// CustomMgrs, no debería ir en una dll y ahí podremos crear nuestros propios managers y manejarlos directamente desde el GameMgr
/// </summary>
public static class GameMgrExtension
{
    /// <summary>
    /// Extension del GameMgr
    /// Tiene que ser static con this
    /// GameMgr.GetInstance().GetCustomMgrs()...
    /// </summary>
    /// <param name="gameMgr"></param>
    /// <returns></returns>
    public static CustomMgrs GetCustomMgrs(this GameMgr gameMgr)
    {
        //TODO 1:: metodo de estensión (notese el this) que nos permite añadir el CustomMgr que hemos creado, para ello primero preguntamos si el 
        //CustomMgr ha sido inicializado ya ha sido configurado, si esto es así devolvemos el customMgr del GameMgr, si no es así lo configuramos.
        // eliinar el return null.
        if(!gameMgr.IsCustomMgrInit()){
            CustomMgrs customMgrs = new CustomMgrs(gameMgr);
            gameMgr.CustomMgr = customMgrs;
        }
        return (CustomMgrs)gameMgr.CustomMgr;

    }

}


