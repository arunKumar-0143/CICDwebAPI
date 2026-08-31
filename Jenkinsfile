pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build CICDProject.sln'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test CICDProject.sln'
            }
        }
    }
}
