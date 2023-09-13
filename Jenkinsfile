//Template para jenkinsFile para Backend explicado para tomar de referencia.

/* Referencia al uso de la libreria desarrollada para cumplir con los steps necesarios en CICD dentro de COTO.
    Central dev/test: jenkins-libs
    CD dev/test: jenkins-libs-cd
    Central Prod: --TBD--
    CD Prod: --TBD--
*/
@Library('jenkins-libs') _  

//Declaracion del pipeline
pipeline {

    //Declaracion de los datos necesarios para invocar a la libreria.
    environment {
        //Nombre que se le va a dar al microservicio (se usa tanto en front como en backend) la imagen de docker tambien queda con este nombre
        imagename = "ms-park-customer"
        //Versionado para la imagen de docker con el numero de build que corrió jenkins
        imagever = "1.0.0"
        //Division hace referencia a una ubicacion logica en el cluster
        //Opciones disponibles (central-backend, central-frontend)
        division = "central-backend"
        // Ruta relativa de la estructura del proyecto donde se encuentra el DockerFile tomando como base el raiz del repo.
        mspath = "./";
    }//fin de datos

	
    agent any

	
    stages {// especificaicon de stages que correra el pipelina 
		stage('build y push docker ms-park-customer') { // Stage para generar imagen y subirla a la registry de docker
            when { 
               allOf{
                    changeset "**/**"
               }
            }
            steps {// Pasos para cumplir el stage
                script { // Marca que va a correr un script (Que se encuentran dentro de la libreria debe estar siempre)
					def parameterMap = ["path": "${mspath}"] 
                    parameterMap["imagename"] = "${imagename}"
                    parameterMap["imagever"] = "${imagever}"
					dockerBuild.buildAndPush( parameterMap ); 
				} //Fin script
            }//Fin de steps
        }//fin stage build y push docker

        stage('script deployment k8s') { //Stage para implementar en Kubernetes
            when { 
               allOf{
                    changeset "**/**"
               }
            }
            steps { // Pasos para cumplir el stage
              script { // Marca que va a correr un script (Que se encuentran dentro de la libreria debe estar siempre)				  					  
					def parameterMap = ["path": "${mspath}"] 
					parameterMap["imagename"] = "${imagename}"
					parameterMap["imagever"] = "${imagever}"
					parameterMap["division"] = "${division}"
					parameterMap["containerPort"] = "80"
					parameterMap["auth"] = "no-auth"    // Se usa para que el ms requiera un access-token (auth=keycloak)
					parameterMap["backend"] = "netcore" // opciones de deploy para backend (netcore - java)

					kubernetes.executeDeployment( parameterMap );
				} //Fin script	
            }//Fin de steps
        } // Fin stage deployment Kubernetes

        stage('apply service cip k8s') { // Stage para generar Cluster IP en kubernetes
            when { 
               allOf{
                    changeset "**/**"
               }
            }
            steps { // Pasos para cumplir el stage
                script{ // Marca que va a correr un script (Que se encuentran dentro de la libreria debe estar siempre)	  									
					def parameterMap = ["path": "${mspath}"] 
					parameterMap["imagename"] = "${imagename}"
					parameterMap["division"] = "${division}"
					parameterMap["port"] = "80"
					parameterMap["targetPort"] = "80"
					
                    kubernetes.executeServiceCip( parameterMap );
				} //Fin script
            } //Fin de steps
        } // Fin de cluster ip kubernetes

        stage('Generar service y route Kong Api Gateway'){ //Stage para generar entradas route y service en kong
			when { 
               allOf{
                    changeset "**/**"
               }
            }
            steps { // Pasos para cumplir el stage
				script { // Marca que va a correr un script (Que se encuentran dentro de la libreria debe estar siempre)	  		
					def parameterMap = ["path": "${mspath}"] 
					parameterMap["imagename"] = "${imagename}"
					parameterMap["division"] = "${division}"
					
                    kong.createRouteAndService( parameterMap );
				}	//Fin script
				
			} //Fin de steps
		} // Fin de creacion en kong
    }//Fin stages

}//Fin Declaracion del pipeline