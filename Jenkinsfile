def BuildSolution(configuration)
{
    powershell """cd 'C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin'
                  .\\MSBuild.exe ${env.WORKSPACE}\\Fizzobuzzci.sln /p:Configuration=${configuration},Platform="Any CPU" /t:build /restore"""
}

def RunTests(configuration)
{
    // Run vstest console on test project DLL generated. Ensure something is logged that Jenkins can consume to display test results.
    powershell "& 'C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\Common7\\IDE\\CommonExtensions\\Microsoft\\TestWindow\\VsTest\\vstest.console.exe' /Logger:trx Test\\bin\\${configuration}\\net6.0-windows\\FizzobuzzciTest.dll"
    mstest testResultsFile:"TestResults/*.trx", keepLongStdio: true
}

pipeline
{
    agent none
    options
    {
        timeout(time: 1200, unit: 'SECONDS')
    }

    stages
    {
        stage('Build Solution')
        {
            parallel
            {
                stage('Debug Build')
                {
                    agent any
                    steps
                    {
                        git(branch: env.BRANCH_NAME, credentialsId: 'b15ff232-f75e-413e-b391-0d2a72b85d54', url: 'https://github.com/elynch93/Fizzobuzzci')
                        BuildSolution('Debug')
                        RunTests('Debug')
                    }
                }

                stage('Release Build')
                {
                    agent any
                    steps
                    {
                        git(branch: env.BRANCH_NAME, credentialsId: 'b15ff232-f75e-413e-b391-0d2a72b85d54', url: 'https://github.com/elynch93/Fizzobuzzci')
                        BuildSolution('Release')
                        RunTests('Release')
                    }
                }
            }
        }

        stage('Merge Testing')
        {
            agent any
            when
            {
                beforeAgent true
                anyOf
                {
                    changeRequest(target: 'main')
                    branch('main')
                }
            }
            steps
            {
                // Do some testing to protect main branch (and when main branch has code merged to it).
                echo('Merge testing...')
            }
        }
    }
}